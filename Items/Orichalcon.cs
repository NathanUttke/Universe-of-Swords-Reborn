using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items;

public class Orichalcon : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Orihalcon");
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
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.HallowedBar, 1);
		val.AddIngredient(ItemID.SoulofLight, 1);
		val.AddIngredient(ItemID.SoulofNight, 1);
		val.AddIngredient(ItemID.PixieDust, 10);
		val.AddIngredient(Mod, "SwordMatter", 80);
		val.AddIngredient(ItemID.FrostCore, 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
