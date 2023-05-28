using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
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
		Item.useTime = 10;
		Item.useAnimation = 20;
		Item.damage = 145;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.FairyQueenMagicItemShot;
		Item.shootSpeed = 32f;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(3))
		{
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame, 0f, 0f, 100, Utils.SelectRandom(Main.rand, Color.MediumVioletRed, Color.Cyan, Color.HotPink), 2f);
            Main.dust[dust].noGravity = true;
        }
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 30;
		Vector2 vector2_1 = new();
		for (int index = 0; index < numberProjectiles; index++)
		{
			vector2_1.X = (float)(player.position.X + player.width * 1.0 + Main.rand.Next(100) * -player.direction + (Main.mouseX + Main.screenPosition.X - player.position.X));
			vector2_1.Y = (float)(player.position.Y + player.height * 0.5 - 600.0);

		    vector2_1.X = (float)(((double)vector2_1.X + player.Center.X) / 2.0) + Main.rand.Next(-100, 100);
			vector2_1.Y -= 500 * index;
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
			float SpeedX = num17 + Main.rand.Next(-12, 10) * 0.2f;
			float SpeedY = num16 + Main.rand.Next(-12, 10) * 0.2f;
			Projectile rainProj = Projectile.NewProjectileDirect(source, vector2_1, new Vector2(SpeedX, SpeedY), type, damage, knockback, Main.myPlayer, 1f);
			rainProj.DamageType = DamageClass.Melee;
		}
		return false;
	}

    public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.StarWrath, 1)
			.AddIngredient(ModContent.ItemType<LunarOrb>(), 2)
			.AddIngredient(ItemID.MeteoriteBar, 75)
			.AddIngredient(ItemID.HellstoneBar, 75)
			.AddIngredient(ModContent.ItemType<Orichalcon>(), 15)
			.AddIngredient(ItemID.LunarBar, 40)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 10)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
    }
}
