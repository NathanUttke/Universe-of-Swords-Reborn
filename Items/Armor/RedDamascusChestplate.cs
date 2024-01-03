using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;
using Terraria.Localization;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class RedDamascusChestplate : ModItem
{
	public override void SetStaticDefaults()
	{
		
		// DisplayName.SetDefault("Red Damascus Chestplate");
		// Tooltip.SetDefault("'Armor for agressive warriors'\n10% increased melee damage\n10% increased melee critical chance");
	}

	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 20;
		Item.value = Item.sellPrice(0, 7, 0, 0);
		Item.rare = ItemRarityID.Orange;
		Item.defense = 20;
		Item.ResearchUnlockCount = 1;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (head.type == ModContent.ItemType<RedDamascusHelmet>())
		{
			return legs.type == ModContent.ItemType<DamascusLeggings>();
		}
		return false;
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = (string)Language.GetOrRegister("Mods.UniverseOfSwordsMod.RedDamascus.SetBonus");
		player.GetDamage(DamageClass.Melee) += 0.1f;
		player.AddBuff(108, 2, true);
		player.GetCritChance(DamageClass.Generic) += 10;
		player.statLifeMax2 += 20;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetDamage(DamageClass.Melee) += 0.1f;
		player.GetCritChance(DamageClass.Generic) += 10;
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ModContent.ItemType<ScarletFlareCore>(), 10);
		val.AddIngredient(Mod, "DamascusBreastplate", 1);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.WrathPotion, 15);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
