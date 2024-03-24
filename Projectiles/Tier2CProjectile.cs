using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles;

public class Tier2CProjectile : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 10;
		Projectile.height = 10;
		Projectile.scale = 1f;
		Projectile.aiStyle = ProjAIStyleID.Arrow;
		Projectile.DamageType = DamageClass.MeleeNoSpeed;
		Projectile.penetrate = 1;
		Projectile.alpha = 255;
        Projectile.friendly = true;
        Projectile.ignoreWater = false;
		Projectile.tileCollide = true;
		Projectile.timeLeft = 50;
		Projectile.extraUpdates = 1;
		AIType = ProjectileID.Bullet;
	}

	public override void AI()
	{
		if (Main.rand.NextBool(2))
		{
			Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Salmon, 1.25f);
		}
	}

	public override void OnKill(int timeLeft)
	{
        SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        for (int i = 0; i < 10; i++)
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, Color.Salmon, 1.25f);
		}
	}
}
