using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class Nightlight : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.width = 16;
        Projectile.height = 18;
        Projectile.scale = 1f;
        Projectile.aiStyle = 1;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = -1;
        Projectile.alpha = 255;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        Projectile.extraUpdates = 1;
        base.AIType = 14;
    }

    public override void PostAI()
    {
        if (Main.rand.NextBool(1))
        {
            Dust obj = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkTorch, 0f, 0f, 0, default(Color), 1f);
            obj.noGravity = true;
            obj.scale = 1f;
            Dust obj2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.VilePowder, 0f, 0f, 0, default(Color), 1f);
            obj2.noGravity = true;
            obj2.scale = 1f;
        }
    }

    public override void Kill(int timeLeft)
    {

        for (int i = 0; i < 10; i++)
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.PinkTorch, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.VilePowder, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, default(Color), 1f);
        }
        SoundEngine.PlaySound(SoundID.Dig, new Vector2(Projectile.position.X, Projectile.position.Y));
    }
}
