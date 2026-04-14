
namespace Comenzo.NPCS.Friendlies
{
    [AutoloadHead]
    public class Merchant : ModNPC
    {
        public const string ShopName = "Shop";
        public int NumberOfTimesTalkedTo = 0;

        private static int ShimmerHeadIndex;
        private static Profiles.StackedNPCProfile NPCProfile;

        public static LocalizedText UpgradedText { get; private set; }

        public override LocalizedText DeathMessage => this.GetLocalization("DeathMessage");

        public override void Load()
        {
            ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 25;

            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 700;
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 90;
            NPCID.Sets.AttackAverageChance[Type] = 30;
            NPCID.Sets.HatOffsetY[Type] = 4;
            NPCID.Sets.ShimmerTownTransform[Type] = true;

            NPCID.Sets.FaceEmote[Type] = ModContent.EmoteBubbleType<MerchantEmote>();

            NPCID.Sets.NPCBesitaryDrawModifiers  drawModifiers = new NPCID.Sets.NPCBesitaryDrawModifiers()
            {
              Veloctiy = 1f,
              Direction = -1
            };

            NPCID.Sets.NPCBesitaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Love)
                .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Like)
                .SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Hate)
            ;

            NPCProfile = Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party"),
                new Profiles.DefaultNPCProfile(Texture, + "_Shimmer", ShimmerHeadIndex, Texture + "_Shimmer_Party")
            );

            ContentSamples.NpcBestiaryRarityStars[Type] = 3;

            UpgradedText = this.GetLocalization("Upgraded");
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = NPCAIStyleID.Passive; 
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;
        }

        public override void SetBestiary(BestiaryDataBase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange9([
               BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,  
            ]);
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Sparkle>());
            }

            if (Main.netMode != NetModeID.Server && NPC.life <= 0)
            {
                string variant = "";
                if (NPC.IsShimmerVariant)
                    variant += "_Shimmer";
            }
        }
    }
}