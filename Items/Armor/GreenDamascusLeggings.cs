using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class GreenDamascusLeggings : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.defense = 10;
	}

	public override void UpdateEquip(Player player)
	{
		player.moveSpeed += 0.1f;
		player.GetCritChance(DamageClass.Generic) += 10;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.ChlorophyteBar, 15)
		.AddIngredient(ModContent.ItemType<DamascusLeggings>(), 1)
		.AddIngredient(ItemID.SoulofMight, 15)
		.AddIngredient(ItemID.SoulofSight, 15)
		.AddIngredient(ItemID.SoulofFright, 15)
		.AddIngredient(ItemID.SwiftnessPotion, 15)
		.AddIngredient(ItemID.HallowedBar, 16)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
