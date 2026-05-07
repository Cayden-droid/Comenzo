using Comenzo.Items.Weapons.Summon.Whip;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Comenzo.Items.Weapons.Summon.Whip
{
    public class Whip : ModItem
    {
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(WhipDebuff.TagDamage);
        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<WhipProjectile>(), 20, 2, 4);
            Item.rare = ItemRarityID.Green; 
        }

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.Whip)
                .AddIngredient(ItemID.DirtBlock)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override bool MeleePrefix() // Gives the whip melee prefixes
        {
            return true;
        }
    }
} 