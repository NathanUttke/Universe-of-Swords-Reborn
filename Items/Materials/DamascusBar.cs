using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Materials;

public class DamascusBar : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Damascus Bar");
		// Tooltip.SetDefault("'Material for creating powerful swords'");
	}

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
		Item.createTile = Mod.Find<ModTile>("DamascusBarTile").Type;
		Item.maxStack = 9999;
		Item.ResearchUnlockCount = 25;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
        val.AddIngredient(Mod, "DamascusOre", 4);
		val.AddTile(TileID.Furnaces);
		val.Register();
	}
}
