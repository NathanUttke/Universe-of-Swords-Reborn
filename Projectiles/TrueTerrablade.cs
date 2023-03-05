using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Projectiles;

internal class TrueTerrablade : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 50;
		Projectile.height = 30;
		Projectile.scale = 1.3f;
		Projectile.friendly = true;
		Projectile.penetrate = 1;
		Main.projFrames[Projectile.type] = 6;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Melee;
		Projectile.tileCollide = true;
		Projectile.ignoreWater = true;
	}

	public override void AI()
	{
		Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.TerraBlade, 0f, 0f, 0, default(Color), 1f).noGravity = true;
		Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.TerraBlade, 0f, 0f, 0, default(Color), 1f).noGravity = true;
		Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.TerraBlade, 0f, 0f, 0, default(Color), 1f).scale = 1f;
		Projectile.rotation = Utils.ToRotation(Projectile.velocity) + (float)Math.PI / 4f;
	}

	public override bool PreDraw(ref Color lightColor)
	{
		Projectile projectile = Projectile;
		projectile.frameCounter++;
		if (Projectile.frameCounter >= 6)
		{
			Projectile projectile2 = Projectile;
			projectile2.frame++;
			Projectile.frameCounter = 0;
			if (Projectile.frame > 5)
			{
				Projectile.frame = 0;
			}
		}
		return true;
	}

	public override void Kill(int timeLeft)
	{
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 0f, 10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 0f, -10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 10f, 10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, -10f, -10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, -10f, 10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 10f, -10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 20f, 10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, -20f, -10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, -20f, 10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 20f, -10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 40f, 10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, -40f, -10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, -40f, 10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 40f, -10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 80f, 10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, -80f, -10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, -80f, 10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 80f, -10f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, -120f, 5f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position.X + 40f, Projectile.position.Y + 40f, 120f, -5f, ProjectileID.TerraBeam, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
	}
}
