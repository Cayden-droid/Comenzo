using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace SecretsOfMana.Items.Armor.Magma
{

    // CMYK
    // C : -100%
    // M : 25%
    // Y : 100%
    // K : -25%

    [AutoloadEquip(EquipType.Body)]
    public class MagmaBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Magma Breastplate");
            /* Tooltip.SetDefault("This body armor provides"
                + "\nImmunity to 'On Fire!'"
                + "\n5 Life Regen"
                + "\n+20 max mana and +1 max minions"); */
        }

        public override void SetDefaults()
        {
            Item.defense = 60; // 0; // ** The amount of defense this item provides when equipped, either as an accessory or armor. */
            Item.lifeRegen = 500;
            Item.rare = ItemRarityID.Green; // 0;
            Item.value = 10000; 
            
            // ** Size */
            Item.height = 18; // 0;
            Item.width = 18; // 0;
        }

        public override void UpdateEquip(Player player)
        {
            player.buffImmune[BuffID.OnFire] = true;
            player.statManaMax2 += 20;
            player.maxMinions++;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            // recipe.AddIngredient(ItemType<EquipMaterial>(), 60);
            // recipe.AddTile(TileType<ExampleWorkbench>());


            recipe.AddIngredient(ItemType<Placeable.Bars.MagmaBar.MagmaBar>(), 25);
            // recipe.AddTile(TileType<MagmaAnvil>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}