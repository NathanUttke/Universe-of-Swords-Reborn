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
using UniverseOfSwordsMod.Dusts;

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
        Projectile.timeLeft = 20;

        Projectile.penetrate = -1;
        Projectile.friendly = true;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;

        Projectile.DamageType = DamageClass.Ranged;
        Projectile.ArmorPenetration = 30;
        Projectile.light = 0.5f;
        Projectile.alpha = 0;

        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 13;
    }
    public override void AI()
    {
        base.AI();        
        Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Red with { A = 0 }, 2f);
    }
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (!target.HasBuff(BuffID.OnFire))
        {
            target.AddBuff(BuffID.OnFire, 300);
        }
    }

    public override Color? GetAlpha(Color lightColor) => new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);

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
        Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");
        Color drawColor = Color.White with { A = 0 };
        Color glowColor = new Color(255, 64, 64, 0);

        //Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);
        //Vector2 origin = sourceRectangle.Size() / 2;       

        for (int j = 0; j < Projectile.oldPos.Length; j++)
        {
            Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY);
            
            drawColor *= 0.75f;
            glowColor *= 0.75f;

            spriteBatch.Draw(glowTexture, drawPos, null, glowColor, Projectile.rotation, glowTexture.Size() / 2f, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            spriteBatch.Draw(texture, drawPos, null, drawColor, Projectile.velocity.ToRotation() + MathHelper.PiOver2, Projectile.Size / 2f, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);            
        }

        spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Color.White with { A = 127 }, Projectile.velocity.ToRotation() + MathHelper.PiOver2, Projectile.Size / 2f, Projectile.scale, SpriteEffects.None, 0);

        return false;
    }

    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        Projectile.Damage();
        for (int i = 0; i < 16; i++)
        {
            int explodeDust = Dust.NewDust(Projectile.position, 25, 50, ModContent.DustType<GlowDust>(), 0f, 0f, 100, new Color(255, 64, 64, 0), 2f);
            Main.dust[explodeDust].velocity = Main.rand.NextVector2Circular(7f, 7f).SafeNormalize(Vector2.Zero);
        }
    }    
}
