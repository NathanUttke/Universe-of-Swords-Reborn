using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items;

public class MartianSaucerCore : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Pulses with space energy");
	}

	public override void SetDefaults()
	{
		Item.width = 38;
		Item.height = 40;
		Item.maxStack = 999;
		Item.value = 400000;
		Item.rare = ItemRarityID.Yellow;
		SacrificeTotal = 25;
	}
}
