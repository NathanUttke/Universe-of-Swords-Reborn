using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace UniverseOfSwordsMod.Tiles;

public class DamascusBarTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileFrameImportant[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
		TileObjectData.addTile(Type);
		ItemDrop = ModContent.ItemType<Items.Placeable.DamascusBar>();
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Damascus Bar");
		AddMapEntry(new Color(246, 249, 250), name);
		MinPick = 40;
	}
}
