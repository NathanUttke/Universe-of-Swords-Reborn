using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items;

public class Skooma : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Skooma");
		Tooltip.SetDefault("Increases movement speed and jump height");
	}

	public override void SetDefaults()
	{
		Item.UseSound = SoundID.Item3;
		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useTurn = true;
		Item.useAnimation = 17;
		Item.useTime = 17;
		Item.maxStack = 30;
		Item.consumable = true;
		Item.width = 22;
		Item.height = 40;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.rare = ItemRarityID.Purple;
		Item.buffType = Mod.Find<ModBuff>("Skooma").Type;
		Item.buffTime = 8000;
		SacrificeTotal = 20;

	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.PurpleMucos, 1);
		val.AddIngredient(ItemID.CandyCorn, 10);
		val.AddIngredient(ItemID.Moonglow, 1);
		val.AddTile(TileID.AlchemyTable);
		val.Register();
	}
}
