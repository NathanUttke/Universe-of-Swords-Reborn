using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Accessories;

public class LegendaryWarriorGauntlet : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Legendary Warrior's Gauntlet");
		Tooltip.SetDefault("'Legendary gauntlet that grants wearer ultimate melee skills'\n15 defense\nHighly increased melee damage\n30% increased melee critical chance\nGreatly increased life regeneration\nIncreases maximum life by 20\n20% increased endurance\nGrants immunity to most debuffs\nGrants Spelunker, Thorns and Titan potion effects");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.rare = ItemRarityID.Red;
		Item.accessory = true; 
		SacrificeTotal = 1;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statDefense += 15;
		player.GetDamage(DamageClass.Melee) *= 1.15f;
		player.lifeRegen += 15;
		player.GetCritChance(DamageClass.Generic) += 25;
		player.statLifeMax2 += 20;
		player.endurance += 0.2f;
		player.AddBuff(9, 2, true);
		player.AddBuff(108, 2, true);
		player.AddBuff(14, 2, true);
		player.buffImmune[BuffID.WitheredWeapon] = true;
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

	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.WarriorEmblem, 1)
		.AddIngredient(ItemID.DestroyerEmblem, 1)
		.AddIngredient(ItemID.AvengerEmblem, 1)
		.AddIngredient(ItemID.FireGauntlet, 1)
		.AddIngredient(ItemID.PowerGlove, 1)
		.AddIngredient(ItemID.TitanGlove, 1)
		.AddIngredient(ItemID.MechanicalGlove, 1)
		.AddIngredient(ItemID.EyeoftheGolem, 1)
		.AddIngredient(ItemID.CelestialShell, 1)
		.AddIngredient(ItemID.AnkhShield, 1)
		.AddIngredient(ItemID.LifeFruit, 10)
		.AddIngredient(ItemID.LunarBar, 25)
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 18)
		.AddIngredient(Mod, "LunarOrb", 4)
		.AddTile(TileID.DemonAltar)
		.Register();
	}
}
