using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SecretsOfMana.Items.Weapons.Melee.DualSlashSword
{
    public class DualSlashSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.damage = 375;
            Item.knockBack = 4.5f;
            Item.width = 40;
            Item.height = 80;
            Item.scale = 1f;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(gold: 25);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModCotent.ProjectileType<DualSlashSwordProjectile>();
            Item.noMelee = true;
            Item.shootsEveryUse = true;
            Item.autoReuse = true;   
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velcoity, int type, int damage, float knockback)
        {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float cellingLimit = target.Y;
            if (cellingLimit > player.Center.Y - 200f)
            {
                cellingLimit = player.Center.Y - 200f;
            }

            for (int i = 0; i < 3; i++)
            {

                position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                position.Y -= 100 * i;
                Vector2 spawnPosition = player.Center - new Vector2(position, position.y);
                Vector2 heading = target - spawnPosition;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= velcoity.Length();
                heading.Y += Main.rand.Next(-40, 41) * 0.02f;

                Projectile.NewProjectile(source, position, heading, type, damage *2, knockback, player.whoAmI, 0f, cellingLimit);

                // This section of code is for mirroring the x positon of the projectile
                // Flips position relative to player.Center
                Vector2 mirroredPosition = player.Center + new Vector2(position - (2 *(player.Center.X - spawnPosition.X)), -position.y);
                // Heading x and y dictate the direction the projectile travels. -heading.x makes it travel in the oppostie direction of the other projectile.
                Vector2 mirroredHeading = new Vector2(-heading.X, heading.Y);

                Projectile.NewProjectile(source, mirroredPosition, mirroredHeading, type, damage * 2, knockback, player.whoAmI, 0f, cellingLimit);
            }

            return false;
        }
    }
}