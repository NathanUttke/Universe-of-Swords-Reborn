using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons.Legacy;

public class SwordOfTheUniverseOG : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword of the Universe");
		Tooltip.SetDefault("'This sword doesn't swing. It lifts the Universe towards the blade'\nThe Overpowered original sword as you remember it, before we nerfed the hell out of it!\nLegacy Item");
	}

	public override void SetDefaults()
	{
		Item.width = 140;
		Item.height = 140;
		Item.scale = 2f;
		Item.rare = ItemRarityID.Purple;
		Item.crit = 16;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 1337;
		Item.knockBack = 20f;
		Item.UseSound = SoundID.Item169;

		Item.shoot = Mod.Find<ModProjectile>("SOTUProjectile2").Type;
		Item.shootSpeed = 30f;
		Item.expert = true;
		Item.value = Item.sellPrice(10, 0, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.X -= 1f * (float)player.direction;
		player.itemLocation.Y -= 1f * (float)player.direction;
	}


	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 2f, velocity.Y + 2f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 2f, velocity.Y - 2f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 4f, velocity.Y + 4f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 4f, velocity.Y - 4f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 6f, velocity.Y + 6f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 6f, velocity.Y - 6f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 8f, velocity.Y + 8f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 8f, velocity.Y - 8f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 10f, velocity.Y + 10f, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.InfluxWaver, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 1f, velocity.Y + 1f, ProjectileID.InfluxWaver, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 1f, velocity.Y - 1f, ProjectileID.InfluxWaver, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 2f, velocity.Y + 2f, ProjectileID.InfluxWaver, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 2f, velocity.Y - 2f, ProjectileID.InfluxWaver, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 3f, velocity.Y + 3f, ProjectileID.InfluxWaver, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 3f, velocity.Y - 3f, ProjectileID.InfluxWaver, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 4f, velocity.Y + 4f, ProjectileID.InfluxWaver, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 4f, velocity.Y - 4f, ProjectileID.InfluxWaver, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 5f, velocity.Y + 5f, ProjectileID.InfluxWaver, damage, knockback, player.whoAmI, 0f, 0f);
		return true;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
		target.AddBuff(69, 360, false);
		target.AddBuff(44, 360, false);
		target.AddBuff(24, 360, false);
		target.AddBuff(20, 360, false);
		target.AddBuff(39, 360, false);
	}
}
