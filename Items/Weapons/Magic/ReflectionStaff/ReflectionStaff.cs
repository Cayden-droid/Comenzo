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
        private const int MirrorCount = 6;

        // Projectile indices (into Main.projectile) of the mirrors this staff spawned, -1 when empty
        private readonly int[] mirrorIndices = new int[MirrorCount] {-1, -1, -1, -1, -1, -1};

        public override void HoldItem(Player player)
        {
            // Only the owning client spawns projectiles; they are synced to everyone else
            if (player.whoAmI != Main.myPlayer)
                return;

            int mirrorType = ModContent.ProjectileType<ReflectionStaffMirror>();

            // Spawn a mirror at a random spot around the player for every slot that has none
            for (int i = 0; i < mirrorIndices.Length; i++)
            {
                if (MirrorExists(mirrorIndices[i], mirrorType, player))
                    continue;

                float randomX = Main.rand.NextFloat(-301f, 301f);
                float randomY = Main.rand.NextFloat(-201f, 201f);
                Vector2 spawnPosition = player.Center + new Vector2(randomX, randomY);

                mirrorIndices[i] = Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, mirrorType, 0, 0f, player.whoAmI);
            }
        }

        private static bool MirrorExists(int index, int mirrorType, Player player)
        {
            return index >= 0
                && Main.projectile[index].active
                && Main.projectile[index].type == mirrorType
                && Main.projectile[index].owner == player.whoAmI;
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
            Item.shootSpeed = 10f;
            Item.noMelee = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int mirrorType = ModContent.ProjectileType<ReflectionStaffMirror>();
            bool firedAtMirror = false;

            // Fire one projectile at each living mirror
            for (int i = 0; i < mirrorIndices.Length; i++)
            {
                int mirrorID = mirrorIndices[i];
                if (!MirrorExists(mirrorID, mirrorType, player))
                    continue;

                Vector2 heading = (Main.projectile[mirrorID].Center - player.Center).SafeNormalize(Vector2.UnitX);
                heading *= velocity.Length();
                Projectile.NewProjectile(source, player.Center, heading, type, damage, knockback, player.whoAmI);
                firedAtMirror = true;
            }

            // With no mirrors out, fire normally toward the cursor
            return !firedAtMirror;
        }
    }
}
