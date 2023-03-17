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
        Projectile.scale = 2f;
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

        double rad = Projectile.ai[0] * (Math.PI / 180.0);
        double distance = 48.0;

        Projectile.position = new Vector2(player.Center.X - (int)(Math.Cos(rad) * distance) - Projectile.width / 2, player.Center.Y - (int)(Math.Sin(rad) * distance) - Projectile.height / 2);

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
        Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), Projectile.scale, SpriteEffects.None, 0);
        return false;
    }


}
