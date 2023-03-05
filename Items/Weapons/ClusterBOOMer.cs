using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ClusterBOOMer : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Cluster BOOMer");
		Tooltip.SetDefault("'We do not take any responsibility for destroyed buildings'");
	}

	public override void SetDefaults()
	{
		Item.width = 114;
		Item.height = 114;
		Item.scale = 1.5f;
		Item.rare = ItemRarityID.Red;
		Item.crit = 2;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 75;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item62;
		Item.shoot = ProjectileID.RocketIV;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 50, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.X -= 1f * (float)player.direction;
		player.itemLocation.Y -= 1f * (float)player.direction;
	}

	public override void AddRecipes()
	{
		
																						Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.ProximityMineLauncher, 1);
		val.AddIngredient(ItemID.AmmoBox, 1);
		val.AddIngredient(ItemID.GrenadeLauncher, 1);
		val.AddIngredient(ItemID.RocketLauncher, 1);
		val.AddIngredient(Mod, "UpgradeMatter", 10);
		val.AddIngredient(ItemID.RocketI, 2000);
		val.AddIngredient(ItemID.RocketIII, 2000);
		val.AddIngredient(ItemID.RocketIV, 1000);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 1f, velocity.Y + 1f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 1f, velocity.Y - 1f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 2f, velocity.Y + 2f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 2f, velocity.Y - 2f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 3f, velocity.Y + 3f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 3f, velocity.Y - 3f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 4f, velocity.Y + 4f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 4f, velocity.Y - 4f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 5f, velocity.Y + 5f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 5f, velocity.Y - 5f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 6f, velocity.Y + 6f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 6f, velocity.Y - 6f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 7f, velocity.Y + 7f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 7f, velocity.Y - 7f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 8f, velocity.Y + 8f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 8f, velocity.Y - 8f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 9f, velocity.Y + 9f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 9f, velocity.Y - 9f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 10f, velocity.Y + 10f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 10f, velocity.Y - 10f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 11f, velocity.Y + 11f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 11f, velocity.Y - 11f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 12f, velocity.Y + 12f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 12f, velocity.Y - 12f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 13f, velocity.Y + 13f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 13f, velocity.Y - 13f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 14f, velocity.Y + 14f, ProjectileID.RocketIV, damage, knockback, player.whoAmI, 0f, 0f);
		return true;
	}
}
