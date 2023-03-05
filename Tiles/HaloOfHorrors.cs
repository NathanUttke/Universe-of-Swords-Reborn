using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace UniverseOfSwordsMod.Tiles;

public class HaloOfHorrors : ModTile
{
	public override void SetStaticDefaults()
	{
				Main.tileFrameImportant[((ModTile)this).Type] = true;
		Main.tileLavaDeath[((ModTile)this).Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.StyleWrapLimit = 36;
		TileObjectData.addTile((int)((ModTile)this).Type);
		base.DustType = 7;
		TileID.Sets.DisableSmartCursor[Type] = true;
		ModTranslation name = ((ModTile)this).CreateMapEntryName((string)null);
		name.SetDefault("Trophy");
		((ModTile)this).AddMapEntry(new Color(120, 85, 60), name);
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		int item = 0;
		if (frameX / 54 == 0)
		{
			item = ((ModTile)this).Mod.Find<ModItem>("HaloOfHorrors").Type;
		}
		if (item > 0)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 48, 48, item, 1);

		}
	}
}
