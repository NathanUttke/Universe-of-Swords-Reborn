using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons.Legacy;

public class SwordOfTheMultiverseOG : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword of the Multiverse");
		Tooltip.SetDefault("'\nThe Overpowered original sword as you remember it, before we nerfed the hell out of it!");
	}

	public override void SetDefaults()
	{
		Item.width = 555;
		Item.height = 555;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Purple;
		Item.crit = 65;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.axe = 1000;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 80085;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item169;

		Item.shoot = Mod.Find<ModProjectile>("SOTM").Type;
		Item.shootSpeed = 30f;
		Item.expert = true;
		Item.value = Item.sellPrice(90, 0, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
		player.itemLocation = player.Center;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 10f, velocity.Y + 10f, Mod.Find<ModProjectile>("SOTM").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 10f, velocity.Y - 10f, Mod.Find<ModProjectile>("SOTM").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SOTUProjectile1").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 5f, velocity.Y + 5f, Mod.Find<ModProjectile>("SOTUProjectile2").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 5f, velocity.Y - 5f, Mod.Find<ModProjectile>("SOTUProjectile3").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 8f, velocity.Y + 8f, Mod.Find<ModProjectile>("SOTUV4Projectile").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 8f, velocity.Y - 8f, Mod.Find<ModProjectile>("SOTUV5Projectile").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 12f, velocity.Y + 12f, Mod.Find<ModProjectile>("SOTUV6Projectile").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 13f, velocity.Y - 13f, Mod.Find<ModProjectile>("SOTU7").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 12f, velocity.Y + 12f, Mod.Find<ModProjectile>("SOTU8").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 10f, velocity.Y - 10f, Mod.Find<ModProjectile>("SOTUV9Projectile").Type, damage, knockback, player.whoAmI, 0f, 0f);
		return true;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(Mod.Find<ModBuff>("EmperorBlaze").Type, 1000, true);
	}
}