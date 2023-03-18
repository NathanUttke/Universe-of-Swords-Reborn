using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SwordOfTheUniverseV2 : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword of the Universe");
		Tooltip.SetDefault("'This sword doesn't swing. It lifts the Universe towards the blade'\nHas changeable forms");
	}

	public override void SetDefaults()
	{
		Item.width = 140;
		Item.height = 140;
		Item.rare = ItemRarityID.Purple;
		Item.crit = 16;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 100;
		Item.knockBack = 20f;
		Item.UseSound = SoundID.Item169;

		Item.shoot = ProjectileID.InfluxWaver;
		Item.shootSpeed = 30f;
		Item.expert = true;
		Item.value = Item.sellPrice(8, 0, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{																																																														
		CreateRecipe()		
		.AddIngredient(Mod, "EdgeLord", 1)
		.AddIngredient(Mod, "SuperInflation", 1)
		.AddIngredient(Mod, "CosmoStorm", 1)
		.AddIngredient(Mod, "GlacialCracker", 1)
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 4)
		.AddIngredient(ItemID.Terragrim, 1)
		.AddTile(TileID.DemonAltar)
		.Register();
    }

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		float spread = 0.5f;
		float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
		double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
		double deltaAngle = spread / 2f;
		for (int i = 0; i < 5; i++)
		{
			double offsetAngle = startAngle + deltaAngle * (double)i;
			Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), Item.shoot, damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);
		}
		return false;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
		target.AddBuff(69, 360, false);
		target.AddBuff(44, 360, false);
		target.AddBuff(24, 360, false);
		target.AddBuff(20, 360, false);
		target.AddBuff(39, 360, false);
	}
}
