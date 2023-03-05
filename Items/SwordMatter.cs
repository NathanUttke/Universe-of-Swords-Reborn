using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items;

public class SwordMatter : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword Matter");
		Tooltip.SetDefault("'Matter of all swords'");
		Main.RegisterItemAnimation(Item.type, (DrawAnimation)new DrawAnimationVertical(5, 4));
		ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		ItemID.Sets.ItemIconPulse[Item.type] = true;
		ItemID.Sets.ItemNoGravity[Item.type] = false;
	}

	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 20;
		Item.maxStack = 9999;
		Item.value = 0;
		Item.rare = ItemRarityID.Orange;
		SacrificeTotal = 25;
	}
}
