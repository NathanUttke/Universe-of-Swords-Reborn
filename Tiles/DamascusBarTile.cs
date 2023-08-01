using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Tiles;

public class DamascusBarTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileFrameImportant[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
		TileObjectData.addTile(Type);
		//ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = ModContent.ItemType<DamascusBar>();
		LocalizedText name = CreateMapEntryName();
		// name.SetDefault("Damascus Bar");
		AddMapEntry(new Color(246, 249, 250), name);
		MinPick = 40;
	}
}
