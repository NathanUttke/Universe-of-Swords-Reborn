using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

internal class Nightmare : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.width = 80;
        Projectile.height = 100;
        Projectile.scale = 0.5f;
        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Main.projFrames[Projectile.type] = 4;
        Projectile.hostile = false;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
    }

    public override void AI()
    {
        Dust obj = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 0, default(Color), 1f);
        obj.noGravity = true;
        obj.scale = 1f;
        Dust obj2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 0, default(Color), 1f);
        obj2.noGravity = true;
        obj2.scale = 1.5f;
        Dust obj3 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 0, default(Color), 1f);
        obj3.noGravity = true;
        obj3.scale = 2f;
        if (Projectile.velocity.X < 0f)
        {
            Projectile.spriteDirection = -1;
        }
        if (Projectile.velocity.X > 0f)
        {
            Projectile.spriteDirection = 1;
        }
        Projectile.alpha = (int)Projectile.localAI[0] * 2;
        for (int i = 0; i < 200; i++)
        {
            NPC target = Main.npc[i];
            if (!target.friendly)
            {
                float shootToX = target.position.X + (float)target.width * 1f - Projectile.Center.X;
                float shootToY = target.position.Y - Projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);
                if (distance < 480f && !target.friendly && target.active)
                {
                    distance = 3f / distance;
                    shootToX *= distance * 5f;
                    shootToY *= distance * 5f;
                    Projectile.velocity.X = shootToX;
                    Projectile.velocity.Y = shootToY;
                }
            }
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
            if (Projectile.frame > 3)
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
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.PurpleTorch, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, default(Color), 1f);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.PurpleTorch, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, default(Color), 1f);
        }
        SoundEngine.PlaySound(SoundID.Dig, new Vector2(Projectile.position.X, Projectile.position.Y));
    }

    public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
    {
        Player owner = Main.player[Projectile.owner];
        if (Main.rand.NextBool(2))
        {
            n.AddBuff(153, 800, false);
            owner.statLife += 2;
            owner.HealEffect(2, true);
        }
    }
}
