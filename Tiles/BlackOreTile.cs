using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Tiles;

public class BlackOreTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileLighted[Type] = true;
		Main.tileBlockLight[Type] = true;
		HitSound = SoundID.Tink;
		DustType = ModContent.DustType<Dusts.BlackOre>();
		ItemDrop = ModContent.ItemType<Items.Placeable.BlackOre>();
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Black Ore");
		AddMapEntry(new Color(0, 0, 0), name);
		MinPick = 200;
	}

	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		r = 0.22f;
		g = 0.32f;
		b = 0.22f;
	}
}
