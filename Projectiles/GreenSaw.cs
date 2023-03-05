using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Projectiles;

public class GreenSaw : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.width = 100;
        Projectile.height = 150;
        Projectile.scale = 1.5f;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.DamageType = DamageClass.Ranged;
        Main.projFrames[Projectile.type] = 3;
        Projectile.penetrate = -1;
        Projectile.alpha = 1;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        Projectile.aiStyle = 71;
    }

    public override void PostAI()
    {
        if (Main.rand.Next(1) == 0)
        {
            Dust obj = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 0, default(Color), 1f);
            obj.noGravity = true;
            obj.scale = 1f;
            Dust obj2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 0, default(Color), 1f);
            obj2.noGravity = true;
            obj2.scale = 3f;
        }
    }

    public override bool PreDraw(ref Color lightColor)
    {
        Projectile projectile = Projectile;
        projectile.frameCounter++;
        if (Projectile.frameCounter >= 1)
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
}
