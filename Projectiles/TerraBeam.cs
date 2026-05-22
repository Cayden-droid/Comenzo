using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace SecretsOfMana.Projectiles
{
	public class TerraBeam : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("The True Destoryer V2");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.TerraBeam);
			AIType = ProjectileID.TerraBeam;
		}


		public override bool PreKill(int timeLeft) {
			Projectile.type = ProjectileID.TerraBeam;
			return true;
		}

		public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position); // Plays a sound when the projectile hits a block
            for (int i = 0; i < 5; i++) // This conditonal function creates dust around where the projectile dies when hitting a block
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Silver);
                dust.noGravity = true;
                dust.velocity *= 1.5f;
                dust.scale *= 0.9f;
            }
        }
	}
}