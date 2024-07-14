using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class GreenDamascusHelmet : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 28;
		Item.height = 20;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.defense = 20;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetAttackSpeed(DamageClass.Melee) += 0.05f;		
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.ChlorophyteBar, 15);
		val.AddIngredient(ModContent.ItemType<DamascusHelmet>(), 1);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.SwiftnessPotion, 15);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
