using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class DamascusBreastplate : ModItem
{
	public override void SetStaticDefaults()
	{
		
		DisplayName.SetDefault("Damascus Breastplate");
		Tooltip.SetDefault("4% increased melee damage");
	}

	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 20;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.defense = 6;
		SacrificeTotal = 1;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (head.type == ModContent.ItemType<DamascusHelmet>())
		{
			return legs.type == ModContent.ItemType<DamascusLeggings>();
		}
		return false;
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = "4 extra defense, 4% increased melee damage, 3% increased melee speed, 4% increased melee critical chance";
		player.GetDamage(DamageClass.Melee) += 0.04f;
		player.statDefense += 4;
		player.GetAttackSpeed(DamageClass.Melee) += 0.03f;
		player.GetCritChance(DamageClass.Generic) += 4;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetDamage(DamageClass.Melee) += 0.04f;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DamascusBar", 20);
		val.AddIngredient(Mod, "SwordMatter", 60);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
