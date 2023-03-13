using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Peripherals.RGB;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class DoubleBladedLightsaberProjectile : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Double Bladed Lightsaber");
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void SetDefaults()
    {
        Projectile.width = 207;
        Projectile.height = 207;
        Projectile.scale = 1.5f;
        Projectile.alpha = 0;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 8;
        Projectile.aiStyle = -1;
    }

    public override void AI()
    {
        Player player = Main.player[Projectile.owner];

        player.heldProj = Projectile.whoAmI;
        player.itemTime = player.itemAnimation = 2;
        player.itemRotation = Projectile.rotation;

        if (Projectile.soundDelay <= 0)
        {
            Projectile.soundDelay = 30;
            SoundEngine.PlaySound(SoundID.Item15, Projectile.Center);
        }

        if (Main.myPlayer == Projectile.owner && (!player.channel || !player.controlUseItem || player.noItems || player.CCed))
        {
            Projectile.Kill();
        }
 

        Dust newDust = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, Projectile.velocity.X, Projectile.velocity.Y, 0, default, 1.5f)];
        newDust.fadeIn = 1.5f;
        Lighting.AddLight(Projectile.Center, 1.1f, 0.3f, 0.4f);

        Projectile.Center = player.MountedCenter;
        Projectile.position.X += player.width / 2 * player.direction;
        Projectile.spriteDirection = player.direction;

        Projectile.rotation += 0.3f * player.direction;
    }
    // Color(220, 40, 30, 200)
    public override Color? GetAlpha(Color lightColor) => new Color(220, 40, 30, 0) * Projectile.Opacity;

    public override bool PreDraw(ref Color lightColor)
    {

        Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

        for (int i = 0; i < 8; i++)        
        {

            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
            Color drawColor = Projectile.GetAlpha(lightColor);
            drawColor *= (8 - i) / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, drawColor, Projectile.rotation * .99f, new Vector2(texture.Width / 2, texture.Height / 2), MathHelper.Lerp(Projectile.scale, 1f, (float)i / 15f), SpriteEffects.None, 0);
        }
        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
        Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0);
        return false;
    }


}
