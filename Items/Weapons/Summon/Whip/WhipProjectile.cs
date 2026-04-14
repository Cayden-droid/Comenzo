namespace Comenzo.Items.Weapons.Summon.Whip
{
    public class WhipProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.IsAWhip[Type] = true; // This makes the projectile act like a whip and use whip detection. Flasks can also be applied     
        }

        public override void SetDefaults()
        {
            Projectile.DefaultToWhip(); // Sets whip properties 

            // Projectile.WhipSettings.Segments = 20; Is vanilla default
            // Projectile.WhipSettings.RangeMultiplier = 1f; Is vanilla default
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.Bufftype<WhipDebuff>(), 240); // Applies the tag damage debuff
            Main.player[Projectile.onwer].MinionAttackTargetNPC = target.whoAmI; // This tells the minion to target whichever enemy is marked
            Projectile.damage  = (int)(Projectile.damage * 0.25f); // Multi-hit penalty, decreases damage by 25%
        }

        private void DrawLine(List<Vector2> list) // This draws a line between all points of a whip incase of empty space between sprites
        {
            Texture2D texture = TextureAssets.FishingLine.value; 
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

                Main.EntitiySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0); 

                pos += diff;
            }
        }
    }
}