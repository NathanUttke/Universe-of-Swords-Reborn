using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Horrormageddon : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Where you see an army, I see a graveyard'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 360;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item71;
		Item.shoot = ProjectileID.DeathSickle;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 5, 0, 0);
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
		val.AddIngredient(Mod, "Doomsday", 1);
		val.AddIngredient(Mod, "Apocalypse", 1);
		val.AddIngredient(Mod, "Machine", 1);
		val.AddIngredient(Mod, "InnosWrath", 1);
		val.AddIngredient(Mod, "BeliarClaw", 1);
		val.AddIngredient(ItemID.LargeEmerald, 1);
		val.AddIngredient(Mod, "UpgradeMatter", 10);
		val.AddIngredient(Mod, "LunarOrb", 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.Meowmere, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.InfernoFriendlyBlast, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.StarWrath, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		return true;
	}
}
