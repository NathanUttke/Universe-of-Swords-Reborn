using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class GreenDamascusHelmet : ModItem
{
	public override void SetStaticDefaults()
	{		
		DisplayName.SetDefault("Green Damascus Helmet");
		Tooltip.SetDefault("'Armor for fast warriors'\n20% increased melee speed\n14% increased melee critical chance");
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 7, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.defense = 20;
		SacrificeTotal = 1;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetAttackSpeed(DamageClass.Melee) += 0.2f;
		player.GetCritChance(DamageClass.Generic) += 14;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DamascusBar", 15);
		val.AddIngredient(Mod, "DamascusHelmet", 1);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.SwiftnessPotion, 15);
		val.AddIngredient(ItemID.HallowedMask, 1);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
