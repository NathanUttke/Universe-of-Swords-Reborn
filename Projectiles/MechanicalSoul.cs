using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class MechanicalSoul : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 20;
		Projectile.height = 18;
		Projectile.scale = 1.5f;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Ranged;
		Main.projFrames[Projectile.type] = 3;
		Projectile.penetrate = -1;
		Projectile.alpha = 255;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		base.AIType = 14;
	}

	public override void PostAI()
	{
		if (Main.rand.NextBool(1))
		{
			Dust obj = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch, 0f, 0f, 0, default(Color), 1f);
			obj.noGravity = true;
			obj.scale = 1f;
			Dust obj2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 0, default(Color), 1f);
			obj2.noGravity = true;
			obj2.scale = 1f;
			Dust obj3 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenTorch, 0f, 0f, 0, default(Color), 1f);
			obj3.noGravity = true;
			obj3.scale = 1f;
		}
	}

	public override bool PreDraw(ref Color lightColor)
	{
		Projectile projectile = Projectile;
		projectile.frameCounter++;
		if (Projectile.frameCounter >= 8)
		{
			Projectile projectile2 = Projectile;
			projectile2.frame++;
			Projectile.frameCounter = 0;
			if (Projectile.frame > 2)
			{
				Projectile.frame = 0;
			}
		}
		return true;
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 10; i++)
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.BlueTorch, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.RedTorch, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.GreenTorch, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
		}
		SoundEngine.PlaySound(SoundID.Dig, new Vector2(Projectile.position.X, Projectile.position.Y));
	}
}
