using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Utilities;

namespace UniverseOfSwordsMod.Projectiles;

internal class NightmareProjectile : ModProjectile
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Type] = 10;
        ProjectileID.Sets.TrailingMode[Type] = 3;
    }
    public override void SetDefaults()
    {
        Projectile.Size = new(30);
        Projectile.scale = 1f;
        Projectile.friendly = true;
        Projectile.penetrate = 2;
        Projectile.DamageType = DamageClass.MeleeNoSpeed;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.timeLeft = 80;        
        Projectile.light = 0.25f;
        Projectile.extraUpdates = 1;
        Projectile.aiStyle = -1;
        Projectile.usesLocalNPCImmunity = true;
    }

    public override void AI()
    {       
        Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor: Color.Purple, Scale: 1.5f);

        Projectile.velocity *= 0.97f;
        Projectile.rotation = Projectile.velocity.ToRotation();
        Projectile.spriteDirection = Projectile.direction;     
    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.ShadowFlame, 300);
    }

    public override Color? GetAlpha(Color lightColor) => new Color(195, 82, 255, 127);

    public override bool PreDraw(ref Color lightColor)
    {
        SpriteEffects spriteEffects = SpriteEffects.None;
        SpriteBatch spriteBatch = Main.spriteBatch;
        Texture2D voidTextureExtra = TextureAssets.Extra[131].Value;
        Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
        Vector2 drawOrigin = texture.Size() / 2f;

        Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
        Color drawColorGlow = Color.Purple with { A = 0 };

        if (Projectile.spriteDirection == -1)
        {
            spriteEffects = SpriteEffects.FlipVertically;
        }

        spriteBatch.Draw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), 1f, SpriteEffects.None, 0);

        for (int i = 0; i < Projectile.oldPos.Length; i++)
        {
            float num = 10 - i;
            Color drawColor = drawColorGlow * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
            drawColor *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
            spriteBatch.Draw(glowSphere, (Projectile.oldPos[i] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, glowSphere.Size() / 2f, (Projectile.scale * 1.5f) - i / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
        }

        for (int i = 0; i < Projectile.oldPos.Length; i++)
        {
            float num = 10 - i;
            Color drawColor = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
            drawColor *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
            spriteBatch.Draw(voidTextureExtra, (Projectile.oldPos[i] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation + (float)Main.timeForVisualEffects * 0.1f, drawOrigin, (Projectile.scale * 1.5f) - i / (float)Projectile.oldPos.Length, spriteEffects, 0);
            spriteBatch.Draw(texture, (Projectile.oldPos[i] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale - i / (float)Projectile.oldPos.Length, spriteEffects, 0);
        }

        spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Color.White * 0.25f , Projectile.rotation, drawOrigin, Projectile.scale * 1.125f, spriteEffects, 0);
        spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);

        return false;
    }


    public override void OnKill(int timeLeft)
    {
        for (int i = 0; i < 15; i++)
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, Color.Purple with { A = 0 }, 1.5f);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.25f, Projectile.oldVelocity.Y * 0.25f, 0, Color.Purple with { A = 0 }, 1.5f);
        }
        
        SoundEngine.PlaySound(SoundID.DD2_SkeletonDeath, Projectile.position);
    }
}
