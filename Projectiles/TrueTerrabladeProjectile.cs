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
	}

    public override Color? GetAlpha(Color lightColor) => new Color(98, 242, 128, 45);

    public override void AI()
	{        
        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(98, 242, 128, 45), 1f);
        
        Projectile.spriteDirection = Projectile.direction;
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
	}
    public override bool PreDraw(ref Color lightColor)
    {
        SpriteBatch spriteBatch = Main.spriteBatch;
        Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/TrueTerrabladeGlow");
        Texture2D terraTexture = TextureAssets.Projectile[Type].Value;

        Color drawColorGlowSecond = new(255, 242, 14, 42);
        Vector2 drawOrigin = glowTexture.Size() / 2f;
        Vector2 terraOrigin = terraTexture.Size() / 2f;

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
    public override void Kill(int timeLeft)
    {        
        SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        for (int i = 4; i < 31; i++)
        {

            int terraDust = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X, Projectile.velocity.Y, 100, new Color(98, 242, 128, 0), 2f);
            Dust dust = Main.dust[terraDust];
            dust.velocity *= 0.75f;

            terraDust = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X, Projectile.velocity.Y, 100, new Color(98, 242, 128, 0), 2f);
            Dust dust2 = Main.dust[terraDust];
            dust2.velocity *= 0.25f;
        }
        if (Projectile.ai[1] == 0f)
        {
            Projectile.ai[1] = 1f;
            float spread = 1.75f;
            float baseSpeed = Projectile.oldVelocity.Length();
            float startAngle = Projectile.oldVelocity.ToRotation() - spread / 2f;
            float deltaAngle = spread / 2f;
            for (int i = 0; i < 20; i++)
            {
                float offsetAngle = startAngle + deltaAngle * i;
                Projectile.NewProjectileDirect(Projectile.GetSource_Death(), Projectile.position, new Vector2(baseSpeed * MathF.Sin(offsetAngle), baseSpeed * MathF.Cos(offsetAngle)), ModContent.ProjectileType<TrueTerrabladeProjectile>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner, 0f, 1f);
            }
        }
    }
}
