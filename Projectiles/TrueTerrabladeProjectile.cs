using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using static Terraria.ModLoader.PlayerDrawLayer;
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
		Projectile.scale = 1f;
		Projectile.tileCollide = false;
		Projectile.ignoreWater = true;
		Projectile.timeLeft = 250;
		Projectile.aiStyle = ProjAIStyleID.Beam;
		AIType = ProjectileID.TerraBeam;
	}

    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(44, 217, 0, 0) * Projectile.Opacity;
    }

    public override void AI()
	{  
		Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
	}

    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        for (int i = 4; i < 31; i++)
        {
            float oldVelocityX = Projectile.oldVelocity.X * (30f / i);
            float oldVelocityY = Projectile.oldVelocity.Y * (30f / i);

            int terraDust = Dust.NewDust(new Vector2(Projectile.oldPosition.X - oldVelocityX, Projectile.oldPosition.Y - oldVelocityY), 8, 8, DustID.TerraBlade, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.8f);
            Main.dust[terraDust].noGravity = true;
            Dust dust = Main.dust[terraDust];
            dust.velocity *= 0.5f;

            terraDust = Dust.NewDust(new Vector2(Projectile.oldPosition.X - oldVelocityX, Projectile.oldPosition.Y - oldVelocityY), 8, 8, DustID.TerraBlade, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.4f);
            dust = Main.dust[terraDust];
            dust.velocity *= 0.05f;
        }
    }
}
