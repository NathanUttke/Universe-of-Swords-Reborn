using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GreatswordOfTheCosmos : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Greatsword of the Cosmos");		
	}

	public override void SetDefaults()
	{
		Item.width = 100;
		Item.height = 100;
		Item.rare = ItemRarityID.Purple;
		Item.crit = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 150;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item46;
		Item.shoot = ProjectileID.Meteor1;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 30 + Main.rand.Next(30);
		Vector2 vector2_1 = default;
		for (int index = 0; index < numberProjectiles; index++)
		{

			vector2_1.X = (float)(player.position.X + player.width * 1.0 + (double)(Main.rand.Next(100) * -player.direction) + (Main.mouseX + Main.screenPosition.X - player.position.X));
			vector2_1.Y = (float)(player.position.Y + player.height * 0.5 - 600.0);

		    vector2_1.X = (float)(((double)vector2_1.X + player.Center.X) / 2.0) + (float)Main.rand.Next(-100, 100);
			vector2_1.Y -= 500 * index;
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
			float SpeedX = num17 + Main.rand.Next(-12, 10) * 0.2f;
			float SpeedY = num16 + Main.rand.Next(-12, 10) * 0.2f;
			Projectile.NewProjectile(source, vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockback, Main.myPlayer, 0f, (float)Main.rand.Next(5));
		}
		return false;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.StarWrath, 1)
			.AddIngredient(ItemID.FragmentSolar, 30)
			.AddIngredient(ItemID.FragmentVortex, 30)
			.AddIngredient(ItemID.FragmentNebula, 30)
			.AddIngredient(ItemID.FragmentStardust, 30)
			.AddIngredient(ModContent.ItemType<PowerOfTheGalactic>(), 1)
			.AddIngredient(ItemID.MeteoriteBar, 100)
			.AddIngredient(ItemID.HellstoneBar, 100)
			.AddIngredient(ModContent.ItemType<Orichalcon>(), 10)
			.AddIngredient(ItemID.LunarBar, 50)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 10)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
    }
}
