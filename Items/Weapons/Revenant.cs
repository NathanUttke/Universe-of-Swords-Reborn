using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Revenant : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Point this sword to the sky and unleash spirits of the dead'");
	}

	public override void SetDefaults()
	{
		Item.damage = 250;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
		Item.channel = true;
		Item.rare = ItemRarityID.Red;
		Item.width = 28;
		Item.height = 30;
		Item.useTime = 20;
		Item.UseSound = SoundID.Item103;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.shootSpeed = 10f;
		Item.useAnimation = 20;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.LostSoulFriendly;
		Item.value = Item.sellPrice(0, 50, 0, 0);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		float spread = 1.74f;
		float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
		double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
		double deltaAngle = spread / 2f;
		for (int i = 0; i < 50; i++)
		{
			double offsetAngle = startAngle + deltaAngle * (double)i;
			Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), Item.shoot, damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);
		}
		return false;
	}
}
