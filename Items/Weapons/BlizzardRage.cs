using System;
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
		Item.scale = 1.1f;
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
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = Main.rand.Next(1, 3);
		Vector2 vector2_1 = new();
		for (int index = 0; index < numberProjectiles; index++)
		{
			//vector2_1 = ((float)(player.position.X + player.width * 0.5 + (double)(Main.rand.Next(100) * -player.direction) + (Main.mouseX + Main.screenPosition.X - player.position.X)), (float)(player.position.Y + player.height * 0.5 - 600.0));

			// seperated above code into vector2_1.X and vector2_1.Y because of errors
			vector2_1.X = (float)(player.position.X + player.width * 0.5 + (double)(Main.rand.Next(100) * -player.direction) + (Main.mouseX + Main.screenPosition.X - player.position.X));
			vector2_1.Y = (float)(player.position.Y + player.height * 0.5 - 600.0);

		    vector2_1.X = (float)(((double)vector2_1.X + player.Center.X) / 2.0) + (float)Main.rand.Next(-100, 100);
			vector2_1.Y -= 100 * index;
			float num12 = Main.mouseX + Main.screenPosition.X - vector2_1.X;
			float num13 = Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
			if ((double)num13 < 0.0)
			{
				num13 *= -1f;
			}
			if ((double)num13 < 20.0)
			{
				num13 = 20f;
			}
			float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
			float num15 = Item.shootSpeed / num14;
			float num17 = num12 * num15;
			float num16 = num13 * num15;
			velocity.X = num17 + Main.rand.Next(-12, 10) * 0.16f;
			velocity.Y = num16 + Main.rand.Next(-12, 10) * 0.16f;
			Projectile.NewProjectile(source, vector2_1.X, vector2_1.Y, velocity.X, velocity.Y, type, (int)(damage * 0.5f), knockback, Main.myPlayer, 0f, Main.rand.Next(5));
		}
		return false;
	}	
}
