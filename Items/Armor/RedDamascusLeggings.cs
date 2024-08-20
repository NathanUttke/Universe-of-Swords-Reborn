using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class RedDamascusLeggings : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 7, 0, 0);
		Item.rare = ItemRarityID.Orange;
		Item.defense = 10;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetCritChance(DamageClass.Generic) += 10;
		player.GetDamage(DamageClass.Melee) += 0.1f;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<ScarletFlareCore>(), 5)
		.AddIngredient(ModContent.ItemType<DamascusLeggings>(), 1)
		.AddIngredient(ItemID.SoulofMight, 15)
		.AddIngredient(ItemID.SoulofSight, 15)
		.AddIngredient(ItemID.SoulofFright, 15)
		.AddIngredient(ItemID.WrathPotion, 15)
		.AddIngredient(ItemID.HallowedBar, 16)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
