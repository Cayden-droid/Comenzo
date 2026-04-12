
namespace Comenzo.Items.Tools.Hooks
{
    public class SteelHookProjectile : ModProjectile
    {
        public override void Load()
        {
            chainTexture = ModContent.Request<Texture2D>("Comenzo/Items/Tools/Hooks/SteelHookChain");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
        }

        public override bool? CanUseGrapple(Player player) // Allows the player to shoot out multiple hooks at once
        {
            int hooksOut = 0; // Defines how main hooks are out
            foreach (var projectile in Main.ActiveProjectiles)
            {
                if (projectile.owner == Main.myPlayer && projectile.type == Projectile.type)
                {
                    hooksOut++; // For each hook that is shoot out another is added, until the maximum amount of hooks is met. 
                }
            }

            return hooksOut <= 2;
        }

        public override float GrappleRange() // Sets the maximum distance the hook can be fired 
        {
            return 500f; 
        }

        public override void NumGrappleHooks(Player player, ref int numHooks) // Sets the maxmimum number of hooks 
        {
            numHooks = 2;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed) // Sets the speed at which the hook is retracted
        {
            speed = 18f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed) // Sets the speed at which a player is pulled to a mounted block
        {
            speed = 10; 
        }
        
        public override bool PreDrawExtras()
        {
            Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter; 
            Vector2 center = Projectile.Center;
            Vector2 directionToPlayer = playerCenter - Projectile.Center;
            float chainRotation = directionToPlayer.ToRotation() - MathHelper.PiOver2;
            float distanceToPlayer = directionToPlayer.Length(); 

            while (distanceToPlayer > 20f && !float.IsNaN(distanceToPlayer))
            {
                directionToPlayer /= distanceToPlayer;
                directionToPlayer *= chaintexture.Height();

                center += directionToPlayer; 
                directionToPlayer = playerCenter - center;
                distanceToPlayer = directionToPlayer.Length();

                Color drawColor = Lighting.GetColor((int)center.X / 16, (int)(center.Y / 16));

                Main.EntitiySpriteDraw(chainTexture.Value, center - Main.screenPosition,
                    chainTexture.Value.Bounds, drawColor, chainRotation,
                    chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0);

            }
            // Stops vanilla from drawing the default chain.
            return false;
        }
    }
}