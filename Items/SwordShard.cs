using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items;

public class SwordShard : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shard of lost sword");
	}

	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 20;
		Item.maxStack = 999;
		Item.value = 0;
		Item.rare = ItemRarityID.LightRed;
		SacrificeTotal = 25;
	}

	public override void AddRecipes()
	{
		
								Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 400);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
