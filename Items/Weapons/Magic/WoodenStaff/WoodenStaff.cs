
namespace Comenzo.Items.Weapons.Magic.WoodenStaff
{
    public class WoodenStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToStaff(ProjectileID.BlackBolt, 7, 20, 11); // Using DefaultToStaff sets various item values for magic weapons. (Defining what the projectile is, x value, y value, velocity?)
            Item.width = 34; 
            Item.height = 40;
            Item.UseSound = SoundID.Item71;

            Item.SetWeaponValues(25, 6, 32); // SetWeaponValues Sets (Damage, Knockback, CritChance)
            Item.SetShopValues(ItemRarityColor.LightRed4, 10000); // SetShopValues takes care of the item rarity and value. 
        }

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.WoodenStaff) // A more advanced way to add a recipe, It assigns the recipe of the Item ID and allows chaining  
                .AddIngredient(ItemID.DirtBlock, 10) // Chaining works be assigning all the values like ingredient or tile to Recipe.Create. 
                .AddTile(TileID.WorkBenches) // This method allows creation of a recipe without having to assign each value individualy to recipe.
                .Register();
        }

        public override void ModifyManaCost(Player player, ref float reduce, ref float mult)
        // (Player player, is making sure that it is refrenceing to the player. This part is assigns the function as a reduction. This part assigns how the reduciton will be arithmeticaly opperated) 
        {
            if (player.statLife < player.statLifeMax2 / 2) // Checks player life relative to max player life
            {
                mult *= 0.5f; // Halfes the mana cost under half max life. 
            }
        }
    }
}