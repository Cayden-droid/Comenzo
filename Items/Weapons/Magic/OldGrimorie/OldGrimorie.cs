using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Enums;
using static Terraria.ModLoader.ModContent;

namespace SecretsOfMana.Items.Weapons.Magic.OldGrimorie
{
    public class OldGrimorie : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Old Grimorie");
            // Tooltip.SetDefault("A tattered old spell book");
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
            Recipe.Create(ModContent.ItemType<OldGrimorie>())
                .AddIngredient(ItemID.DirtBlock)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}