using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SecretsOfMana.Items.Weapons.Magic.ReflectionStaff
{
    public class ReflectionStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.damage = 500;
            Item.knockBack = 5f;
            Item.width = 24;
            Item.height = 48;
            Item.scale = 1f;
            Item.UseSound = SoundID.Item1;
            Item.value = Item.buyPrice(gold: 75);
            Item.DamageType = DamageClass.Magic;
            Item.shoot = ModContent.ProjectileType<ReflectionStaffProjectile>();
            Item.noMelee = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velcoity, int type, int damage, float knockback)
        {
            Item.shoot = ModContent.ProjectileType<RelfectionStaffMirror>();
            for (i = 0; i < 6; i++)
            {
                Vector2 target = new Vector2(Main.rand.NextFloat(801), Main.rand.NextFloat(801));
                position = target;
                velcoity = 0;
                knockback = 0f;
                damage = 0;
                Projectile.NewProjectile(source, position, velcoity, type, damage, knockback);
            }

            Item.shoot = ModContent.ProjectileType<ReflectionStaffProjectile>();
            while (RelfectionStaffMirror.ProjectileExists == true)
            {
                RelfectionStaffMirror.AI();  
            }                         
        }
    }
}