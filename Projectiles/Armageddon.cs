using Terraria.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace UniverseOfSwordsMod.Projectiles;

public class Armageddon : ModProjectile
{
    public override string Texture => $"Terraria/Images/Projectile_{Main.rand.Next(424, 426)}";

    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Type] = 8;
        ProjectileID.Sets.TrailingMode[Type] = 4;
    }
    public override void SetDefaults()
    {
        Projectile.Size = new(20);
        Projectile.scale = 1.5f;
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.MeleeNoSpeed;
        Projectile.penetrate = 1;
        Projectile.extraUpdates = 1;
        Projectile.tileCollide = true;
    }

    public override void AI()
    {
        Projectile.rotation = Projectile.velocity.ToRotation();
        Projectile.velocity.Y += 0.4f;

        for (int i = 0; i < 6; i++)
        {
            Dust dust = Dust.NewDustDirect(Projectile.position - Projectile.velocity / 20f * i, 30, 30, ModContent.DustType<GlowDust>(), 0, 0, 0, Color.Orange, 0.75f);
            dust.noGravity = true;
            dust.velocity *= 0.3f;
        }
    }
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.Daybreak, 500, false);
        target.AddBuff(BuffID.OnFire, 500, false);
    }

    public override void OnKill(int timeLeft)
    {
        Projectile.Resize(144, 144);

        for (int i = 0; i < 20; i++)
        {
            Vector2 newVelocity = Vector2.Normalize(Utils.RandomVector2(Main.rand, -100f, 100f)) * 5f;
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0, 0, 0, Color.Orange);
            dust.position = Projectile.Center;
            dust.velocity = newVelocity;
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0, 0, 0, Color.Orange);
        }

        Projectile.Damage();
        Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
        SoundEngine.PlaySound(SoundID.DD2_GoblinBomb with { Pitch = -0.25f }, Projectile.position);             
    }

    public override bool PreDraw(ref Color lightColor)
    {
        SpriteBatch spriteBatch = Main.spriteBatch;
        Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
        Color drawColorGlow = Color.Orange with { A = 0 };
        Color drawColorTrail = drawColorGlow;

        Texture2D meteorTexture = TextureAssets.Projectile[Type].Value;
        Vector2 drawOrigin = meteorTexture.Size() / 2;

        for (int i = 0; i < Projectile.oldPos.Length; i++)
        {
            Vector2 drawPos = Projectile.oldPos[i] + Projectile.Size / 2 - Main.screenPosition;
            drawColorTrail *= 0.9f;
            spriteBatch.Draw(meteorTexture, drawPos, null, drawColorTrail, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
        }


        spriteBatch.Draw(meteorTexture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
        spriteBatch.Draw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, glowSphere.Size() / 2, 0.8f, SpriteEffects.None, 0);

        return false;
    }
}
