namespace Comenzo.Items.Tools.Hooks
{
    internal class SteelHook : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.None; 
            Item.useTime = 0;
            Item.useAnimation = 0;

            Item.shootSpeed = 18f;
            Item.shoot = ModContent.ProjectileType<SteelHookProjectile>();
            
        }
    }
}