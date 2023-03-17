using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Projectiles;

internal class TrueTerrablade : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 40;
		Projectile.height = 40;
		Projectile.friendly = true;
		Projectile.penetrate = 1;		
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Melee;
		Projectile.tileCollide = false;
		Projectile.ignoreWater = true;
		Projectile.timeLeft = 300;
		Projectile.aiStyle = ProjAIStyleID.Beam;
		AIType = ProjectileID.SwordBeam;
	}

	public override void AI()
	{
		Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.TerraBlade, 0f, 0f, 0, default, 1f).noGravity = true;
		Projectile.rotation = Utils.ToRotation(Projectile.velocity) + MathHelper.PiOver4;
	}

    public override void Kill(int timeLeft)
    {
        Projectile.alpha++;
    }
}
