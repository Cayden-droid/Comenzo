
namespace Comenzo.Items.Weapons.Ranged.LongBow
{
    public class LongBow : ModItem
    {
        public override void SetDefaults() // How a bow functions is very similar to a gun 
        {
            Item.width = 32;
            Item.height = 48;
            Item.rare = ItemRarityID.White; // Ingame rarity of the item aka the color the Items name is displayed as
            Item.useTime = 8; // Item use time in ticks (60 ticks == 1 second)
            Item.useAnimation = 8; // How long the use animation lasts in ticks (60 ticks == 1 second)
            Item.useStyle = ItemUseStyleID.Shoot; 
            Item.autoReuse = true; // The item can be used be holding down the mouse button

            Item.SetWeaponValues(12, 4, 4);
            Item.DamageType = Ranged;
            Item.noMelee = true; // This stops the use animation from doing melee damage

            Item.shoot = ProjectileID.PurificaitonPowder; // What the weapon shoots like? For whatever reason PurificationPowder is the default in vinalla source 
            Item.shootSpeed = 5f; // The speed of the projectile based of pixels per frame
            Item.useAmmo = AmmoID.Arrow; // The corresponding type of ammo that the weapon uses. 
        }

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.OldGrimorie)
                .AddIngredient(ItemID.DirtBlock)
                .AddTile(TileID.WorkBenches)
                .Register();
        }


        public override Vector2? HoldOffSet() // The position of where the weapon is displayed based off the players hands 
        {
            return new Vector2(2f, -2f);
        }

    }
}