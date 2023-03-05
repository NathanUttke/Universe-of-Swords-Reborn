using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class SOTU7 : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sotu Projectile 7");
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void SetDefaults()
    {
        Projectile.width = 35;
        Projectile.height = 75;
        Projectile.scale = 2.2f;
        Projectile.aiStyle = 1;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = 999;
        Projectile.alpha = 255;
        Projectile.light = 10f;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        Projectile.extraUpdates = 1;
        base.AIType = 14;
    }

    public virtual void CreateDust()
    {
        if (Main.rand.Next(4) == 0)
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.VilePowder, 0f, 0f, 100, default(Color), 2f);
            Main.dust[dust].noGravity = true;
            Dust obj = Main.dust[dust];
            obj.velocity *= 0.2f;
            Dust obj2 = Main.dust[dust];
            obj2.velocity += Projectile.velocity;
        }
    }
}
