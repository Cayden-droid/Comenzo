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
        private int tickCounter = 0;

        public override void UpdateInventory(Player player)
        {
            tickCounter++;
        }
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
            Item.shoot = ModContent.ProjectileType<DualSlashSwordProjectile>();
            Item.noMelee = true;
            Item.shootsEveryUse = true;
            Item.autoReuse = true;   
        }

        // When read, tells the server that this weapon has a alternative function. In this case reading a right click input
        public override bool AltFunction(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2) // this defines what happens when a right click is inputed
            {
                Item.useTime = 120; 
                Item.useAnimation = 120;
                Item.damage = 2500;
                Item.width = 40;
                Item.height = 80;
                Item.shoot = ModContent.ProjectileType<DualSlashSwordProjectileAlt>();

            }

            else
            {
                Item.useTime = 20;
                Item.useAnimation = 20;
                Item.damage = 375;
                Item.shoot = ModContent.ProjectileType<DualSlashSwordProjectile>();
            }

            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velcoity, int type, int damage, float knockback)
        {

            if (player.altFunctionUse == 2)
            {
                tickCounter = 0;

                Vector2 position = new Vector2(player.Center.X, player.Center.Y);

                Vector2 heading = (target - position).SafeNormalize(Vector2.UnitX); // the variable heading helps find figure out the distance to target, and calculate the velocity
                heading *= velcoity.Length(); // Calculates the final velocity based of the distance to target

                player.GetModPlayer<ManaDrain>().hasManaDrainDebuff = true; // Applies the mana drain debuff
                ManaDrain.UpdateBadEffects();

                Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f);

                return false; // Stops the right click function from beign exectued
            }
        
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float cellingLimit = target.Y;
            if (cellingLimit > player.Center.Y - 200f)
            {
                cellingLimit = player.Center.Y - 200f;
            }

            for (int i = 1; i < 4; i++)
            {

                position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                position.Y -= 100 * i;
                Vector2 spawnPosition = player.Center - new Vector2(position, position.Y);
                Vector2 heading = target - spawnPosition;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Y += Main.rand.Next(-40, 41) * 0.02f;

                Projectile.NewProjectile(source, position, heading, type, damage * (i / 4), knockback, player.whoAmI, 0f, cellingLimit);

                // This section of code is for mirroring the x positon of the projectile
                // Flips position relative to player.Center
                Vector2 mirroredPosition = player.Center + new Vector2(position - (2 *(player.Center.X - spawnPosition.X)), -position.y);
                // Heading x and y dictate the direction the projectile travels. -heading.x makes it travel in the oppostie direction of the other projectile.
                Vector2 mirroredHeading = new Vector2(-heading.X, heading.Y);

                Projectile.NewProjectile(source, mirroredPosition, mirroredHeading, type, damage * (i / 4), knockback, player.whoAmI, 0f, cellingLimit);
            }

            return false;
        }
    }
}