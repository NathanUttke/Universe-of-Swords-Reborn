using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class Armageddon : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.width = 20;
        Projectile.height = 13;
        Projectile.scale = 1f;
        Projectile.aiStyle = 1;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = 1;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        base.AIType = 14;
    }

    public override void PostAI()
    {
        if (Main.rand.Next(1) == 0)
        {
            Dust obj = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Flare, 0f, 0f, 0, default(Color), 1f);
            obj.noGravity = true;
            obj.scale = 2f;
        }
    }

    public override void Kill(int timeLeft)
    {
        for (int i = 0; i < 1; i++)
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Flare, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Flare, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, default(Color), 1f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0f, 0f, ProjectileID.InfernoFriendlyBlast, (int)((double)Projectile.damage * 1.0), Projectile.knockBack, Main.myPlayer, 0f, 0f);
        }
        SoundEngine.PlaySound(SoundID.Dig, new Vector2(Projectile.position.X, Projectile.position.Y));
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(189, 500, false);
    }
}
