using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;
using Terraria.Localization;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class GreenDamascusChestplate : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 20;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.defense = 18;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (head.type == ModContent.ItemType<GreenDamascusHelmet>())
		{
			return legs.type == ModContent.ItemType<GreenDamascusLeggings>();
		}
		return false;
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = (string)Language.GetOrRegister("Mods.UniverseOfSwordsMod.GreenDamascus.SetBonus");
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
		val.AddIngredient(ItemID.ChlorophyteBar, 15);
		val.AddIngredient(ModContent.ItemType<DamascusBreastplate>(), 1);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.SwiftnessPotion, 15);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
