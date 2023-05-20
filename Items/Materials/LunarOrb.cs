using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Materials;

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
		SacrificeTotal = 10;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.FragmentSolar, 10)
			.AddIngredient(ItemID.FragmentVortex, 10)
			.AddIngredient(ItemID.FragmentNebula, 10)
			.AddIngredient(ItemID.FragmentStardust, 10)
			.AddIngredient(ItemID.SoulofLight, 15)
			.AddIngredient(ItemID.SoulofNight, 15)
			.AddIngredient(ItemID.SoulofFlight, 15)
			.AddIngredient(ItemID.SoulofMight, 15)
			.AddIngredient(ItemID.SoulofFright, 15)
			.AddIngredient(ItemID.SoulofSight, 15)
			.AddIngredient(ModContent.ItemType<MartianSaucerCore>(), 1)
			.AddIngredient(ItemID.CelestialSigil, 1)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}
