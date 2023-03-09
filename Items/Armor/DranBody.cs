using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class DranBody : ModItem
{
	public override void SetStaticDefaults()
	{
		
		DisplayName.SetDefault("Epidermis of the Death Emperor");
		Tooltip.SetDefault("'These hands have taken so many lives...'" +
            "\nMaximum life increased by 1000" +
            "\n50% increased damage" +
            "\n100% increased melee damage" +
            "\nIncreased minion capacity by 8" +
            "\nIncreased sentries capacity by 6" +
            "\nArmor piercing increased to 300" +
            "\nGrants immunity to most debuffs" +
            "\nImmunity to lava");
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
		val.AddIngredient(ItemID.LunarBar, 30);
		val.AddIngredient(Mod, "LegendaryWarriorGauntlet", 2);
		val.AddIngredient(Mod, "BlackOre", 50);
		val.AddIngredient(Mod, "HaloOfHorrors", 1);
		val.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 2);
		val.AddIngredient(Mod, "BlueDamascusChestplate", 1);
		val.AddIngredient(Mod, "GreenDamascusChestplate", 1);
		val.AddIngredient(Mod, "RedDamascusChestplate", 1);
		val.AddIngredient(ItemID.ObsidianRose, 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}

	public override void UpdateEquip(Player player)
	{
		player.statLifeMax2 += 1000;
		player.GetDamage(DamageClass.Melee) += 1f;
		player.GetDamage(DamageClass.Magic) += 0.5f;
		player.GetDamage(DamageClass.Throwing) += 0.5f;
		player.GetDamage(DamageClass.Summon) += 0.5f;
		player.GetDamage(DamageClass.Ranged) += 0.5f;
		player.maxTurrets += 6;
		player.maxMinions += 8;
		player.GetArmorPenetration(DamageClass.Generic) += 300;
		player.lavaImmune = true;
		player.buffImmune[30] = true;
		player.buffImmune[36] = true;
		player.buffImmune[67] = true;
		player.buffImmune[22] = true;
		player.buffImmune[31] = true;
		player.buffImmune[23] = true;
		player.buffImmune[20] = true;
		player.buffImmune[35] = true;
		player.buffImmune[32] = true;
		player.buffImmune[33] = true;
		player.buffImmune[46] = true;
	}
}
