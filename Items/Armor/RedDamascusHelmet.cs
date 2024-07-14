using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class RedDamascusHelmet : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 7, 0, 0);
		Item.rare = ItemRarityID.Orange;
		Item.defense = 20;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetDamage(DamageClass.Melee) += 0.1f;
		player.GetCritChance(DamageClass.Generic) += 14;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ModContent.ItemType<ScarletFlareCore>(), 5);
		val.AddIngredient(ModContent.ItemType<DamascusHelmet>(), 1);
		val.AddIngredient(ItemID.WrathPotion, 15);
		val.AddIngredient(ItemID.HallowedBar, 16);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
