using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class SOTM : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("SOTM");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 900;
		Projectile.height = 500;
		Projectile.scale = 1f;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Ranged;
		Projectile.penetrate = -1;
		Projectile.alpha = 255;
		Projectile.light = 10f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
		base.AIType = 14;
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		target.AddBuff(Mod.Find<ModBuff>("EmperorBlaze").Type, 1000, true);
	}
}
