using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SecretsOfMana.Items.Weapons.Summon.KillerRabbitFeed
{
    // Not loaded until it has a sprite (KillerRabbitFeed.png) and a working minion
    [Autoload(false)]
    public class KillerRabbitFeed : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Type] = true;

            ItemID.Sets.StaffMinionSlotsRequired[Type] = 1f;
        }

        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.knockBack = 1f;
            Item.mana = 10;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(gold: 30);
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item44;

            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            // Item.buffType = ModContent.BuffType<>();

            Item.shoot = ModContent.ProjectileType<BUNY>();
        }
    }
}