namespace Comenzo.Projectiles
{
    public class MagmaArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.FiresFewerFromDaedalusStormbow[type] = true; // Fires fewer arrows for DaedalusStormbow for balancing based of the type of arrow
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;

            Projectile.arrow = true;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 1200; // Total amount of time the projectile can be alive without hitting something.
        }

        public override void AI()
        {
            // Applies gravity after quarter a second
            // 15f here is a quarter second so 1f here would be about 1/60th of a second
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 15f)
            {
                Projectile.ai[0] = 15f;
                Projectile.velocity += 0.1f;
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2; // The projectile is rotated to face the direction of travel

            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity = 16f;
            }
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