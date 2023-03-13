using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BuzzKillFutureMode : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Buzz Kill Future Mode");
		Tooltip.SetDefault("'Release the Gamma ray infused bees!'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Red;
		Item.crit = 4;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 50;
		Item.knockBack = 1f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.Bee;
		Item.shootSpeed = 9f;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int[] projectileArray = {ProjectileID.BeeHive, ProjectileID.Beenade}; 

		if (Main.rand.NextBool(5))
		{
            float spread = 0.174f;
            float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
            double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
            double deltaAngle = spread / 2f;
            double offsetAngle = startAngle + deltaAngle;
            Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), projectileArray[Main.rand.Next(0, projectileArray.Length)], damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);         
        }
		return true;
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "LunarOrb", 1);
		val.AddIngredient(ItemID.HiveBackpack, 1);
		val.AddIngredient(ItemID.LunarBar, 20);
		val.AddIngredient(Mod, "BuzzKill", 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}
}
