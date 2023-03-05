using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Tiles;

public class DamascusOreTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileLighted[Type] = true;
		Main.tileBlockLight[Type] = true;
		HitSound = SoundID.Tink;
		DustType = ModContent.DustType<Dusts.DamascusSparkle>();
		ItemDrop = ModContent.ItemType<Items.Placeable.DamascusOre>();		
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Damascus Ore");
		AddMapEntry(new Color(246, 249, 250), name);
	     MinPick = 40;
	}

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
