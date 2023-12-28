using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class DamascusHelmet : ModItem
{
	public override void SetStaticDefaults()
	{
		
		// DisplayName.SetDefault("Damascus Helmet");
		// Tooltip.SetDefault("3% increased melee speed");
	}

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.defense = 4;
		Item.ResearchUnlockCount = 1;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetAttackSpeed(DamageClass.Melee) += 0.03f;
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DamascusBar", 10);
		val.AddIngredient(Mod, "SwordMatter", 15);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
