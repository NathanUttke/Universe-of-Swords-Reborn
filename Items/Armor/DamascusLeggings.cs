using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class DamascusLeggings : ModItem
{
	public override void SetStaticDefaults()
	{
		
		DisplayName.SetDefault("Damascus Leggings");
		Tooltip.SetDefault("6% increased movement speed");
	}

	public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.defense = 4;
		SacrificeTotal = 1;
	}

	public override void UpdateEquip(Player player)
	{
		player.moveSpeed += 0.06f;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DamascusBar", 15);
		val.AddIngredient(Mod, "SwordMatter", 65);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
