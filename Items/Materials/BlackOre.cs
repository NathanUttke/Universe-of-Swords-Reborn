using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Materials;

public class BlackOre : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Shadow Ore");
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 16;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.value = 100000;
		Item.rare = ItemRarityID.Red;
		Item.autoReuse = true;
		Item.consumable = true;
		Item.createTile = Mod.Find<ModTile>("BlackOreTile").Type;
		Item.maxStack = 9999;
		SacrificeTotal = 100;
	}
}
