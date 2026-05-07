using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Comenzo.Items.Armor.Magma
{
    [AutoloadEquip(EquipType.Legs)]
    public class MagmaGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Magma Greaves");
            /* Tooltip.SetDefault("This leg armor provides"
                + "\n100% increased movement speed"); */
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
            Item.defense = 15; // 0; // ** The amount of defense this item provides when equipped, either as an accessory or armor. */
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
            Item.lifeRegen = 1;
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
            // item.release = 0;
            // item.reuseDelay = 0;
            // item.scale = 1f;
            // item.sentry = false;
            // item.shoot = 0;
            // item.shootSpeed = 0f;
            // item.shopCustomPrice = null;
            // item.shopSpecialCurrency = -1;
            // item.stack = 1;
            // item.tileBoost = -1;
            // item.tileWand = 0;
            // item.ToolTip = null;
            // item.type = 0;
            // item.uniqueStack = false;
            // item.useAmmo = AmmoID.None;
            // item.useAnimation = 100;
            // item.UseSound = null;
            // item.useStyle = 0; // ** The use style of your item: 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns */
            // item.useTime = 100; // ** The time span of using the item in frames. Blocks use 10. Default value is 100. Weapons usually have equal useAnimation and useTime, unequal values for these two results in multiple attacks per click.
            // item.useTurn = false; // ** Whether the player can turn around while the using animation is happening.
            Item.value = 10000; // 0;
                                // item.vanity = false;
                                // item.wet = false;
                                // item.wetCount = 0;e



            // ** Size */
            Item.height = 18; // 0;
            Item.width = 18; // 0;


            // ** Damage Type */
            // item.melee = false;
            // item.magic = false;
            // item.ranged = false;
            // item.thrown = false;
            // item.summon = false;


            // ** Tool Power */
            // item.axe = 0;
            // item.pick = 0;
            // item.hammer = 0;


            // ** Fishing Power */
            // item.bait = 0;
            // item.fishingPole = 0;


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


            // ** Static Fields */
            // item.staff = false;

            // ** tModLoader Only */
            // item.modItem = null;
            // item.globalItems = new GlobalItem[0];
        }

        public override void UpdateEquip(Player player)
        {
            Item.lifeRegen = 10;

            Player.jumpHeight  += 30; // 15;
            Player.jumpSpeed   += 7f; // 5.01f;
            player.maxRunSpeed  += 2f; // 3f;
            player.runAcceleration  += 0.15f; // 0.08f;
            player.moveSpeed += 10f; // 0.05f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            // recipe.AddIngredient(ItemType<EquipMaterial>(), 45);
            // recipe.AddTile(TileType<ExampleWorkbench>());

            recipe.AddIngredient(ItemType<Placeable.Bars.MagmaBar.MagmaBar>(), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}