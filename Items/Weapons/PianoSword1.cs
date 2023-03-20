using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PianoSword1 : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Beethoven Beater");
		Tooltip.SetDefault("'Moonlight Sonata - Beethoven'");
	}

	public override void SetDefaults()
	{
		Item.width = 122;
		Item.height = 122;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 22;
		Item.knockBack = 3f;
		Item.UseSound = new SoundStyle($"{nameof(UniverseOfSwordsMod)}/Sounds/Item/PianoGreen");
		Item.shoot = ProjectileID.WoodenArrowFriendly;
		Item.shootSpeed = 12f;
		Item.value = 40000;
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
		val.AddIngredient(ItemID.LivingWoodPiano, 1);
		val.AddIngredient(ItemID.CactusPiano, 1);
		val.AddIngredient(ItemID.EbonwoodPiano, 1);
		val.AddIngredient(ItemID.RichMahoganyPiano, 1);
		val.AddIngredient(ItemID.PalmWoodPiano, 1);
		val.AddIngredient(ItemID.BorealWoodPiano, 1);
		val.AddIngredient(ItemID.Piano, 1);
		val.AddTile(TileID.Sawmill);
		val.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.FrostburnArrow, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.FireArrow, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.FlaironBubble, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.CursedArrow, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.IchorArrow, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.Stake, damage, knockback, player.whoAmI, 0f, 0f);
		return true;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(20, 360, false);
	}
}
