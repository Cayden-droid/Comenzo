using SecretsOfMana.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Enums;
using static Terraria.ModLoader.ModContent;

namespace SecretsOfMana.Items.Weapons.Melee.TheTrueDestroyer
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
            Item.autoReuse = true; // ** Whether the item is in continuous use while the mouse button is held down.
            Item.crit = 76; // ** The base critical chance for this item (%). Remember that the player has a base crit chance of 4. */
            Item.damage = 3000;
            Item.questItem = true;
            Item.useAnimation = 5;
            Item.useStyle = 1; // ** The use style of your item: 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns */
            Item.useTime = 5; // ** The time span of using the item in frames. Blocks use 10. Default value is 100. Weapons usually have equal useAnimation and useTime, unequal values for these two results in multiple attacks per click.
            Item.height = 20;
            Item.width = 20;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.shoot = ModContent.ProjectileType<TerraBeam>();
        }
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f) {
				ceilingLimit = player.Center.Y - 200f;
			}
			// Loop these functions 3 times.
			for (int i = 0; i < 3; i++) {
				position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
				position.Y -= 100 * i;
				Vector2 heading = target - position;

				if (heading.Y < 0f) {
					heading.Y *= -1f;
				}

				if (heading.Y < 20f) {
					heading.Y = 20f;
				}

				heading.Normalize();
				heading *= velocity.Length();
				heading.Y += Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
			}

			return false;
		}
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