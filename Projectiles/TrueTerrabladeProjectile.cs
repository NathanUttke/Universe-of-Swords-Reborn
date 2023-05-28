using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Mono.Cecil;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace UniverseOfSwordsMod.Projectiles;

public class TrueTerrabladeProjectile : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("True Terra Blade");
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
    }
    public override void SetDefaults()
	{
		Projectile.width = 62;
		Projectile.height = 68;
		Projectile.friendly = true;
		Projectile.penetrate = 1;		
		Projectile.DamageType = DamageClass.Melee;
		Projectile.scale = 1f;
		Projectile.tileCollide = true;
		Projectile.ignoreWater = true;
		Projectile.timeLeft = 200;
		Projectile.aiStyle = ProjAIStyleID.Arrow;
        AIType = ProjectileID.Bullet;
	}

    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(98, 242, 128, 40);
    }
    public override void AI()
	{        
        int newTerraDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.TerraBlade, 0f, 0f, 127, default, 1f);
        Main.dust[newTerraDust].noGravity = true;        
        Projectile.spriteDirection = Projectile.direction;
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
	}
    public override bool PreDraw(ref Color lightColor)
    {
        SpriteBatch spriteBatch = Main.spriteBatch;
        Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/TrueTerrabladeGlow");
        Texture2D terraTexture = TextureAssets.Projectile[Type].Value;

        Color drawColorGlowSecond = new(255, 242, 14, 49);
        Vector2 drawOrigin = new(glowTexture.Width / 2, glowTexture.Height / 2);
        Vector2 terraOrigin = new(terraTexture.Width / 2, terraTexture.Height / 2);

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

            spriteBatch.Draw(glowTexture, (Projectile.oldPos[i] - Main.screenPosition) + new Vector2(Projectile.width / 2f, Projectile.height / 2f) + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale - i / (float)Projectile.oldPos.Length, spriteEffects, 0);
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

            int terraDust = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y), 8, 8, DustID.TerraBlade, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.8f);
            Main.dust[terraDust].noGravity = true;
            Dust dust = Main.dust[terraDust];
            dust.velocity *= 0.75f;

            terraDust = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y), 8, 8, DustID.TerraBlade, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.4f);
            dust = Main.dust[terraDust];
            dust.velocity *= 0.25f;
        }
        if (Projectile.ai[1] == 0)
        {
            Projectile.ai[1] = 1;
            float spread = 1.75f;
            float baseSpeed = (float)Math.Sqrt(Projectile.oldVelocity.X * Projectile.oldVelocity.X + Projectile.oldVelocity.Y * Projectile.oldVelocity.Y);
            double startAngle = Math.Atan2(Projectile.oldVelocity.X, Projectile.oldVelocity.Y) - (double)(spread / 2f);
            double deltaAngle = spread / 2f;
            for (int i = 0; i < 20; i++)
            {
                double offsetAngle = startAngle + deltaAngle * i;
                Projectile.NewProjectileDirect(Projectile.GetSource_Death(), Projectile.position, new Vector2(baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle)), ModContent.ProjectileType<TrueTerrabladeProjectile>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Main.myPlayer, 0f, 1f);
            }
        }
    }
}
