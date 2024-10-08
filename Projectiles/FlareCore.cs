using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.Audio;
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
        Projectile.height = 22;
        Projectile.scale = 1.5f;
        Projectile.aiStyle = -1;
        Projectile.timeLeft = 20;
        Projectile.penetrate = -1;
        Projectile.friendly = true;
        Projectile.ignoreWater = true;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.ArmorPenetration = 30;
        Projectile.alpha = 0;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 13;
        Projectile.noEnchantmentVisuals = true;
    }
    public override void AI()
    {        
        Lighting.AddLight(Projectile.position, 0.5f, 0.1f, 0.1f);
        for (int i = 0; i < 10; i++)
        {
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor:Color.Red, Scale:0.75f);
            dust.velocity *= 0.3f;
        }
    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.OnFire, 300);
    }

    public override Color? GetAlpha(Color lightColor) => new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);

    public override bool PreDraw(ref Color lightColor)
    {

        SpriteBatch spriteBatch = Main.spriteBatch;

        Texture2D texture = TextureAssets.Projectile[Type].Value;
        Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");
        Color drawColor = new(255, 127, 127, 0);
        Color glowColor = new(255, 64, 64, 0);

        Vector2 origin = Vector2.UnitX * texture.Width / 2;       

        for (int j = 0; j < Projectile.oldPos.Length; j++)
        {
            Vector2 drawPos = Projectile.oldPos[j] - Main.screenPosition + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY);
            
            drawColor *= 0.75f;
            glowColor *= 0.75f;

            spriteBatch.Draw(glowTexture, drawPos, null, glowColor, Projectile.rotation, glowTexture.Size() / 2f, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            spriteBatch.Draw(texture, drawPos, null, drawColor, Projectile.velocity.ToRotation() + MathHelper.PiOver2, origin, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);            
        }

        spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Color.White with { A = 127 }, Projectile.velocity.ToRotation() + MathHelper.PiOver2, origin, Projectile.scale, SpriteEffects.None, 0);

        return false;
    }

    public override void OnKill(int timeLeft)
    {
        Projectile.Resize(144, 144);
        SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        Projectile.Damage();
        for (int i = 0; i < 5; i++)
        {
            Dust explodeDust = Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<GlowDust>(), Projectile.velocity, 100, Color.Red, 6f);
            explodeDust.velocity = Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 20f * 16f) * 8f;
        }
    }    
}
