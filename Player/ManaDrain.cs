using Terraria;
using Terraria.ModLoader;

namespace SecretsOfMana
{
    public class ManaDrain : ModPlayer
    {
        public bool hasManaDrainDebuff = false;

        public override void ResetEffects()
        {
            hasManaDrainDebuff = false;
        }

        public override void UpdateBadEffects()
        {
            if (hasManaDrainDebuff)
            {
                // This stops normal mana regen. 
                Player.manaRegenDelay = 60;
                Player.manaRegen = 0;
            }
            
            // Every ten ticks, and when the player's mana is greater than zero, reducess the players mana. 
            if (Main.GameUpdateCount % 10 == 0 && Player.statMana > 0)
            {
                Player.statMana -= 1;

                // Prevents the player from reaching negative mana
                if (Player.statMana < 0)
                {
                    Player.statMana = 0;
                }
            }
        }
    }
}