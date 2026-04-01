using Terraria.ModLoader;

using Terraria.ID;

namespace Comenzo.Items.Weapons.Melee.BrokenSword
{
    public class BrokenSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A forgotten relic of the past");
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 24; // The width of the item in use
            Item.height = 22; // The height of the item in use
            Item.value = Item.sellPrice(gold: 2, silver: 50); // The value the item sells for
            Item.rare = ItemRarityID.Green; // The rarity the item is classifed by

            // Use Properties
            Item.useTime = 40; // The time span of using the item
            Item.useAnimation = 40; // The time span of the animation of the item
            Item.useStyle = ItemUseStyleID.Swing; // The useStyle of the item
            Item.autoReuse = false; // Defines if the item can be used automatically by holding down the mouse
            Item.UseSound = SoundID.Item1; // Defines how the item sounds when used

            // Damage and Type Properties
            Item.DamageType = DamageClass.Melee; // Defines which class the item belongs to
            Item.damage = 12; // Sets the amount of damage that the item does
            Item.crit = 8; // Sets the critical chance the item has. The player by default has a 4% chance
            Item.knockBack = 6; // Sets the knockback of the item. Maximum is 20
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}