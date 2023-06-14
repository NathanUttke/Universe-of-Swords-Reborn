using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

internal class Nightmare : ModProjectile
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        Main.projFrames[Projectile.type] = 4;
    }
    public override void SetDefaults()
    {
        Projectile.width = 94;
        Projectile.height = 62;
        Projectile.scale = 1f;
        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Projectile.DamageType = DamageClass.MeleeNoSpeed;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
    }

    public override void AI()
    {
        base.AI();
        float maxDetectRadius = 250f; 
        float projSpeed = 15f; 

        Dust skullDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Purple, 0f, 0f, 100, default, 1.5f);
        skullDust.noGravity = true;

        Projectile.frameCounter++;
        if (Projectile.frameCounter >= 8)
        {
            Projectile.frame++;
            Projectile.frameCounter = 0;
            if (Projectile.frame > 3)
            {
                Projectile.frame = 0;
            }
        }

        Projectile.rotation = Projectile.velocity.ToRotation();

        if (Projectile.spriteDirection == -1)
        {
            Projectile.rotation += MathHelper.Pi;
        }
        Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f) ? 1 : -1;
        Projectile.alpha = (int)Projectile.localAI[0] * 2;

        NPC closestNPC = FindClosestNPC(maxDetectRadius);
        if (closestNPC == null) 
        {
            return;
        }        
        Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
    }
    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        Player owner = Main.player[Projectile.owner];

        if (!target.HasBuff(BuffID.ShadowFlame))
        {
            target.AddBuff(BuffID.ShadowFlame, 500);
        }

        if (Main.rand.NextBool(3) && !target.HasBuff(BuffID.ShadowFlame))
        {
            target.AddBuff(BuffID.ShadowFlame, 800, false);
            owner.statLife += 2;   
            owner.HealEffect(2, true);
        }
    }
    public NPC FindClosestNPC(float maxDetectDistance)
    {
        NPC closestNPC = null;
        float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

        for (int i = 0; i < Main.maxNPCs; i++)
        {
            NPC target = Main.npc[i];
            if (target.CanBeChasedBy())
            {
                float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);
                if (sqrDistanceToTarget < sqrMaxDetectDistance)
                {
                    sqrMaxDetectDistance = sqrDistanceToTarget;
                    closestNPC = target;
                }
            }
        }
        return closestNPC;
    }

    public override bool PreDraw(ref Color lightColor)
    {
        SpriteEffects spriteEffects = SpriteEffects.None;

        Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
        int frameHeight = texture.Height / Main.projFrames[Projectile.type];
        int startY = frameHeight * Projectile.frame;

        Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
        Color drawColorGlow = Color.Purple;

        Rectangle sourceRectangle = new(0, startY, texture.Width, frameHeight);

        if (Projectile.spriteDirection == -1)
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }

        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, default, default, default, default, Main.GameViewMatrix.TransformationMatrix);

        Main.spriteBatch.Draw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), 1.25f, SpriteEffects.None, 0);
        Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, Color.White, Projectile.rotation, sourceRectangle.Size() / 2f, Projectile.scale, spriteEffects, 0);

        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, default, default, default, default, Main.GameViewMatrix.TransformationMatrix);
        return false;
    }

    public override void Kill(int timeLeft)
    {
        for (int i = 0; i < 15; i++)
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Clentaminator_Purple, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, default, 1f);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Clentaminator_Purple, Projectile.oldVelocity.X * 0.25f, Projectile.oldVelocity.Y * 0.25f, 0, default, 1f);
        }
        SoundEngine.PlaySound(SoundID.DD2_SkeletonDeath, new Vector2(Projectile.position.X, Projectile.position.Y));
    }
}
