using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Comenzo.Projectiles
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

		public override bool OnTileCollide(Vector2 oldVelocity) {
			for (int i = 0; i < 5; i++) {
				int a = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.Starfury, (int)(Projectile.damage * .5f), 0, Projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
			}
			return true;
		}
	}
}