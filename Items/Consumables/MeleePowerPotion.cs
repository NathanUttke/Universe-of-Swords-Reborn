using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Consumables;

public class MeleePowerPotion : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Increases melee stats by small amount");
	}

	public override void SetDefaults()
	{
		Item.UseSound = SoundID.Item3;
		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useTurn = true;
		Item.useAnimation = 18;
		Item.useTime = 18;
		Item.maxStack = 30;
		Item.consumable = true;
		Item.width = 20;
		Item.height = 26;
		Item.value = Item.sellPrice(0, 0, 4, 0);
		Item.rare = ItemRarityID.Orange;
		Item.buffType = Mod.Find<ModBuff>("MeleePower").Type;
		Item.buffTime = 8000;
		SacrificeTotal = 30;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(Mod, "SwordMatter", 25)
			.AddIngredient(ItemID.Deathweed, 1)
			.AddTile(TileID.Bottles)
			.Register();
        CreateRecipe()
			.AddIngredient(Mod, "SwordMatter", 25)
			.AddIngredient(ItemID.Deathweed, 1)
			.AddTile(TileID.AlchemyTable)
			.Register();
    }
}
