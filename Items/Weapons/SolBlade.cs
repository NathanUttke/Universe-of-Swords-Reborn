using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SolBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Unleashes small spread of meteors\nMelee attacks chance have chance to spawn inferno explosion");
	}

	public override void SetDefaults()
	{
		Item.width = 86;
		Item.height = 86;
		Item.scale = 1f;
		Item.rare = -11;
		Item.useStyle = ItemUseStyleID.Swing;

		Item.useTime = 20;
		Item.useAnimation = 20;

		Item.damage = 79;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item70;
		Item.shootSpeed = 25f;
		Item.shoot = Mod.Find<ModProjectile>("Armageddon").Type;
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.InfernoFork, 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles =  Main.rand.Next(2, 6);
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(40f));
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		if (Main.rand.NextBool(3))
		{
			Projectile.NewProjectile(Item.GetSource_OnHit(target), target.Center.X, target.Center.Y, 0f, 0f, ProjectileID.InfernoFriendlyBlast, damage, knockback, player.whoAmI, 0f, 0f);
		}
	}
}
