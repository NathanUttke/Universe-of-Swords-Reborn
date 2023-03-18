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
		Item.rare = ItemRarityID.Red;
		Item.crit = 6;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 15;
		Item.damage = 130;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item62;
		Item.shoot = ProjectileID.VortexBeaterRocket;
		Item.shootSpeed = 30f;
		Item.value = Item.buyPrice(0, 30, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}


	public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(Mod, "Machine", 1)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 5)
			.AddIngredient(Mod, "DamascusBar", 20)
			.AddIngredient(ItemID.SoulofFright, 15)
			.AddIngredient(ItemID.SoulofMight, 15)
			.AddIngredient(ItemID.SoulofSight, 15)
			.AddIngredient(ItemID.SpectreBar, 20)
			.AddIngredient(Mod, "PrimeSword", 1)
			.AddIngredient(Mod, "DestroyerSword", 1)
			.AddIngredient(Mod, "TwinsSword", 1)
			.AddIngredient(Mod, "MartianSaucerCore", 1)
			.AddIngredient(ItemID.ShroomiteBar, 10)
			.AddIngredient(ItemID.LihzahrdPowerCell, 5)
			.AddTile(TileID.MythrilAnvil)
			.Register();
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
