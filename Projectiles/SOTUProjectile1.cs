using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class SOTUProjectile1 : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sotu Projectile 1");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 40;
		Projectile.height = 80;
		Projectile.scale = 2.2f;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Ranged;
		Projectile.penetrate = 999;
		Projectile.alpha = 255;
		Projectile.light = 10f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
		base.AIType = 14;
	}
}
