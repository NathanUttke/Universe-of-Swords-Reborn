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
		Projectile.scale = 1f;
		Projectile.aiStyle = ProjAIStyleID.Arrow;
		Projectile.DamageType = DamageClass.MeleeNoSpeed;
		Projectile.penetrate = 1;
		Projectile.alpha = 255;
        Projectile.friendly = true;
        Projectile.ignoreWater = false;
		Projectile.tileCollide = true;
		Projectile.timeLeft = 60;
		Projectile.extraUpdates = 1;
		Projectile.noEnchantmentVisuals = true;
		AIType = ProjectileID.Bullet;
	}

	public override void AI()
	{
        Dust.NewDustDirect(Projectile.oldPosition, 1, 1, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f, 0, Color.Salmon, 0.5f);
    }

	public override void OnKill(int timeLeft)
	{
        SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        for (int i = 0; i < 10; i++)
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, Color.Salmon, 0.5f);
		}
	}
}
