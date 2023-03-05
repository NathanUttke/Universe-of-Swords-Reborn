using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items;

public class ScarletFlareCore : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Scarlet Flare Core");
		Tooltip.SetDefault("'Core from depths of hell'");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 50;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.Red;
		SacrificeTotal = 25;
	}
}
