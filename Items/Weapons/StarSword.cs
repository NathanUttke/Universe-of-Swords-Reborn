using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Placeable;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class StarSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots bouncy stars");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 55;
		Item.useAnimation = 25;
		Item.damage = 26;
		Item.knockBack = 5f;
		Item.shoot = ModContent.ProjectileType<StarSwordProjectile>();
		Item.shootSpeed = 9f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 20, 0);
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; 		
		SacrificeTotal = 1;
	}

    public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 2)
		.AddIngredient(ItemID.Starfury, 1)
		.AddIngredient(ItemID.FallenStar, 20)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
