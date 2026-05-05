
namespace Comenzo.Items.Weapons.Magic.OldGrimorie
{
    public class OldGrimorie : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Old Grimorie");
            Tooltip.SetDefault("A tattered old spell book");
        }
        public override void SetDefaults()
        {
            Item.DefaultToStaff(ProjectileID.BlackBolt, 7, 20, 11);
            Item.width = 34;
            Item.height = 40;
            Item.UseSound = SoundID.Item71;
            Item.SetWeaponValues(14, 4, 4);
            Item.SetShopValues(ItemRarityColor.LightRed4, 10000);
        }

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.OldGrimorie)
                .AddIngredient(ItemID.DirtBlock)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}