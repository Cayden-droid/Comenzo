using SecretsOfMana.Items.Weapons.Melee.BrokenSword;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace SecretsOfMana.NPCS.Enemies.SkeletonKnight
{
    public class SkeletonKnight : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Skeleton];

            NPCID.Sets.ShimmerTransformToNPC[Type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() { // Influences how the Npc looks inside the bestiary 
              Velocity = 1f // Draws the NPC walking +1 tiles in the x direction  
            };
        }

        public override void SetDefaults()
        {
            NPC.width = 18; // How wide the npc will apper in game
            NPC.height = 40; // How tall the npc appers in game
            NPC.damage = 25;
            NPC.defense = 7;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f; 
            NPC.aiStyle = NPCAIStyleID.Fighter; // Assigns the style of ai that Npc has, or how the npc acts in game

            AIType = NPCID.Skeleton; // Borrows the Ai type from the skeleton
            AnimationType = NPCID.Skeleton; // Borrows the animation type from the skeleton
            Banner = Item.NPCtoBanner(NPCID.Skeleton); // Makes this Npc be affected by the normal skeleton banner
            BannerItem = Item.BannerToItem(Banner); // Makes the kills of this Npc go towards the banner its associtated with
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenSword>(), 10)); // 1 in 10 chance to drop the broken sword item
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
          return SpawnCondition.OverworldNightMonster.Chance * 0.2f; // Spawns with 1/5 the chance of a zombie  
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // Used instead of calling Add mutliple times, adds multiple items at once
            bestiaryEntry.Info.AddRange([
                // Sets the spawn conditions of this NPC that is listed in the bestiary
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,

                // The decription of the Npc in the bestiary
                new FlavorTextBestiaryInfoElement("Mods.SecretsOfMana.Bestiary.SkeletonKnight"),


                // This line is used to tell the game to prioritize a specific InfoElement as the source for the background image in the bestiary
                // new BestiaryPortraitBackgroundProvidePreferenceInfoElement(GameContent.GetInstance<CavernBiome>().CavernBiomeBesitaryInfoElement),
            ]);
        }
    }
}