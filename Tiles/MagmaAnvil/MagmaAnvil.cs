using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace SecretsOfMana.Tiles.MagmaAnvil
{
	public class MagmaAnvil : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.CoordinateHeights = new[] { 18 };
			TileObjectData.addTile(Type);
			// AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Magma Anvil");
			AddMapEntry(new Color(200, 200, 200), name);
			// dustType = DustType<Sparkle>();
			AdjTiles = new int[] { TileID.Anvils };
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}