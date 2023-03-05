using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using UniverseOfSwordsMod.Items.Weapons;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items;

public class RevenantBag : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Revenant Bag");
		Tooltip.SetDefault("'Something terrible is hidden inside this bag'");
	}

	public override void SetDefaults()
	{
		Item.maxStack = 1;
		Item.consumable = true;
		Item.width = 24;
		Item.height = 24;
		Item.rare = ItemRarityID.Red;
		SacrificeTotal = 1;

	}

	public override bool CanRightClick()
	{
		return true;
	}

	public override void RightClick(Player player)
	{
		var entitySource = player.GetSource_OpenItem(Type);
		player.QuickSpawnItem(entitySource, ModContent.ItemType<Revenant>(), 1);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.CrimsonChest, 1);
		val.AddIngredient(ItemID.CorruptionChest, 1);
		val.AddIngredient(ItemID.HallowedChest, 1);
		val.AddIngredient(ItemID.FrozenChest, 1);
		val.AddIngredient(ItemID.JungleChest, 1);
		val.AddIngredient(ItemID.BoneKey, 1);
		val.AddIngredient(ItemID.Ectoplasm, 75);
		val.AddTile(TileID.BoneWelder);
		val.Register();
	}
}
