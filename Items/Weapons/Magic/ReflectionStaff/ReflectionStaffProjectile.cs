using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SecretsOfMana.Items.Weapons.Magic.ReflectionStaff
{
    public class ReflectionStaffProjectile : ModProjectile
    {
        // Placeholder sprite until ReflectionStaffProjectile.png exists
        public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.AmethystBolt;

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 300;
        }
    }
}
