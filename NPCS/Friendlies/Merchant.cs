
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
            // This adds a different look for the NPCs head when the npc is shimmered
            ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
        }

        public override void SetStaticDefaults()
        {
            // Total amount of frames that the NPC has to make an action 
            Main.npcFrameCount[Type] = 25;

            NPCID.Sets.ExtraFramesCount[Type] = 9; // Frame count for things like talking to other NPCs or sitting in a chair
            NPCID.Sets.AttackFrameCount[Type] = 4; // Frame count for an attack
            NPCID.Sets.DangerDetectRange[Type] = 700; // How far away an enemy can be detected in pixels 
            NPCID.Sets.AttackType[Type] = 0; // Type of attack the NPC performs 
            NPCID.Sets.AttackTime[Type] = 90; // Amount of time in ticks for the NPC's attack animation to end from the start
            NPCID.Sets.AttackAverageChance[Type] = 30; // Denominator for the chance for the NPC to attack, (1/30)
            NPCID.Sets.HatOffsetY[Type] = 4; // Spawns the party hat at a offset
            NPCID.Sets.ShimmerTownTransform[Type] = true; // Defines if the NPC has a shimmer form

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
                if (NPC.altTexture == 1) 
                    variant += "_Party";
                int hatGore = NPCP.GetPartyHatGore();
                int headGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Head").Type;
                int armGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Arm").Type;
                int legGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Leg").Type;

                if (hatGore > 0)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, hatGore);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, headGore, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.veloctiy, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.veloctiy, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
            }
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (source is EntitySource_SpawnNPC)
            {
                TownNPCRespawnSystem.unlockedExamplePersonSpawn = true;
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (TownNPCRespawnSystem.unlockedExamplePersonSpawn)
            {
                return true; 
            }

            foreach (var player in Main.ActivePlayers)
            {
                if (player.inventory.Any(item => item.type == ModContent.ItemType<>() || item.type == ModCotent.ItemType<Items.Placeable>()))
                {
                    return true;
                }
            }

            return false;
        }

        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Merchant",
                ""
            };
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.NextBool(4))
            {
                chat.Add(Language.GetTextValue("Mods.Comenzo.Dialouge.Merchant.PartyGirlDialogue", Main.npc[partyGirl].GivenName));
            }

            chat.Add(Language.GetTextValue("Mods.Comenzo.Dialogue.Merchant.StandardDialogue1"));
            chat.Add(Language.GetTextValue("Mods.Comenzo.Dialogue.Merchant.StandardDialogue2"));
            chat.Add(Language.GetTextValue("Mods.Comenzo.Dialogue.Merchant.StandardDialogue3"));
            chat.Add(Language.GetTextValue("Mods.Comenzo.Dialogue.Merchant.StandardDialogue4"));
            chat.Add(Language.GetTextValue("Mods.Comenzo.Dialogue.Merchant.CommonDialogue"), 5.0);
            chat.Add(Language.GetTextValue("Mods.Comenzo.Dialogue.Merchant.RareDialogue"), 0.1);

            NumberOfTimesTalkedTo++; 
            if (NumberOfTimesTalkedTo >= 10)
            {
                chat.Add(Language.GetTextValue("Mods.Comenzo.Dialogue.Merchant.TalkALot"));
            }

            string chosenChat = chat; 

            if (chosenChat == Language.GetTextValue("Mods.Comenzo.Dialogue.Merchant.StandardDialogue4"))
            {
                Main.npcChatCornerItem = ItemID.HiveBackpack;
            }

            return chosenChat; 
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Awesomeifty";
            if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
            {
                button = "Upgrade" + Lang.GetItemNameValue(ItemID.HiveBackpack);
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
                {
                    SoundEngine.PlaySound(SoundID.Item37);

                    Main.npcChatText = UpgradedText.Value;

                    int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.HiveBackpack);
                    var entitySource = NPC.GetSource_GiftOrReward();

                    Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir(); 
                    Main.LocalPlayer.QuickSpawnItem(entitySource, ModContent.ItemType<WaspNest>());

                    return;
                }

                shop = ShopName;
            }
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName);

            npcShop.Register();
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            foreach (Item item in items)
            {
                if (item == null || item.type == ItemID.None)
                {
                    continue; 
                }

                if (NPC.IsShimmerVariant)
                {
                    int value = item.shopCustomPrice ?? item.value;
                    item.shopCustomPrice = value / 2;
                }
            }
        }

        public override void ModifyNPCLoot()
        {
            npcLoot.Add(ItemDropRule.Common(ModCotent.ItemType<MagmaAnvil>()));
        }

        public override bool CanGoToStatue(bool toKingStatue) => true;

        public override void OnGoToStatue(bool toKingStatue)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)Comenzo.MessageType.TeleportToStatue);
                packet.Write((byte)NPC.whoAmI);
                packet.Send();
            }

            else
            {
                StatueTeleport();
            }
        }

        public void StatueTeleport()
        {
            for (int i = 0; i < 30; i++) {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y))
                {
                    position.X = Math.Sign(position.X) * 20;
                }

                else
                {
                    postion.Y = Math.Sign(position.Y) * 20;
                }

                Dust.NewDustPerfect(NPC.Center + position, ModContent.DustType<Sparkle>(), Vector2.Zero).noGravity = true;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<SparklingBall>();
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffSet)
        {
            multiplier = 12f; 
            randomOffSet = 2f; 
        }

        public override void LoadData(TagCompound tag)
        {
            NumberOfTimesTalkedTo = tag.GetInt("numberOfTimesTalkedTo");
        }

        public override void SaveData()
        {
            tag["numberOfTimesTalkedTo"] = NumberOfTimesTalkedTo;
        }
    }
}