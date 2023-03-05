using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BoxOfGrenades : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Box of Grenades");
		Tooltip.SetDefault("'Forget throwing grenades one at a time. Just throw a boxful at your enemies!'");
	}

	public override void SetDefaults()
	{
		Item.width = 40;
		Item.height = 40;
		Item.scale = 1.5f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 55;
		Item.useAnimation = 55;
		Item.damage = 60;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.Grenade;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 24, 0, 0);
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
		val.AddIngredient(ItemID.FireworksLauncher, 1);
		val.AddIngredient(ItemID.AmmoBox, 1);
		val.AddIngredient(ItemID.WoodenCrate, 1);
		val.AddIngredient(ItemID.FireworksBox, 99);
		val.AddIngredient(Mod, "GrenadeBlade", 1);
		val.AddIngredient(Mod, "StickyGrenadeBlade", 1);
		val.AddIngredient(Mod, "BouncyGrenadeBlade", 1);
		val.AddIngredient(Mod, "UpgradeMatter", 10);
		val.AddIngredient(ItemID.Grenade, 2000);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 1f, velocity.Y + 1f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 1f, velocity.Y - 1f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 2f, velocity.Y + 2f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 2f, velocity.Y - 2f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 3f, velocity.Y + 3f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 3f, velocity.Y - 3f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 4f, velocity.Y + 4f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 4f, velocity.Y - 4f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 5f, velocity.Y + 5f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 5f, velocity.Y - 5f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 6f, velocity.Y + 6f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 6f, velocity.Y - 6f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 7f, velocity.Y + 7f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 7f, velocity.Y - 7f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 8f, velocity.Y + 8f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 8f, velocity.Y - 8f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 9f, velocity.Y + 9f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 9f, velocity.Y - 9f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 10f, velocity.Y + 10f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 10f, velocity.Y - 10f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 11f, velocity.Y + 11f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 11f, velocity.Y - 11f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 12f, velocity.Y + 12f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 12f, velocity.Y - 12f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 13f, velocity.Y + 13f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 13f, velocity.Y - 13f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 14f, velocity.Y + 14f, ProjectileID.Grenade, damage, knockback, player.whoAmI, 0f, 0f);
		return true;
	}
}
