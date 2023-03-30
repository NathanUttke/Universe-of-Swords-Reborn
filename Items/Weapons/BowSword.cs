using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 35;
		Item.useAnimation = 35;
		Item.damage = 12;
		Item.knockBack = 5f;
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
		.AddRecipeGroup("IronBar", 15)
		.AddIngredient(Mod, "SwordMatter", 150)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
