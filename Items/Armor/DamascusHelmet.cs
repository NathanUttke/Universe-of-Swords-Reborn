using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class DamascusHelmet : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.defense = 6;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetAttackSpeed(DamageClass.Melee) += 0.03f;
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<DamascusBar>(), 10)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 15)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
