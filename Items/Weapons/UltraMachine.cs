using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class UltraMachine : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Ultra Machine");
		Tooltip.SetDefault("'Insert Hollywood computer generated special effects here'");
	}

	public override void SetDefaults()
	{
		Item.width = 132;
		Item.height = 132;
		Item.scale = 1.4f;
		Item.rare = ItemRarityID.Red;
		Item.crit = 6;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 120;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item62;
		Item.shoot = ProjectileID.VortexBeaterRocket;
		Item.shootSpeed = 30f;
		Item.value = Item.sellPrice(1, 0, 0, 0);
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
		val.AddIngredient(Mod, "Machine", 1);
		val.AddIngredient(Mod, "SwordMatter", 1000);
		val.AddIngredient(Mod, "DamascusBar", 20);
		val.AddIngredient(ItemID.SkeletronPrimeTrophy, 1);
		val.AddIngredient(ItemID.DestroyerTrophy, 1);
		val.AddIngredient(ItemID.RetinazerTrophy, 1);
		val.AddIngredient(ItemID.SpazmatismTrophy, 1);
		val.AddIngredient(ItemID.SpectreBar, 20);
		val.AddIngredient(Mod, "PrimeSword", 1);
		val.AddIngredient(Mod, "DestroyerSword", 1);
		val.AddIngredient(Mod, "TwinsSword", 1);
		val.AddIngredient(Mod, "MartianSaucerCore", 1);
		val.AddIngredient(ItemID.ShroomiteBar, 10);
		val.AddIngredient(ItemID.LihzahrdPowerCell, 5);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.LaserMachinegunLaser, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.RocketI, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y + 2f, velocity.X, velocity.Y + 2f, ProjectileID.RocketI, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y + 2f, velocity.X, velocity.Y + 2f, ProjectileID.LaserMachinegunLaser, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y + 2f, velocity.X, velocity.Y + 2f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y - 2f, velocity.X, velocity.Y - 2f, ProjectileID.RocketI, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y - 2f, velocity.X, velocity.Y - 2f, ProjectileID.LaserMachinegunLaser, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y - 2f, velocity.X, velocity.Y - 2f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		return true;
	}
}
