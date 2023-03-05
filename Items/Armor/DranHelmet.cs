using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class DranHelmet : ModItem
{
	public override void SetStaticDefaults()
	{
		
		DisplayName.SetDefault("Maw of the Monster King");
		Tooltip.SetDefault("'These jaws know only hunger for the next soul'" +
            "\n50% increased critical chance" +
            "\nMaximum life increased by 1000" +
            "\n50% increased damage" +
            "\nReduces mana usage by 90%" +
            "\nReduces ammo usage by 20%" +
            "\nReduces throwing usage by 50%" +
            "\nIncreased mana regeneration" +
            "\nGrants Night Owl and Gills buffs");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 34;
		Item.value = Item.buyPrice(3, 0, 0, 0);
		Item.expert = true;
		Item.defense = 150;
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.LunarBar, 20);
		val.AddIngredient(ItemID.BossMaskBetsy, 1);
		val.AddIngredient(Mod, "BlackOre", 50);
		val.AddIngredient(Mod, "HaloOfHorrors", 1);
		val.AddIngredient(Mod, "SwordShard", 5);
		val.AddIngredient(Mod, "BlueDamascusHelmet", 1);
		val.AddIngredient(Mod, "GreenDamascusHelmet", 1);
		val.AddIngredient(Mod, "RedDamascusHelmet", 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}

	public override void UpdateEquip(Player player)
	{
		player.GetCritChance(DamageClass.Generic) += 50;
		player.GetCritChance(DamageClass.Magic) += 50;
		player.GetCritChance(DamageClass.Ranged) += 50;
		player.GetCritChance(DamageClass.Throwing) += 50;
		player.statLifeMax2 += 1000;
		player.GetDamage(DamageClass.Melee) += 0.5f;
		player.GetDamage(DamageClass.Magic) += 0.5f;
		player.GetDamage(DamageClass.Throwing) += 0.5f;
		player.GetDamage(DamageClass.Summon) += 0.5f;
		player.GetDamage(DamageClass.Ranged) += 0.5f;
		player.manaRegen += 30;
		player.AddBuff(12, 2, true);
		player.AddBuff(4, 2, true);
		player.manaCost -= 0.9f;
		player.ThrownCost50 = true;
		player.ammoCost80 = true;
	}
}
