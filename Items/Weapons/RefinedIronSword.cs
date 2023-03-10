using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class RefinedIronSword : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Refined Iron Sword");
	}

	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 60;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 15;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.buyPrice(0, 0, 30, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		
																								Recipe val = CreateRecipe(1);
		val.AddRecipeGroup("IronBar", 5);
		val.AddIngredient(ItemID.IronBroadsword, 1);
		val.AddIngredient(Mod, "SwordMatter", 20);
		val.AddTile(TileID.Anvils);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddRecipeGroup("IronBar", 5);
		val2.AddIngredient(ItemID.LeadBroadsword, 1);
		val2.AddIngredient(Mod, "SwordMatter", 20);
		val2.AddTile(TileID.Anvils);
		val2.Register();
	}
}
