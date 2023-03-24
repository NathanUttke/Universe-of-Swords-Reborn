using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items;

public class DamascusPickaxe : ModItem
{
	public override void SetDefaults()
	{
		Item.damage = 10;
		Item.DamageType = DamageClass.Melee; 
		Item.width = 38;
		Item.height = 38;
		Item.useTime = 17;
		Item.useAnimation = 17;
		Item.pick = 55;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 0, 20, 0);
		Item.rare = ItemRarityID.Green;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{

		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DamascusBar", 10);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
