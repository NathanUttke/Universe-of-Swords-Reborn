using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.Graphics.Shaders;
using Terraria.Graphics;
using Terraria.Audio;
using System;

namespace UniverseOfSwordsMod.Projectiles;

public class FlareCore : ModProjectile
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Type] = 10;
        ProjectileID.Sets.TrailingMode[Type] = 3;
    }
    public override void SetDefaults()
    {
        Projectile.width = 22;
        Projectile.height = 46;

        Projectile.scale = 1.15f;
        Projectile.aiStyle = -1;
        Projectile.timeLeft = 50;

        Projectile.penetrate = -1;
        Projectile.friendly = true;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;

        Projectile.DamageType = DamageClass.Ranged;
        Projectile.ArmorPenetration = 30;
        Projectile.light = 0.8f;

        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 13;
    }
    public override void AI()
    {
        base.AI();        
        Dust redDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 1f);
        redDust.noGravity = true;
        redDust.scale = 1.15f;
    }
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (Main.rand.NextBool(2) && !target.HasBuff(BuffID.OnFire))
        {
            target.AddBuff(BuffID.OnFire, 300);
        }
    }

    public override bool PreDraw(ref Color lightColor)
    {
        /*var mainType = typeof(Main); 
        // Reflection stuff
        MethodInfo methodInfo = mainType.GetMethod("DrawPrettyStarSparkle", BindingFlags.NonPublic | BindingFlags.Static);
        if (methodInfo != null)
        {
            methodInfo.Invoke(this, new object[] {Projectile, SpriteEffects.None, Projectile.Center + Vector2.Zero - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + (Projectile.rotation - MathHelper.PiOver2).ToRotationVector2(), Color.Yellow, Color.Red});
        }*/

        SpriteBatch spriteBatch = Main.spriteBatch;

        Texture2D texture = TextureAssets.Projectile[Type].Value;
        Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);
        Vector2 origin = sourceRectangle.Size() / 2;
        Color newColor = Color.White;

        for (int j = 0; j < Projectile.oldPos.Length; j++)
        {
            Vector2 drawPos = Projectile.oldPos[j] - Main.screenPosition + origin;
            float multValue = 10 - j;
            newColor *= multValue / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
            newColor.A /= 8;
            spriteBatch.Draw(texture, drawPos, sourceRectangle, newColor, Projectile.velocity.ToRotation() + MathHelper.PiOver2, origin, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);

        }
        newColor.A = 0;
        spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, Color.White, Projectile.velocity.ToRotation() + MathHelper.PiOver2, origin, Projectile.scale, SpriteEffects.None, 0);

        return false;
    }

    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        Projectile.Damage();
        for (int i = 0; i < 8; i++)
        {
            int explodeDust = Dust.NewDust(Projectile.position, 25, 50, DustID.Clentaminator_Red, 0f, 0f, 100, default, 1.5f);
            Main.dust[explodeDust].velocity = Main.rand.NextVector2Circular(7f, 7f);
        }
    }
    public override Color? GetAlpha(Color lightColor) => Color.Red;

    private Color StripColors(float progressOnStrip)
    {
        Color result = Color.Lerp(Color.White, Color.Red, Utils.GetLerpValue(-0.2f, 0.5f, progressOnStrip, clamped: true)) * (1f - Utils.GetLerpValue(0f, 0.98f, progressOnStrip));
        result.A = 0;
        return result;
    }
    private float StripWidth(float progressOnStrip)
    {
        float num = 1f;
        float lerpValue = Utils.GetLerpValue(0f, 0.2f, progressOnStrip, clamped: true);
        num *= 1f - (1f - lerpValue) * (1f - lerpValue);
        return 64f;
    }
}
