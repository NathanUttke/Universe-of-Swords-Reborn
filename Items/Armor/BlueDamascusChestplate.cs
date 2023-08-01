using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class BlueDamascusChestplate : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Blue Damascus Chestplate");
		// Tooltip.SetDefault("'Armor for durable warriors'\n7% increased melee damage\n10% increased movement speed");
	}

	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 20;
		Item.value = Item.sellPrice(0, 7, 0, 0);
		Item.rare = ItemRarityID.Cyan;
		Item.defense = 20;
		Item.ResearchUnlockCount = 1;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (head.type == Mod.Find<ModItem>("BlueDamascusHelmet").Type)
		{
			return legs.type == Mod.Find<ModItem>("BlueDamascusLeggings").Type;
		}
		return false;
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = "10% endurance, 7% increased melee critical chance, increases maximum life by 60";
		player.endurance += 0.1f;
		player.GetCritChance(DamageClass.Generic) += 7;
		player.statLifeMax2 += 60;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetDamage(DamageClass.Melee) += 0.07f;
		player.moveSpeed += 0.1f;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DamascusBar", 15);
		val.AddIngredient(Mod, "DamascusBreastplate", 1);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.IronskinPotion, 15);
		val.AddIngredient(ItemID.HallowedPlateMail, 1);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
