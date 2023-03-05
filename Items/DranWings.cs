using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace UniverseOfSwordsMod.Items;

[AutoloadEquip(EquipType.Wings)]
public class DranWings : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("10 seconds fly time" +
			"\nUltimate acceleration" +
			"\nGreat speed" +
			"\nAllows ability to dash" +
            "\n20% increased movement speed" +
            "\nIncreases maximum life by 250" +
            "\n20% increased damage" +
            "\nGrants gravitation effect");

		// These wings use the same values as the solar wings
		// Fly time: 550 ticks = 9.17 seconds
		// Fly speed: 15f
		// Acceleration multiplier: 10f
		ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(550, 15f, 10f);
	}

	public override void SetDefaults()
	{
		Item.width = 78;
		Item.height = 54;
		Item.value = Item.sellPrice(1, 0, 0, 0);
		Item.rare = ItemRarityID.Red;
		Item.accessory = true; 
		Item.defense = 50;
		SacrificeTotal = 1;

	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.wingTimeMax = 550;
		player.dashType= 1;
		player.statLifeMax2 += 250;
		player.moveSpeed += 0.2f;
		player.GetDamage(DamageClass.Melee) += 0.2f;
		player.GetDamage(DamageClass.Magic) += 0.2f;
		player.GetDamage(DamageClass.Throwing) += 0.2f;
		player.GetDamage(DamageClass.Summon) += 0.2f;
		player.GetDamage(DamageClass.Ranged) += 0.2f;
		player.AddBuff(18, 2, true);
	}

	public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
	{
		ascentWhenFalling = 0.3f;
		ascentWhenRising = 0.15f;
		maxCanAscendMultiplier = 1f;
		maxAscentMultiplier = 3f;
		constantAscend = 0.135f;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.DD2PetDragon, 1);
		val.AddIngredient(ItemID.SoulofFlight, 40);
		val.AddIngredient(Mod, "BlackOre", 15);
		val.AddIngredient(Mod, "LunarOrb", 6);
		val.AddIngredient(Mod, "HaloOfHorrors", 1);
		val.AddIngredient(ItemID.WingsVortex, 1);
		val.AddIngredient(ItemID.WingsNebula, 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}
}
