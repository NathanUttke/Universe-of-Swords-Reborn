using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace UniverseOfSwordsMod.Projectiles;

internal class TrueTerrabladeProjectile : ModProjectile
{
	public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.TerraBeam}";
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("True Terra Blade");
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }
    public override void SetDefaults()
	{
		Projectile.width = 40;
		Projectile.height = 40;
		Projectile.friendly = true;
		Projectile.penetrate = 1;		
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Melee;
		Projectile.scale = 1f;
		Projectile.tileCollide = false;
		Projectile.ignoreWater = true;
		Projectile.timeLeft = 250;
		Projectile.aiStyle = ProjAIStyleID.Beam;
		AIType = ProjectileID.SwordBeam;
	}

    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(44, 217, 0, 0) * Projectile.Opacity;
    }

    public override void AI()
	{
		//Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Green, 0f, 0f, 127, default, 1.1f).noGravity = true;
		Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
	}

    public override void Kill(int timeLeft)
    {
        Projectile.alpha++;
    }
}
