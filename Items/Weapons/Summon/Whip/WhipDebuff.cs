
namespace Comenzo.Items.Weapons.Summon.Whip
{
    public class WhipDebuff : ModBuff
    {
        public static readonly int TagDamage = 5;

        public override void SetStaticDefaults()
        {
            // This allows the debuff to be applied to all NPCs, including NPCs immune to most or all other debuffs
            BuffID.Sets.IsATagBuff[type] = true;
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifers modifers)
        {
            // This line allows only player attackes to benefit from the debuff, by checking what the attack was. 
            if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
                return; 
        }
    }
}