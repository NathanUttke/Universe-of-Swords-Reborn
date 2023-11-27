using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Accessories;

public class LegendaryWarriorGauntlet : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Legendary Warrior's Gauntlet");
		/* Tooltip.SetDefault("'Legendary gauntlet that grants wearer ultimate melee skills'\n" +
			"15 defense\n" +
			"Highly increased melee damage\n" +
			"30% increased melee critical chance\n" +
			"Greatly increased life regeneration\n" +
			"Increases maximum life by 20\n20% increased endurance\n" +
			"Grants immunity to most debuffs\n" +
			"Grants Spelunker, Thorns and Titan potion effects"); */
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.rare = ItemRarityID.Red;
		Item.accessory = true; 
		Item.ResearchUnlockCount = 1;
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
		player.buffImmune[BuffID.BrokenArmor] = true;
		player.buffImmune[BuffID.Burning] = true;
		player.buffImmune[BuffID.Darkness] = true;
		player.buffImmune[BuffID.Confused] = true;
		player.buffImmune[BuffID.Cursed] = true;
		player.buffImmune[BuffID.Poisoned] = true;
		player.buffImmune[BuffID.Silenced] = true;
		player.buffImmune[BuffID.Slow] = true;
		player.buffImmune[BuffID.Weak] = true;
		player.buffImmune[BuffID.Chilled] = true;
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
		.AddIngredient(ModContent.ItemType<LunarOrb>(), 4)
		.AddTile(TileID.DemonAltar)
		.Register();
	}
}
