using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items;

public class SwordOfPower : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Broken Sword Of Power");
		Tooltip.SetDefault("You need to fix this sword if you want to actually use it");
	}

	public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 62;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.damage = 1;
		Item.knockBack = 4f;
		Item.value = 0;
		Item.autoReuse = false;	
		SacrificeTotal = 1;
	}
}
