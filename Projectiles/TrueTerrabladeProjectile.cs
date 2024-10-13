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
        ProjectileID.Sets.TrailingMode[Type] = 2;
    }
    public override void SetDefaults()
	{
		Projectile.Size = new(16);
		Projectile.friendly = true;
		Projectile.penetrate = 1;		
		Projectile.DamageType = DamageClass.Melee;
		Projectile.ignoreWater = true;
		Projectile.timeLeft = 30;
		Projectile.aiStyle = -1;
        Projectile.extraUpdates = 1;
	}

    public override Color? GetAlpha(Color lightColor) => new Color(98, 242, 128, 45);

    public override void AI()
	{        
        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor:new Color(98, 242, 128, 45), Scale:1.25f);
        
        Projectile.spriteDirection = Projectile.direction;
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4;
	}
    public override bool PreDraw(ref Color lightColor)
    {
        SpriteBatch spriteBatch = Main.spriteBatch;
        Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/TrueTerrabladeGlow");
        Texture2D terraTexture = TextureAssets.Projectile[Type].Value;

        Color drawColorGlowSecond = new(255, 242, 14, 42);
        Color drawColor = Projectile.GetAlpha(lightColor);

        Vector2 drawOrigin = Vector2.UnitX * glowTexture.Width;
        Vector2 terraOrigin = Vector2.UnitX * terraTexture.Width;

        SpriteEffects spriteEffects = SpriteEffects.None;
        if (Projectile.spriteDirection == -1)
        {
           // spriteEffects = SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally;
        }

        for (int i = 0; i < Projectile.oldPos.Length; i++)
        {
            Vector2 oldDrawPos = Projectile.oldPos[i] - Main.screenPosition + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY);
            drawColor *= 0.6f;

            spriteBatch.Draw(glowTexture, oldDrawPos, null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            spriteBatch.Draw(terraTexture, oldDrawPos, null, drawColor, Projectile.rotation, terraOrigin, Projectile.scale, spriteEffects, 0);
        }

        spriteBatch.Draw(terraTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlowSecond, Projectile.rotation, terraOrigin, Projectile.scale, spriteEffects, 0);
        return false;
    }
    public override void OnKill(int timeLeft)
    {        
        SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        for (int i = 0; i < 20; i++)
        {
            Dust terraDust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor:new Color(98, 242, 128, 0));
            terraDust.velocity *= 2f;
        }
        if (Projectile.ai[1] == 0f && Projectile.owner == Main.myPlayer)
        {
            Projectile.ai[1] = 1f;
            Projectile.netUpdate = true;
            for (int i = 0; i < 20; i++)
            {
                Vector2 newVelocity = (Vector2.UnitX * 8f).RotatedBy(i * MathHelper.TwoPi / 20f);
                Projectile newProj = Projectile.NewProjectileDirect(Projectile.GetSource_Death(), Projectile.position, newVelocity, ModContent.ProjectileType<TrueTerrabladeProjectile>(), Projectile.damage / 10, Projectile.knockBack, Projectile.owner, 0f, 1f);
                newProj.penetrate = 1;            
            }
        }
    }
}
