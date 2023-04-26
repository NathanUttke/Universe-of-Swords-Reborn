using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Placeable;

namespace UniverseOfSwordsMod.Items;

public class Orichalcon : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Scintillo Bar");
		Tooltip.SetDefault("Most powerful and rarest ore for making swords");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.maxStack = 999;
		Item.value = 180000;
		Item.rare = ItemRarityID.LightPurple;
		SacrificeTotal = 25;
	}

	public override void AddRecipes()
	{
		CreateRecipe(5)
		.AddIngredient(ItemID.HallowedBar, 5)
		.AddIngredient(ItemID.SoulofLight, 25)
		.AddIngredient(ItemID.SoulofNight, 25)
		.AddIngredient(ItemID.PixieDust, 10)
		.AddIngredient(ModContent.ItemType<DamascusBar>(), 5)
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 1)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
