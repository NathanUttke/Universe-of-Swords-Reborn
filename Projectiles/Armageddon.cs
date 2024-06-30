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
        Projectile.width = 20;
        Projectile.height = 13;
        Projectile.scale = 1f;
        Projectile.aiStyle = 25;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.MeleeNoSpeed;
        Projectile.penetrate = 1;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        AIType = ProjectileID.Boulder;
    }

    public override void AI()
    {
        Projectile.rotation = Projectile.velocity.ToRotation();
        if (Main.rand.NextBool(2))
        {
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Orange with { A = 0 }, 1f);
        }
    }

    public override bool PreDraw(ref Color lightColor)
    {
        SpriteBatch spriteBatch = Main.spriteBatch;
        Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
        Color drawColorGlow = Color.Orange;
        drawColorGlow.A = 0;

        Texture2D meteorTexture = TextureAssets.Projectile[Type].Value;
        Vector2 drawOrigin = new(meteorTexture.Width / 2, meteorTexture.Height / 2);


        spriteBatch.Draw(meteorTexture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
        spriteBatch.Draw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), 0.8f, SpriteEffects.None, 0);

        return false;
    }

    public override void OnKill(int timeLeft)
    {
        Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 0, default, 1f);
        Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, default, 1f);

        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0f, 0f, ProjectileID.InfernoFriendlyBlast, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
        SoundEngine.PlaySound(SoundID.Dig, new Vector2(Projectile.position.X, Projectile.position.Y));             
    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (!target.HasBuff(BuffID.Daybreak))
        {
            target.AddBuff(BuffID.Daybreak, 500, false);
        }
    }
}
