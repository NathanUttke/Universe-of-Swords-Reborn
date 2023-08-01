using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Consumables;

public class NordMead : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Nord Mead");
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
		Item.width = 20;
		Item.height = 36;
		Item.value = Item.sellPrice(0, 0, 20, 0);
		Item.rare = ItemRarityID.Orange;
		Item.buffType = Mod.Find<ModBuff>("NordMead").Type;
		Item.buffTime = 14000;
		Item.ResearchUnlockCount = 20;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.Seed, 10);
		val.AddIngredient(ItemID.BottledHoney, 1);
		val.AddTile(TileID.Kegs);
		val.Register();
	}
}
