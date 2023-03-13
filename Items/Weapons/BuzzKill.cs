using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BuzzKill : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Buzz Kill");
		Tooltip.SetDefault("'Release the Africanized bees!'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 25;
		Item.knockBack = 1f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.Bee;
		Item.shootSpeed = 8f;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		float spread = 0.174f;
		float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
		double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
		double deltaAngle = spread / 2f;
		for (int i = 0; i < 3; i++)
		{
			double offsetAngle = startAngle + deltaAngle * (double)i;
			Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), Item.shoot, damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.BeeKeeper, 1);
		val.AddIngredient(ItemID.BeeGun, 1);
		val.AddIngredient(ItemID.Beenade, 80);
		val.AddIngredient(ItemID.HallowedBar, 10);
		val.AddIngredient(ItemID.HoneyBlock, 500);
		val.AddIngredient(ItemID.Hive, 500);
		val.AddIngredient(Mod, "TheStinger", 1);
		val.AddTile(TileID.HoneyDispenser);
		val.Register();
	}
}
