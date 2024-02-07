using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Tiles;

public class DamascusOreTile : ModTile
{
	public override void SetStaticDefaults()
	{
		TileID.Sets.Ore[Type] = true;
		Main.tileSolid[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileLighted[Type] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileSpelunker[Type] = true;
		Main.tileShine2[Type] = true;
		Main.tileShine[Type] = 975;
		
		HitSound = SoundID.Tink;
		DustType = ModContent.DustType<DamascusSparkle>();		
		
		LocalizedText name = CreateMapEntryName();
		
		AddMapEntry(new Color(246, 249, 250), name);
	    MinPick = 65;
	}

	public override bool CanExplode(int i, int j) => false;


    public override void NumDust(int i, int j, bool fail, ref int num)
	{
		num = (fail ? 2 : 4);
	}

	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		r = 0.46f;
		g = 0.49f;
		b = 0.5f;
	}
}
