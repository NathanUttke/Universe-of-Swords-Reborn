using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class DamascusLeggings : ModItem
{
	public override void SetStaticDefaults()
	{
		
		// DisplayName.SetDefault("Damascus Leggings");
		// Tooltip.SetDefault("6% increased movement speed");
	}

	public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.defense = 6;
		Item.ResearchUnlockCount = 1;
	}

	public override void UpdateEquip(Player player)
	{
		player.moveSpeed += 0.06f;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
            .AddIngredient(ModContent.ItemType<DamascusBar>(), 15)
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 10)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
