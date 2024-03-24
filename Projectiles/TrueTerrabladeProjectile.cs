using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles;

public class TrueTerrabladeProjectile : ModProjectile
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
    }
    public override void SetDefaults()
	{
		Projectile.width = 31;
		Projectile.height = 34;
		Projectile.friendly = true;
		Projectile.penetrate = 1;		
		Projectile.DamageType = DamageClass.Melee;
		Projectile.scale = 1f;
		Projectile.tileCollide = true;
		Projectile.ignoreWater = true;
		Projectile.timeLeft = 30;
		Projectile.aiStyle = -1;
        Projectile.extraUpdates = 1;
	}

    public override Color? GetAlpha(Color lightColor) => new Color(98, 242, 128, 45);

    public override void AI()
	{        
        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(98, 242, 128, 45), 0.5f);
        
        Projectile.spriteDirection = Projectile.direction;
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
	}
    public override bool PreDraw(ref Color lightColor)
    {
        SpriteBatch spriteBatch = Main.spriteBatch;
        Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/TrueTerrabladeGlow");
        Texture2D terraTexture = TextureAssets.Projectile[Type].Value;

        Color drawColorGlowSecond = new(255, 242, 14, 42);
        Vector2 drawOrigin = glowTexture.Size() / 2;
        Vector2 terraOrigin = terraTexture.Size() / 2;

        SpriteEffects spriteEffects = SpriteEffects.None;
        if (Projectile.spriteDirection == -1)
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }

        for (int i = 0; i < Projectile.oldPos.Length; i++)
        {
            float num = 10 - i;
            Color drawColor = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
            drawColor *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);

            spriteBatch.Draw(glowTexture, (Projectile.oldPos[i] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale - i / (float)Projectile.oldPos.Length, spriteEffects, 0);
            spriteBatch.Draw(terraTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, terraOrigin, Projectile.scale, spriteEffects, 0);
        }

        spriteBatch.Draw(terraTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlowSecond, Projectile.rotation, terraOrigin, Projectile.scale, spriteEffects, 0);
        return false;
    }
    public override void OnKill(int timeLeft)
    {        
        SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        for (int i = 0; i < 20; i++)
        {

            int terraDust = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X, Projectile.velocity.Y, 100, new Color(98, 242, 128, 0), 1f);
            Dust dust = Main.dust[terraDust];
            dust.velocity *= 0.75f;

            terraDust = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X, Projectile.velocity.Y, 100, new Color(98, 242, 128, 0), 1f);
            Dust dust2 = Main.dust[terraDust];
            dust2.velocity *= 0.25f;
        }
        if (Projectile.ai[1] == 0f && Projectile.owner == Main.myPlayer)
        {
            Projectile.ai[1] = 1f;
            Projectile.netUpdate = true;
            for (int i = 0; i < 20; i++)
            {
                Vector2 newVelocity = new Vector2(8f, 0f).RotatedBy(i + MathHelper.TwoPi / 20f);
                Projectile newProj = Projectile.NewProjectileDirect(Projectile.GetSource_Death(), Projectile.position, newVelocity, ModContent.ProjectileType<TrueTerrabladeProjectile>(), Projectile.damage / 4, Projectile.knockBack, Projectile.owner, 0f, 1f);
                newProj.penetrate = 1;            
            }
        }
    }
}
