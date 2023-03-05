using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PianoSword3 : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Mozart Mauler");
		Tooltip.SetDefault("'Piano Concerto No.20 - Mozart'");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.scale = 2.5f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 66;
		Item.knockBack = 3f;
		Item.UseSound = new SoundStyle($"{nameof(UniverseOfSwordsMod)}/Sounds/Item/PianoRed");

		Item.shoot = ProjectileID.FallingStar;
		Item.shootSpeed = 15f;
		Item.value = Item.sellPrice(0, 10, 0, 0);
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
		val.AddIngredient(ItemID.SkywarePiano, 1);
		val.AddIngredient(ItemID.SlimePiano, 1);
		val.AddIngredient(ItemID.BlueDungeonPiano, 1);
		val.AddIngredient(ItemID.GreenDungeonPiano, 1);
		val.AddIngredient(ItemID.PinkDungeonPiano, 1);
		val.AddIngredient(ItemID.ObsidianPiano, 1);
		val.AddIngredient(ItemID.MeteoritePiano, 1);
		val.AddIngredient(ItemID.BonePiano, 1);
		val.AddTile(TileID.Sawmill);
		val.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.LostSoulFriendly, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.ShadowBeamFriendly, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.InfernoFriendlyBolt, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.HellfireArrow, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.MeteorShot, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.Bone, damage, knockback, player.whoAmI, 0f, 0f);
		return true;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(137, 360, false);
	}
}
