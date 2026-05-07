using Comenzo.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Comenzo.Items.Weapons.Melee.TheTrueDestroyer
{
    public class TheTrueDestroyer
    : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The True Destroyer V2");// By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
                                                            // Tooltip.SetDefault("This is a basic modded sword.");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TerraBlade);
            Item.shootSpeed *= 0.75f;
            Item.damage = (int)(Item.damage * 3000);

            // ** Fields */
            // item.accessory = false;
            // item.active = true;
            // item.alpha = 0;
            // item.ammo = AmmoID.None;
            Item.autoReuse = true; // ** Whether the item is in continuous use while the mouse button is held down.
                                   // item.buffTime = 0;
                                   // item.buffType = 0;
                                   // item.buy = false;
                                   // item.cartTrack = false;
                                   // item.channel = false;
                                   // item.color = Transparent;
                                   // item.consumable = false;
                                   // item.createTile = -1;
                                   // item.createWall = -1;
            Item.crit = 76; // ** The base critical chance for this item (%). Remember that the player has a base crit chance of 4. */
            Item.damage = 3000;
            // item.DD2Summon = false;
            // item.defense = 0; // ** The amount of defense this item provides when equipped, either as an accessory or armor. */
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
            // item.lifeRegen = 0;
            // item.makeNPC = 0;
            // item.mana = 0;
            // item.manaIncrease = 0;
            // item.material = false;
            // item.maxStack = 1;
            // item.mech = false;
            // item.mountType = -1;
            // item.netID = 0;
            // item.noMelee = false; // ** If true, the item's using animation will not deal damage. Set to true on most weapons that aren't swords.
            // item.notAmmo = false;
            // item.noUseGraphic = false;
            // item.noWet = false;
            // item.paint = 0;
            // item.placeStyle = 0;
            // item.potion = false;
            // item.prefix = 0;
            Item.questItem = true;
            // item.rare = 0;
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
            Item.useAnimation = 5;
            // item.UseSound = null;
            Item.useStyle = 1; // ** The use style of your item: 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns */
            Item.useTime = 5; // ** The time span of using the item in frames. Blocks use 10. Default value is 100. Weapons usually have equal useAnimation and useTime, unequal values for these two results in multiple attacks per click.
                              // item.useTurn = false; // ** Whether the player can turn around while the using animation is happening.
                              // item.value = 0;
                              // item.vanity = false;
                              // item.wet = false;
                              // item.wetCount = 0;



            // ** Size */
            Item.height = 20;
            Item.width = 20;


            // ** Damage Type */
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
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


		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			type = ProjectileType<TerraBeam>();
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}


	// public class TerraBeam : ModProjectile
	// {
	// 	public override void SetStaticDefaults() {

	// 	}

	// 	public override void SetDefaults() {
	// 		projectile.CloneDefaults(ProjectileID.TerraBeam);
	// 		aiType = ProjectileID.TerraBeam;
	// 	}

	// 	public override bool PreKill(int timeLeft) {
	// 		projectile.type = ProjectileID.TerraBeam;
	// 		return true;
	// 	}

	// 	public override bool OnTileCollide(Vector2 oldVelocity) {
	// 		for (int i = 0; i < 5; i++) {
	// 			int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.Starfury, (int)(projectile.damage * .5f), 0, projectile.owner);
	// 			Main.projectile[a].aiStyle = 1;
	// 			Main.projectile[a].tileCollide = true;
	// 		}
	// 		return true;
	// 	}
	// }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddRecipeGroup("IronBar", 5);
            recipe.AddTile(TileID.FireflyinaBottle);
            recipe.Register();
        }
    }
}