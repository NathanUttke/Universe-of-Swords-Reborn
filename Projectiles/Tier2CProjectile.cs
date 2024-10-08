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
		Projectile.Size = new(10);
		Projectile.aiStyle = ProjAIStyleID.Arrow;
		Projectile.DamageType = DamageClass.MeleeNoSpeed;
		Projectile.penetrate = 1;
		Projectile.alpha = 255;
        Projectile.friendly = true;
        Projectile.ignoreWater = false;
		Projectile.timeLeft = 60;
		Projectile.extraUpdates = 1;
		Projectile.noEnchantmentVisuals = true;
		AIType = ProjectileID.Bullet;
	}

	public override void AI()
	{
        Dust dust = Dust.NewDustDirect(Projectile.oldPosition, 1, 1, ModContent.DustType<GlowDust>(), 0, 0, 0, Color.Red, 0.5f);
        dust.velocity *= 0.2f;
        dust.position = Projectile.Center - Projectile.velocity / 20f;
    }

	public override void OnKill(int timeLeft)
	{
        SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        for (int i = 0; i < 20; i++)
		{
			Dust dust = Dust.NewDustDirect(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Red, 0.5f);
			dust.velocity *= 2f;
		}
	}
}
