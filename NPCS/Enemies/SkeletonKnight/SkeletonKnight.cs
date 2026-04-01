namespace Comenzo.NPCS.Enemies.SkeletonKnight
{
    public class SkeletonKnight : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Skeleton];

            NPCID.Sets.ShimmerTrasnformToNPC[Type] = NPCID.Skeleton;

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
            NPC.LifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPCDeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f; 
            NPC.aisytle = NPCAIStyleID.Fighter; // Assigns the style of ai that Npc has, or how the npc acts in game

            AIType = NPCID.Skeleton; // Borrows the Ai type from the skeleton
            AnimationType = NPCID.Skeleton; // Borrows the animation type from the skeleton
            Banner = Item.NPCtoBanner(NPCID.Skeleton); // Makes this Npc be affected by the normal skeleton banner
            BannerItem = Item.BannerToItem(Banner); // Makes the kills of this Npc go towards the banner its associtated with
            SpawnBiomes = [GameContent.GetInstance<CavernBiome>().Type]; // Tells the game which biome the Npc spawns in 
        }

        public override void ModfiyNPCLoot(NPCLoot npcloot)
        {
            npcloot.Add(ItemDropRule.Common(ItemID.BrokenSword, 10)); // 1 in 10 chance to drop the broken sword item
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
          return SpawnCondition.OverworldNightMonster.Chance * 0.2f; // Spawns with 1/5 the chance of a zombie  
        }

        public override void SetBestiary(BestiaryDatabase database, BesitaryEntry besitaryEntry)
        {
            // Used instead of calling Add mutliple times, adds multiple items at once
            besitaryEntry.Info.AddRange([
                // Sets the spawn conditions of this NPC that is listed in the bestiary
                BesitaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,

                // The decription of the Npc in the besitary
                new FlavorTextBesitaryInfoElement("Mods.Comenzo.Besitary.SkeletonKnight"),


                // This line is used to tell the game to prioritize a specific InfoElement as the source for the background image in the bestiary
                new BestiaryPortraitBackgroundProviderPreferenceInfoElement(GameCotent.GetInstance<CavernBiome>().CavernBiomeBesitaryInfoElement),
            ]);
        }
    }
}