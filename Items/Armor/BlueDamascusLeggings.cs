using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class BlueDamascusLeggings : ModItem
{
	public override void SetStaticDefaults()
	{
		
		DisplayName.SetDefault("Blue Damascus Leggings");
		Tooltip.SetDefault("'Armor for durable warriors'\n6% increased melee critical chance\n5% increased movement speed");
	}

	public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 18;
		Item.value = Item.buyPrice(0, 7, 0, 0);
		Item.rare = ItemRarityID.Cyan;
		Item.defense = 20;
		SacrificeTotal = 1;
	}

	public override void UpdateEquip(Player player)
	{
		player.moveSpeed += 0.05f;
		player.GetCritChance(DamageClass.Generic) += 6;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DamascusBar", 15);
		val.AddIngredient(Mod, "DamascusLeggings", 1);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.IronskinPotion, 15);
		val.AddIngredient(ItemID.HallowedGreaves, 1);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
