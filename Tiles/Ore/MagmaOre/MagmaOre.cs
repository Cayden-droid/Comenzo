using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace SecretsOfMana.Tiles.Ore.MagmaOre
{
	public class MagmaOre : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileOreFinderPriority[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Magma Ore");
			AddMapEntry(new Color(152, 171, 198), name);

			// dustType = mod.ItemType("Sparkle");
			HitSound = SoundID.Tink;
			//mineResist = 3f;
			MinPick = 450;
		}
	}
}