using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class DranLeggings : ModItem
{
	public override void SetStaticDefaults()
	{	
		DisplayName.SetDefault("Overalls of the Demon Overlord");
		Tooltip.SetDefault("'These feet travel down the path of absolute carnage'" +
            "\nMaximum life increased by 1000" +
            "\n50% increased damage" +
            "\n100% increased movement speed" +
            "\nImmunity to knockback" +
            "\nGrants water walking" +
            "\nGrants immunity to most debuffs" +
            "\nImmunity to lava");
	}

	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 20;
		Item.value = Item.buyPrice(3, 0, 0, 0);
		Item.expert = true;
		Item.defense = 150;
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.LunarBar, 20);
		val.AddIngredient(Mod, "BlackOre", 50);
		val.AddIngredient(Mod, "HaloOfHorrors", 1);
		val.AddIngredient(Mod, "BlueDamascusLeggings", 1);
		val.AddIngredient(Mod, "GreenDamascusLeggings", 1);
		val.AddIngredient(Mod, "RedDamascusLeggings", 1);
		val.AddIngredient(ItemID.LavaWaders, 1);
		val.AddIngredient(ItemID.FrostsparkBoots, 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}

	public override void UpdateEquip(Player player)
	{
		player.statLifeMax2 += 1000;
		player.GetDamage(DamageClass.Melee) += 0.5f;
		player.GetDamage(DamageClass.Magic) += 0.5f;
		player.GetDamage(DamageClass.Throwing) += 0.5f;
		player.GetDamage(DamageClass.Summon) += 0.5f;
		player.GetDamage(DamageClass.Ranged) += 0.5f;
		player.moveSpeed += 1f;
		player.jumpBoost = true;
		player.noFallDmg = true;
		player.longInvince = true;
		player.noKnockback = true;
		player.buffImmune[24] = true;
		player.buffImmune[67] = true;
		player.lavaImmune = true;
		player.AddBuff(15, 2, true);
	}
}
