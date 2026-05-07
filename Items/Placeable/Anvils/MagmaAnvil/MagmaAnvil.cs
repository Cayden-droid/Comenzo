using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Comenzo.Items.Placeable.Anvils.MagmaAnvil
{
	public class MagmaAnvil : ModItem
	{
		public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Magma Anvil");
			// Tooltip.SetDefault("This is a magma anvil");
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.MythrilAnvil);
			Item.width = 28;
			Item.height = 14;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = TileType<Tiles.Anvils.MagmaAnvil.MagmaAnvil>();
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MythrilAnvil);
			recipe.AddIngredient(ItemType<Items.Placeable.Bars.MagmaBar.MagmaBar>(), 10);
            recipe.AddTile(TileID.Hellforge);
			recipe.Register();
		}
	}
}