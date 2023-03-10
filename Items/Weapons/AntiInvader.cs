using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class AntiInvader : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Anti-Invader");
		Tooltip.SetDefault("'I'll like to have chicken burger, fried chicken wings, two slices of your chicken pie, no make that three... What do you mean you can't supersize me?!'");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.damage = 99;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item33;
		Item.shoot = ProjectileID.LaserMachinegunLaser;
		Item.shootSpeed = 30f;
		Item.value = Item.sellPrice(0, 25, 0, 0);
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
		val.AddIngredient(ItemID.MartianConduitPlating, 999);
		val.AddIngredient(Mod, "MartianSaucerCore", 1);
		val.AddIngredient(Mod, "SwordMatter", 200);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
