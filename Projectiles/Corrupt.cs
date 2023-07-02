using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class Corrupt : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Corrupt Crystallus");
	}


	public override void SetDefaults()
	{
		Projectile.width = 10;
		Projectile.height = 10;
		Projectile.scale = 1f;
		Projectile.aiStyle = ProjAIStyleID.Arrow;
		Projectile.friendly = true;
		Projectile.DamageType = DamageClass.MeleeNoSpeed;
		Projectile.penetrate = 1;
		Projectile.alpha = 255;
		Projectile.ignoreWater = false;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		Projectile.timeLeft = 60;
        AIType = ProjectileID.Bullet;
	}

	public override void AI()
	{
		base.AI();
		if (Main.rand.NextBool(2))
		{
			Dust obj = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Demonite, 0f, 0f, 0, default, 1f);
			obj.noGravity = true;
			obj.scale = 1f;
		}
	}

	public override void Kill(int timeLeft)
	{

		for (int i = 0; i < 10; i++)
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Demonite, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, default, 1f);
		}
		SoundEngine.PlaySound(SoundID.Dig, new Vector2(Projectile.position.X, Projectile.position.Y));
	}
}
