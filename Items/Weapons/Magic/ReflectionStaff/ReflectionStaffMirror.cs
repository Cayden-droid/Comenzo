using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SecretsOfMana.Items.Weapons.Magic.ReflectionStaff
{
    public class RelfectionStaffMirror : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Types] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.damage = 0;
            Projectile.width = 16;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.noEnchantmentVisuals = true;
            boolean ProjectileExists = true;
        }

        public override void AI()
        {
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile other = Main.projectile[i];

                if (other.active && i != Projectile.whoAmI && other.type == ModContent.ProjectileType<ReflectionStaffProjectile>())
                {
                    if (Projectile.Hitbox.Intersects(other.Hitbox))
                    {
                        ReflectProjectile(other);
                    }
                }
            }
        }

        private void ReflectProjectile(Projectile proj)
        {
            proj.velcoity.X *= -1f;
            proj.position += proj.velcoity;

            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item150, Projectile.position);
            Projectile.Kill();
        }
    }
}