using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles;

public class CorruptCrystallusProj : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Corrupt Crystallus");
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
		Projectile.noEnchantmentVisuals = true;
	}

	public override void AI()
	{
        Dust dust = Dust.NewDustDirect(Projectile.position, 1, 1, ModContent.DustType<GlowDust>(), 0, 0, 0, Color.MediumOrchid, 0.5f);
		dust.velocity *= 0.2f;
        dust.position = Projectile.Center - Projectile.velocity / 10f;
    }

    public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 10; i++)
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, Color.MediumOrchid, 0.5f);
		}
		SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
	}
}
