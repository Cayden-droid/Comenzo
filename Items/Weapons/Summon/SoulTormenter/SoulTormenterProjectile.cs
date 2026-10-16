using SecretsOfMana.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.ModLoader;

namespace SecretsOfMana.Items.Weapons.Summon.SoulTormenter
{
    public class SoulTormenterProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.IsAWhip[Type] = true; // This makes the projectile act like a whip and use whip detection. Flasks can also be applied     
        }

        public override void SetDefaults()
        {
            Projectile.width = 18;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ownerHitCheck = true; // This prevents the projectile from hitting through solid tiles.
			Projectile.extraUpdates = 1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.DamageType = DamageClass.SummonMeleeSpeed;
			Projectile.WhipSettings.Segments = 20;
        }

        private float Timer
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }
        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2; // PiOver2 helps it be created at the right position without it, it is off by 90 degrees counterclockwise

            Projectile.Center = Main.GetPlayerArmPosition(Projectile) + Projectile.velocity * Timer;
            Projectile.spriteDirection = Projectile.velocity.X >= 0f ? 1 : -1;
            // UnitX is used here to check if the projectile's velocity is above or equal to zero on the x axis

            Timer++;

            Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out _, out _);
            if (Timer >= timeToFlyOut || owner.itemAnimation <= 0)
            {
                Projectile.Kill();
                return;
            }

            owner.heldProj = Projectile.whoAmI;
            owner.MatchItemTimeToItemAnimation();
            if (Timer == timeToFlyOut / 2)
            {
                List<Vector2> points = Projectile.WhipPointsForCollision;
                Projectile.FillWhipControlPoints(Projectile, points);
                SoundEngine.PlaySound(SoundID.Item153, points[points.Count - 1]);
            }

            float swingProgress = Timer / timeToFlyOut;

            // This conditional statement creates dust along the whip path during the swing
            if (Utils.GetLerpValue(0.1f, 0.7f, swingProgress, clamped: true) * Utils.GetLerpValue(0.9f, 0.7f, swingProgress, clamped: true) > 0.5f && !Main.rand.NextBool(3))
            {
                List<Vector2> points = Projectile.WhipPointsForCollision;
                points.Clear();
                Projectile.FillWhipControlPoints(Projectile, points);
                int pointIndex = Main.rand.Next(points.Count - 10, points.Count);
                Rectangle spawnArea = Utils.CenteredRectangle(points[pointIndex], new Vector2(30f, 30f));
                int dustType = DustID.Enchanted_Gold;
                if (Main.rand.NextBool(3))
                    dustType = DustID.TintableDustLighted;
                // This section is repsosible for randomly selecting a segment, and defining the dust; preparing it for creation
                
                // Spawns teh dust based of the spawn area
                Dust dust = Dust.NewDustDirect(spawnArea.TopLeft(), spawnArea.Width, spawnArea.Height, dustType, 0f, 0f, 100, Color.White);
                dust.position = points[pointIndex];
                dust.fadeIn = 0.3f;
                Vector2 spinningPoint = points[pointIndex] - points[pointIndex - 1];
                dust.noGravity = true;
                dust.velocity *= 0.5f;
                // This segment causes the dust to spawn with a velocity perpendicular, to the whip segments. This gives the impression of sparks flying off
                dust.velocity += spinningPoint.RotatedBy(owner.direction * ((float)Math.PI / 2f));
                dust.velocity *= 0.5f;
            }
        }


        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<WhipDebuff>(), 240); // Applies the tag damage debuff
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI; // This tells the minion to target whichever enemy is marked
            Projectile.damage  = (int)(Projectile.damage * 0.25f); // Multi-hit penalty, decreases damage by 25%
        }

        private void DrawLine(List<Vector2> list) // This draws a line between all points of a whip incase of empty space between sprites
        {
            Texture2D texture = TextureAssets.FishingLine.Value; 
            Rectangle frame = texture.Frame(); 
            Vector2 origin = new Vector2(frame.Width / 2, 2); // This is creating a new vector which will be used to draw the line. 

            Vector2 pos = list[0]; 
            for (int i = 0; i < list.Count - 1; i++) 
            {
                Vector2 element = list[i];
                Vector2 diff = list[i + 1] - element;

                float rotation = diff.ToRotation() - MathHelper.PiOver2;
                Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White); 
                Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);

                Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0); 

                pos += diff;
            }
        }

        public override bool PreDraw(ref Color lightColor) {
			List<Vector2> list = new List<Vector2>();
			Projectile.FillWhipControlPoints(Projectile, list);

			DrawLine(list);

			SpriteEffects flip = Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			Texture2D texture = TextureAssets.Projectile[Type].Value;
			Vector2 pos = list[0];

			// Draws each whip segment from the sprite sheet: handle, three segment styles, then the tip
			for (int i = 0; i < list.Count - 1; i++)
			{
				Rectangle frame = new Rectangle(0, 0, 10, 26); // The handle
				Vector2 origin = new Vector2(5, 8); // Where the player's hand holds the handle
				float scale = 1;

				if (i == list.Count - 2)
				{
					// The tip, scaled up when fully extended and down when curled up
					frame.Y = 74;
					frame.Height = 18;

					Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out int _, out float _);
					float t = Timer / timeToFlyOut;
					scale = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true));
				}
				else if (i > 10)
				{
					frame.Y = 58;
					frame.Height = 16;
				}
				else if (i > 5)
				{
					frame.Y = 42;
					frame.Height = 16;
				}
				else if (i > 0)
				{
					frame.Y = 26;
					frame.Height = 16;
				}

				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;

				float rotation = diff.ToRotation() - MathHelper.PiOver2; // The sprite faces down, so PiOver2 corrects the rotation
				Color color = Lighting.GetColor(element.ToTileCoordinates());

				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, flip, 0);

				pos += diff;
			}

			return false;
        }
    }
}