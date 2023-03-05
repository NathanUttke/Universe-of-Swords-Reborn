using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Saphira : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Saphira");
		Tooltip.SetDefault("'Sword with many shining sapphires attached to it'");
	}

	public override void SetDefaults()
	{
		Item.width = 56;
		Item.height = 56;
		Item.scale = 1.3f;
		Item.rare = ItemRarityID.Cyan;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.damage = 60;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item46;
		Item.shoot = Mod.Find<ModProjectile>("SaphiraProj").Type;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{

		int numberProjectiles = 4 + Main.rand.Next(4);
		Vector2 vector2_1 = default(Vector2);
		for (int index = 0; index < numberProjectiles; index++)
		{
			//((Vector2)(ref vector2_1))._002Ector((float)(player.position.X + player.width * 0.5 + (double)(Main.rand.Next(100) * -player.direction) + (Main.mouseX + Main.screenPosition.X - player.position.X)), (float)(player.position.Y + player.height * 0.5 - 600.0));
			vector2_1.X = (float)(player.position.X + player.width * 0.5 + (Main.rand.Next(100) * -player.direction) + (Main.mouseX + Main.screenPosition.X - player.position.X));
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
		val.AddIngredient(ItemID.Sapphire, 25);
		val.AddIngredient(ItemID.SpookyWood, 400);
		val.AddIngredient(ItemID.ScarecrowBanner, 1);
		val.AddIngredient(ItemID.ZombieElfBanner, 1);
		val.AddIngredient(ItemID.BlizzardStaff, 1);
		val.AddIngredient(Mod, "BlizzardRage", 1);
		val.AddIngredient(Mod, "Orichalcon", 2);
		val.AddIngredient(Mod, "SwordMatter", 300);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
