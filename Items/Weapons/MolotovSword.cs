using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons;

public class MolotovSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'The bottle cracked under the pressure and the flames came out of the wrong end. Though it seems to have improved it...'");
		SacrificeTotal = 1;

	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.7f;
		Item.rare = ItemRarityID.LightRed;
		Item.crit = 8;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 69;
		Item.knockBack = 6f;
		Item.shoot = ProjectileID.MolotovCocktail;
		Item.shootSpeed = 12f;
		Item.UseSound = new SoundStyle($"{nameof(UniverseOfSwordsMod)}/Sounds/Item/Flare");
		Item.value = Item.sellPrice(0, 20, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DamascusBar", 30);
		val.AddIngredient(ItemID.MolotovCocktail, 99);
		val.AddIngredient(ItemID.HellstoneBar, 50);
		val.AddIngredient(ItemID.LivingFireBlock, 100);
		val.AddIngredient(ItemID.Sake, 30);
		val.AddIngredient(ItemID.Flamethrower, 1);
		val.AddTile(TileID.Kegs);
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
