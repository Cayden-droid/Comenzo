using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace SecretsOfMana.Items.Weapons.Melee.DualSlashSword
{
    public class DualSlashSwordProjectileAlt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Types] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee; 
            Projectile.penetrate = 25;
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

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float coneLength = 94f * Projectile.scale;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            
        }
    }
}