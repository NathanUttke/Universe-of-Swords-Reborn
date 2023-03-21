using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class GreenDamascusChestplate : ModItem
{
	public override void SetStaticDefaults()
	{
		
		DisplayName.SetDefault("Green Damascus Chestplate");
		Tooltip.SetDefault("'Armor for fast warriors'\n15% increased melee damage\n10% increased melee speed");
	}

	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 20;
		Item.value = Item.sellPrice(0, 7, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.defense = 30;
		SacrificeTotal = 1;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (head.type == Mod.Find<ModItem>("GreenDamascusHelmet").Type)
		{
			return legs.type == Mod.Find<ModItem>("GreenDamascusLeggings").Type;
		}
		return false;
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = "25% increased melee speed, 7% increased melee critical chance, 50% increased movement speed, increases maximum life by 20";
		player.GetAttackSpeed(DamageClass.Melee) += 0.25f;
		player.GetCritChance(DamageClass.Generic) += 7;
		player.moveSpeed += 0.5f;
		player.statLifeMax2 += 20;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
		player.GetDamage(DamageClass.Melee) += 0.15f;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DamascusBar", 15);
		val.AddIngredient(Mod, "DamascusBreastplate", 1);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.SwiftnessPotion, 15);
		val.AddIngredient(ItemID.HallowedPlateMail, 1);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
