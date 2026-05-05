using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Comenzo.Items.Weapons.Melee.MagmaSword
{
	public class MagmaSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Sword"); // By de+fault, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("This is a magma sword");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 48;
            Item.DamageType = DamageClass.Melee;
            Item.UseSound = SoundID.Item1;
            Item.SetWeaponValues(127, 5, 6);
            Item.useAnimation = 35;
            Item.useTime = 35;
            
        }
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			target.AddBuff(BuffID.OnFire, 60);
		}


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Items.Placeable.Bars.MagmaBar.MagmaBar>(), 18);
            recipe.AddTile(TileType<Tiles.Anvils.MagmaAnvil.MagmaAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
