using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class MechanicalSoul : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Left click to shoot multiple projectiles that deal lower damage\nRight click to shoot big projectile that deals higher damage");
	}

	public override void SetDefaults()
	{
		Item.width = 52;
		Item.height = 60;
		Item.scale = 1f;
		Item.expert = true;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 120;
		Item.knockBack = 8f;
		Item.shootSpeed = 20f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 25, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.knockBack = 8f;
			Item.crit = 6;
			Item.damage = 120;
			Item.shoot = ModContent.ProjectileType<InvisibleProj>();
		}
		else
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.knockBack = 4f;
			Item.crit = 0;
			Item.damage = 80;
			Item.shoot = ModContent.ProjectileType<Soul1>();
		}
		return base.CanUseItem(player);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		if (player.altFunctionUse == 2)
		{
			Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<Projectiles.MechanicalSoul>(), damage, knockback, player.whoAmI, 0f, 0f);
			return true;
		}
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 1f, velocity.Y + 1f, ModContent.ProjectileType<Soul2>(), damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 1f, velocity.Y - 1f, ModContent.ProjectileType<Soul3>(), damage, knockback, player.whoAmI, 0f, 0f);
		return true;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{

		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.BlueTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.RedTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.GreenTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "Nightlight", 1);
		val.AddIngredient(ItemID.HallowedBar, 30);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
