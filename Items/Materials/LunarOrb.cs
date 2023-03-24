using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items;

public class LunarOrb : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Essence of Lunar Towers");
	}

	public override void SetDefaults()
	{
		Item.width = 40;
		Item.height = 40;
		Item.maxStack = 999;
		Item.value = 700000;
		Item.rare = ItemRarityID.Cyan;
		SacrificeTotal = 25;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.FragmentSolar, 10);
		val.AddIngredient(ItemID.FragmentVortex, 10);
		val.AddIngredient(ItemID.FragmentNebula, 10);
		val.AddIngredient(ItemID.FragmentStardust, 10);
		val.AddIngredient(ItemID.SoulofLight, 15);
		val.AddIngredient(ItemID.SoulofNight, 15);
		val.AddIngredient(ItemID.SoulofFlight, 15);
		val.AddIngredient(ItemID.SoulofMight, 20);
		val.AddIngredient(ItemID.SoulofFright, 20);
		val.AddIngredient(ItemID.SoulofSight, 20);
		val.AddIngredient(Mod, "MartianSaucerCore", 1);
		val.AddIngredient(ItemID.CelestialSigil, 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}
}
