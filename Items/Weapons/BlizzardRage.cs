using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BlizzardRage : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 20;
		Item.damage = 51;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.NorthPoleSnowflake;
		Item.shootSpeed = 25f;
		Item.value = 450500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		Item.ResearchUnlockCount = 1;
		Item.alpha = 100;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = Main.rand.Next(1, 4);
		Vector2 vector2_1 = new();
		for (int i = 0; i < numberProjectiles; i++)
		{
			vector2_1.X = player.Center.X + (Main.rand.Next(100) * -player.direction) + (Main.mouseX + Main.screenPosition.X - player.position.X);
			vector2_1.Y = player.Center.Y - 600f;

		    vector2_1.X = (float)((vector2_1.X + player.Center.X) / 2f) + Main.rand.Next(-100, 100);
			vector2_1.Y -= 100 * i;
			float num12 = Main.mouseX + Main.screenPosition.X - vector2_1.X;
			float num13 = Main.mouseY + Main.screenPosition.Y - vector2_1.Y;

			if (num13 < 0f)
			{
				num13 *= -1f;
			}
			if (num13 < 20f)
			{
				num13 = 20f;
			}

			float num14 = MathF.Sqrt(num12 * num12 + num13 * num13);
			float num15 = Item.shootSpeed / num14;
			num12 *= num15;
			num13 *= num15;
			velocity.X = num12 + Main.rand.Next(-12, 10) * 0.16f;
			velocity.Y = num13 + Main.rand.Next(-12, 10) * 0.16f;
			Projectile.NewProjectile(source, vector2_1, velocity, type, damage / 2, knockback, player.whoAmI, 0f, Main.rand.Next(5));
		}
		return false;
	}	
}
