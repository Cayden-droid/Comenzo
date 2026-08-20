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
            // ** Fields */
            // item.accessory = false;
            // item.active = true;
            // item.alpha = 0;
            // item.ammo = AmmoID.None;
            // item.autoReuse = false; // ** Whether the item is in continuous use while the mouse button is held down.
            // item.buffTime = 0;
            // item.buffType = 0;
            // item.buy = false;
            // item.cartTrack = false;
            // item.channel = false;
            // item.color = Transparent;
            // item.consumable = false;
            // item.createTile = -1;
            // item.createWall = -1;
            // item.crit = 0; // ** The base critical chance for this item (%). Remember that the player has a base crit chance of 4. */
            // item.damage = 0;
            // item.DD2Summon = false;
            Item.defense = 60; // 0; // ** The amount of defense this item provides when equipped, either as an accessory or armor. */
            // item.dye = 0;
            // item.expert = false;
            // item.expertOnly = false;
            // item.favorited = false; // ** 	If the item has been marked as favorited in the inventory. */
            // item.flame = false;
            // item.glowMask = -1;
            // item.hairDye = -1;
            // item.healLife = 0;
            // item.healMana = 0;
            // item.holdStyle = 0;
            // item.instanced = false;
            // item.knockBack = 0f; // ** 	The force of the knock back. Max value is 20. */
            // item.lavaWet = false;
            Item.lifeRegen = 500;
            // item.makeNPC = 0;
            // item.mana = 0;
            // item.manaIncrease = 0;
            // item.material = false;
            // item.maxStack = 1;
            // item.mech = false;
            // item.mountType = -1;
            // item.netID = 0;
            // item.noMelee = false;
            // item.notAmmo = false;
            // item.noUseGraphic = false;
            // item.noWet = false;
            // item.paint = 0;
            // item.placeStyle = 0;
            // item.potion = false;
            // item.prefix = 0;
            // item.questItem = false;
            Item.rare = ItemRarityID.Green; // 0;
            Item.value = 10000; 
            
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