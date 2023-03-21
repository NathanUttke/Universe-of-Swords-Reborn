using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class RedDamascusLeggings : ModItem
{
	public override void SetStaticDefaults()
	{
		
		DisplayName.SetDefault("Red Damascus Leggings");
		Tooltip.SetDefault("'Armor for agressive warriors'\n10% increased melee critical chance\n10% increased melee damage");
	}

	public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 7, 0, 0);
		Item.rare = ItemRarityID.Orange;
		Item.defense = 10;
		SacrificeTotal = 1;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetCritChance(DamageClass.Generic) += 10;
		player.GetDamage(DamageClass.Melee) += 0.1f;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DamascusBar", 15);
		val.AddIngredient(Mod, "DamascusLeggings", 1);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.WrathPotion, 15);
		val.AddIngredient(ItemID.HallowedGreaves, 1);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
