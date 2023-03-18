using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Machine : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Pew, pew! Boom, boom!");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 62;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 62;
		Item.knockBack = 3.5f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.shoot = ProjectileID.VortexBeaterRocket;
		Item.shootSpeed = 10f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}


	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.BrokenHeroSword, 1);
		val.AddIngredient(Mod, "Orichalcon", 1);
		val.AddIngredient(Mod, "UpgradeMatter", 2);
		val.AddIngredient(ItemID.LaserRifle, 1);
		val.AddIngredient(Mod, "PrimeSword", 1);
		val.AddIngredient(Mod, "DestroyerSword", 1);
		val.AddIngredient(Mod, "TwinsSword", 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
