using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items;

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
		Item.useAnimation = 17;
		Item.useTime = 17;
		Item.maxStack = 30;
		Item.consumable = true;
		Item.width = 20;
		Item.height = 26;
		Item.value = Item.sellPrice(0, 0, 5, 0);
		Item.rare = ItemRarityID.Orange;
		Item.buffType = Mod.Find<ModBuff>("MeleePower").Type;
		Item.buffTime = 10000;
		SacrificeTotal = 20;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 10);
		val.AddTile(TileID.WorkBenches);
		val.Register();
	}
}
