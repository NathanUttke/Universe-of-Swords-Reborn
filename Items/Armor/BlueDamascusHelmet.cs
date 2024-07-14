using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class BlueDamascusHelmet : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.rare = ItemRarityID.Cyan;
		Item.defense = 30;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetAttackSpeed(DamageClass.Melee) += 0.06f;
		player.GetCritChance(DamageClass.Generic) += 6;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
        val.AddIngredient(ModContent.ItemType<DamascusBar>(), 15);
        val.AddIngredient(ModContent.ItemType<DamascusHelmet>(), 1);
        val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.IronskinPotion, 15);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
