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
		Item.damage = 14;
		Item.knockBack = 5f;	
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 30, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
		.AddRecipeGroup("IronBar", 5)
		.AddIngredient(ItemID.IronBroadsword, 1)
		.AddIngredient(Mod, "SwordMatter", 20)
		.AddTile(TileID.Anvils)
		.Register();
		CreateRecipe()
		.AddRecipeGroup("IronBar", 5)
		.AddIngredient(ItemID.LeadBroadsword, 1)
		.AddIngredient(Mod, "SwordMatter", 20)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
