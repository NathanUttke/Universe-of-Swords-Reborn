using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class SOTUV9Projectile : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sotu Projectile 9");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 100;
		Projectile.height = 100;
		Projectile.scale = 1.9f;
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
