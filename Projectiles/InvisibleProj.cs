using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class InvisibleProj : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 18;
		Projectile.height = 20;
		Projectile.scale = 1f;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Ranged;
		Projectile.penetrate = 0;
		Projectile.alpha = 255;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		base.AIType = 14;
	}
}
