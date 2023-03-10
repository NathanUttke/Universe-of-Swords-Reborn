using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheSwarm : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots swarm of bees");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 17;
		Item.useAnimation = 17;
		Item.damage = 15;
		Item.knockBack = 5f;
		Item.shoot = ProjectileID.Bee;
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = 38500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 100);
		val.AddIngredient(Mod, "TheStinger", 1);
		val.AddIngredient(ItemID.BeeGun, 1);
		val.AddTile(TileID.Anvils);
		val.Register();
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

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
