using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Tiles;

namespace UniverseOfSwordsMod.Items.Materials;

public class DamascusBar : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 24;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.value = 2000;
		Item.rare = ItemRarityID.Green;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
		Item.consumable = true;
		Item.createTile = ModContent.TileType<DamascusBarTile>();
		Item.maxStack = 9999;
		Item.ResearchUnlockCount = 25;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
        val.AddIngredient(ModContent.ItemType<DamascusOre>(), 4);
		val.AddTile(TileID.Furnaces);
		val.Register();
	}
}
