using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class BlueDamascusChestplate : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 20;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.rare = ItemRarityID.Cyan;
		Item.defense = 20;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (head.type == ModContent.ItemType<BlueDamascusHelmet>())
		{
			return legs.type == ModContent.ItemType<BlueDamascusLeggings>();
		}
		return false;
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = (string)Language.GetOrRegister("Mods.UniverseOfSwordsMod.BlueDamascus.SetBonus");
        player.endurance += 0.1f;
		player.GetCritChance(DamageClass.Generic) += 7;
		player.statLifeMax2 += 60;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetDamage(DamageClass.Melee) += 0.07f;
		player.moveSpeed += 0.1f;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ModContent.ItemType<DamascusBar>(), 15);
		val.AddIngredient(ModContent.ItemType<DamascusBreastplate>(), 1);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.IronskinPotion, 15);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
