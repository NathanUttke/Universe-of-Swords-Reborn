using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PrismSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'There is no pot of gold at the end of this rainbow. Only death'");
	}

	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 35;
		Item.scale = 1.5f;
		Item.channel = true;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.damage = 120;
		Item.UseSound = SoundID.Item67;
		Item.shoot = ProjectileID.LastPrism;
		Item.shootSpeed = 120f;
		Item.value = 600000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.X -= 0f * (float)player.direction;
		player.itemLocation.Y -= 0f * (float)player.direction;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.LargeSapphire, 1);
		val.AddIngredient(ItemID.LargeRuby, 1);
		val.AddIngredient(ItemID.LargeEmerald, 1);
		val.AddIngredient(ItemID.LargeTopaz, 1);
		val.AddIngredient(ItemID.LargeAmethyst, 1);
		val.AddIngredient(ItemID.LargeDiamond, 1);
		val.AddIngredient(ItemID.CrystalShard, 50);
		val.AddIngredient(ItemID.LifeCrystal, 3);
		val.AddIngredient(ItemID.ManaCrystal, 3);
		val.AddIngredient(ItemID.RainbowCrystalStaff, 1);
		val.AddIngredient(ItemID.LastPrism, 1);
		val.AddIngredient(ItemID.LunarBar, 10);
		val.AddTile(TileID.CrystalBall);
		val.Register();
	}


	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo spawnSource, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
			//Projectile.NewProjectile((IEntitySource)(object)spawnSource, position, velocity, ProjectileID.LastPrism, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile proj = Projectile.NewProjectileDirect(spawnSource, position, velocity, ProjectileID.LastPrism, damage, knockback, player.whoAmI, 0f, 0f);
		proj.DamageType = DamageClass.Melee;
		return false;
	}
}
