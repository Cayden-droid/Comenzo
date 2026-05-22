using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace SecretsOfMana.Buffs
{
    public class WhipDebuff : ModBuff
    {
        public static readonly int TagDamage = 5;

        public override void SetStaticDefaults()
        {
            // This allows the debuff to be applied to all NPCs, including NPCs immune to most or all other debuffs
            BuffID.Sets.IsATagBuff[Type] = true;
        }
    }

    public class WhipDebuffNPC : GlobalNPC
    {
         public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            // This line allows only player attackes to benefit from the debuff, by checking what the attack was. 
            if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated) 
                return;

            var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
			if (npc.HasBuff<WhipDebuff>()) {
				// Apply a flat bonus to every hit
				modifiers.FlatBonusDamage += WhipDebuff.TagDamage * projTagMultiplier; 
            }
        }
    }
}