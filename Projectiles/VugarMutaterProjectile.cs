using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class VugarMutaterProjectile : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Vugar Mutater");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 20;
		Projectile.height = 25;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.DamageType = DamageClass.Melee;
		Projectile.penetrate = -1;
		Projectile.alpha = 255;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
		base.AIType = 14;
	}
}
