using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Uses arrows as ammo");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.3f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 35;
		Item.useAnimation = 35;
		Item.damage = 13;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item5;
		Item.shootSpeed = 7f;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.useAmmo = AmmoID.Arrow;
	}

	public override void AddRecipes()
	{				
		CreateRecipe()
		.AddIngredient(ItemID.WoodenBow, 1)
		.AddRecipeGroup(RecipeGroupID.IronBar, 15)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 200)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
