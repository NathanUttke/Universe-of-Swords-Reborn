using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class EdgeLord : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Blood for the Blood God! Skulls for the skull throne! Milk for the Khorne flakes!'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 12;
		Item.useAnimation = 12;
		Item.damage = 222;
		Item.knockBack = 11f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.VampireKnife;
		Item.shootSpeed = 30f;
		Item.value = 800000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.X -= 0f * (float)player.direction;
		player.itemLocation.Y -= 0f * (float)player.direction;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "DraculaSword", 2);
		val.AddIngredient(ItemID.VampireKnives, 1);
		val.AddIngredient(ItemID.VampireBanner, 1);
		val.AddIngredient(ItemID.HellstoneBar, 80);
		val.AddIngredient(ItemID.LunarBar, 40);
		val.AddIngredient(Mod, "SwordMatter", 69);
		val.AddIngredient(ItemID.TrueNightsEdge, 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(Mod, "DraculaSword", 2);
		val2.AddIngredient(ItemID.ScourgeoftheCorruptor, 1);
		val2.AddIngredient(ItemID.VampireBanner, 1);
		val2.AddIngredient(ItemID.HellstoneBar, 80);
		val2.AddIngredient(ItemID.LunarBar, 40);
		val2.AddIngredient(Mod, "SwordMatter", 69);
		val2.AddIngredient(ItemID.TrueNightsEdge, 1);
		val2.AddTile(TileID.LunarCraftingStation);
		val2.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		float spread = 1.74f;
		float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
		double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
		double deltaAngle = spread / 2f;
		for (int i = 0; i < 65; i++)
		{
			double offsetAngle = startAngle + deltaAngle * (double)i;
			Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), Item.shoot, damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);
		}
		return false;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(69, 360, false);
	}
}
