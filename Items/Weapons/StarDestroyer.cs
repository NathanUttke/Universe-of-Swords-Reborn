using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class StarDestroyer : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Each time you swing this sword stars are being shattered to pieces'");
	}

	public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 60;
		Item.scale = 1.4f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.damage = 100;
		Item.knockBack = 4.5f;
		Item.UseSound = SoundID.Item88;
		Item.shoot = ProjectileID.LunarFlare;
		Item.shootSpeed = 30f;
		Item.value = 750000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{

		int numberProjectiles = 6 + Main.rand.Next(6);
		Vector2 vector2_1 = default(Vector2);
		for (int index = 0; index < numberProjectiles; index++)
		{
			//((Vector2)(ref vector2_1))._002Ector((float)(player.position.X + player.width * 0.5 + (double)(Main.rand.Next(100) * -player.direction) + (Main.mouseX + Main.screenPosition.X - player.position.X)), (float)(player.position.Y + player.height * 0.5 - 600.0));

			vector2_1.X = (float)(player.position.X + player.width * 0.5 + (Main.rand.Next(100) * -player.direction) + (Main.mouseX + Main.screenPosition.X - (double)(player).position.X));
			vector2_1.Y = (float)(player.position.Y + player.height * 0.5 - 600.0);

		  vector2_1.X = (float)(((double)vector2_1.X + player.Center.X) / 2.0) + (float)Main.rand.Next(-100, 100);
			vector2_1.Y -= 100 * index;
			float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
			float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
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
			float SpeedX = num17 + (float)Main.rand.Next(-12, 10) * 0.16f;
			float SpeedY = num16 + (float)Main.rand.Next(-12, 10) * 0.16f;
			Projectile.NewProjectile(source, vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockback, Main.myPlayer, 0f, (float)Main.rand.Next(5));
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.LunarFlareBook, 1);
		val.AddIngredient(ItemID.LunarBar, 10);
		val.AddIngredient(Mod, "Orichalcon", 2);
		val.AddIngredient(ItemID.FragmentSolar, 5);
		val.AddIngredient(ItemID.FragmentVortex, 5);
		val.AddIngredient(ItemID.FragmentNebula, 5);
		val.AddIngredient(ItemID.FragmentStardust, 5);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddIngredient(Mod, "LunarOrb", 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}
}
