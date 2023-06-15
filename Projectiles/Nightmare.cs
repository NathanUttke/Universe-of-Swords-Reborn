using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

internal class Nightmare : ModProjectile
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
    }
    public override void SetDefaults()
    {
        Projectile.width = 54;
        Projectile.height = 58;
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

    public override Color? GetAlpha(Color lightColor) => new Color(255, 82, 119, 100);

    public override bool PreDraw(ref Color lightColor)
    {
        SpriteEffects spriteEffects = SpriteEffects.None;
        SpriteBatch spriteBatch = Main.spriteBatch;
        Texture2D voidTextureExtra = TextureAssets.Extra[131].Value;
        Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
        Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);

        Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
        Color drawColorGlow = new(255, 128, 255);

        if (Projectile.spriteDirection == -1)
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }

        spriteBatch.End();
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, default, default, default, default, Main.GameViewMatrix.TransformationMatrix);

        spriteBatch.Draw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), 1f, SpriteEffects.None, 0);

        for (int i = 0; i < Projectile.oldPos.Length; i++)
        {
            float num = 10 - i;
            Color drawColor = drawColorGlow * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
            drawColor *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
            spriteBatch.Draw(glowSphere, (Projectile.oldPos[i] - Main.screenPosition) + new Vector2(Projectile.width / 2f, Projectile.height / 2f) + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), (Projectile.scale * 1.5f) - i / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
        }

        spriteBatch.End();
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, default, default, default, default, Main.GameViewMatrix.TransformationMatrix);

        for (int i = 0; i < Projectile.oldPos.Length; i++)
        {
            float num = 10 - i;
            Color drawColor = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
            drawColor *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
            spriteBatch.Draw(voidTextureExtra, (Projectile.oldPos[i] - Main.screenPosition) + new Vector2(Projectile.width / 2f, Projectile.height / 2f) + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation + Main.GlobalTimeWrappedHourly * 2f, drawOrigin, (Projectile.scale * 1.5f) - i / (float)Projectile.oldPos.Length, spriteEffects, 0);
            spriteBatch.Draw(texture, (Projectile.oldPos[i] - Main.screenPosition) + new Vector2(Projectile.width / 2f, Projectile.height / 2f) + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, (Projectile.scale) - i / (float)Projectile.oldPos.Length, spriteEffects, 0);
        }

        spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);

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
