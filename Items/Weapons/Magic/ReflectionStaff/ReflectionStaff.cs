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
        private readonly int[] mirrorIndices = new int[6] {-1, -1, -1, -1, -1, -1};

        public RelfectionStaffMirror mirror;

        public override void HoldItem(Player player)
        {
            int mirrorType = ModContent.ProjectileType<RelfectionStaffMirror>();

            bool mirrorExists;
            for (int i = 0; i < mirrorIndices.Length; i++)
            {
                int index = mirrorIndices[i];

                mirrorExists = index >= 0
                    && Main.projectile[index].active
                    && Main.projectile[index].type == mirrorType
                    && Main.projectile[index].owner == player.whoAmI;
            }

            int mirrorNumber;
            if (!mirrorExists)
            {
                float randomX = Main.rand.NextFloat(-301f, 301f);
                float randomY = Main.rand.NextFloat(-201f, 201f);
                Vector2 spawnPosition = player.Center + new Vector2(randomX, randomY);

                for (int i = 0; i < 6; i++)
                {
                    mirror = new RelfectionStaffMirror(mirrorIndices[i]);
                    mirrorNumber = mirror.getMirror();

                    mirrorNumber = Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, 0, mirrorType, 0, 0f, player.whoAmI); 
                } 
            }
        }

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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int mirrorID = mirrorIndices[1];
            Vector2 position;
            Vector2 target;
            Vector2 heading;
                           
            while (mirrorID >= 0 && Main.projectile[mirrorID].active)
            {
                position = new Vector2(player.Center.X, player.Center.Y);
                target = Main.projectile[mirrorID].Center;

                heading = (target - position).SafeNormalize(Vector2.UnitX);
                heading *= velcoity.Length();
                Projectile.NewProjectile(source, position, heading, type, damage, knockback);
                mirror.AI();
                mirrorID++;

                if (mirrorID => 6)
                {
                    mirrorID = 0;
                }
            }

            if (mirrorID < 0 && !Main.projectile[mirrorID].active)
            {
                return null;
            }
        }
    }
}