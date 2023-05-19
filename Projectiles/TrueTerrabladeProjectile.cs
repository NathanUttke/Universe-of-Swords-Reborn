using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

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
		Projectile.scale = 1.75f;
		Projectile.tileCollide = false;
		Projectile.ignoreWater = true;
		Projectile.timeLeft = 250;
		Projectile.aiStyle = ProjAIStyleID.Beam;
	}

    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(44, 217, 0, 0) * Projectile.Opacity;
    }
    public override void AI()
	{
		int newTerraDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.TerraBlade, 0f, 0f, 127, default, 1.1f);
        Main.dust[newTerraDust].noGravity = true;       
		Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
	}
    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        for (int i = 4; i < 31; i++)
        {

            int terraDust = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y), 8, 8, DustID.TerraBlade, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.8f);
            Main.dust[terraDust].noGravity = true;
            Dust dust = Main.dust[terraDust];
            dust.velocity *= 0.5f;

            terraDust = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y), 8, 8, DustID.TerraBlade, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.4f);
            dust = Main.dust[terraDust];
            dust.velocity *= 0.05f;
        }
    }
}
