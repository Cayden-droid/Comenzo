using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Comenzo.Items.Armor.Magma
{
    [AutoloadEquip(EquipType.Head)]
    public class MagmaHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Helmet");
            Tooltip.SetDefault("This helmet provides the Burning Buff!");
        }

        public override void SetDefaults()
        {

            Item.defense = 30; // 0; // ** The amount of defense this item provides when equipped, either as an accessory or armor. */
            Item.rare = ItemRarityID.Green; // 0;
            Item.value = 10000; // 0;

            // ** Size */
            Item.height = 18; // 0;
            Item.width = 18; // 0;

            // ** Assigned Slot */
            // item.backSlot = -1;
            // item.balloonSlot = -1;
            // item.bodySlot = -1;
            // item.faceSlot = -1;
            // item.frontSlot = -1;
            // item.handOffSlot = -1;
            // item.handOnSlot = -1;
            // item.headSlot = -1;
            // item.legSlot = -1;
            // item.neckSlot = -1;
            // item.shieldSlot = -1;
            // item.shoeSlot = -1;
            // item.waistSlot = -1;
            // item.wingSlot = -1;

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<MagmaBreastplate>() && legs.type == ItemType<MagmaGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {


            player.AddBuff(BuffID.OnFire, 216000, true);
            /* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemType<Placeable.Bars.MagmaBar.MagmaBar>(), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}