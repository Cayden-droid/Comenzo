using Microsoft.Xna.Framework;
using SecretsOfMana.Items.Armor.Magma;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SecretsOfMana.Items.Weapons.Melee.CustomProjectileSword
{
    public class CustomProjectileSwordProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Types] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee; 
            Projectile.penetrate = 5;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.ownerHitCheckDistance = 300f;
            Projectile.usesOwnerMeleeHitCD = true;
            Projectile.stopDealingDamageAfterPenetrateHits = true;

            Projectile.aiStyle = -1;

            Projectile.noEnchantmentVisuals = true;
        }

        public override void AI()
        {
            Projectile.localAI[0]++;
            Player player = Main.player[Projectile.owner];
            float percentageOfLife = Projectile.localAI[0] / Projectile.ai[1];
            float direction = Projectile.ai[0];

            float scaleMulti = 0.6f;
            float scaleAdder = 1f;

            Projectile.scale = scaleAdder + percentageOfLife * scaleMulti;
            
            float dustRotation = Main.rand.NextFloatDirection() * MathHelper.PiOver2 * 0.7f;
            Vector2 dustPosition = Projectile.Center + dustRotation.ToRotationVector2() * 84f * Projectile.scale;
            Vector2 duseVelocity = (dustRotation + Projectile.ai[0] * MathHelper.PiOver(2)).ToRotationVector2();

            if (Projectile.localAI[0] >= Projectile.ai[1])
            {
                Projectile.Kill();
            }
        }
    }
}