using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class DoubleBladedLightsaberProjectile : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Double Bladed Lightsaber");
    }

    public override void SetDefaults()
    {
        Projectile.width = 52;
        Projectile.height = 52;
        Projectile.scale = 4f;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.DamageType = DamageClass.Melee;
    }

    public override void AI()
    {
        Projectile projectile = Projectile;
        projectile.soundDelay--;
        if (Projectile.soundDelay <= 0)
        {
            SoundEngine.PlaySound(SoundID.Item15, new Vector2(Projectile.Center.X, Projectile.Center.Y));
            Projectile.soundDelay = 45;
        }
        Player player = Main.player[Projectile.owner];
        if (Main.myPlayer == Projectile.owner && (!player.channel || player.noItems || player.CCed))
        {
            Projectile.Kill();
        }
        Lighting.AddLight(Projectile.Center, 1f, 0f, 0f);
        Projectile.Center = player.MountedCenter;
        Projectile.position.X += player.width / 2 * player.direction;
        Projectile.spriteDirection = player.direction;
        Projectile projectile2 = Projectile;
        projectile2.rotation += 0.3f * (float)player.direction;
        if (Projectile.rotation > (float)Math.PI * 2f)
        {
            Projectile projectile3 = Projectile;
            projectile3.rotation -= (float)Math.PI * 2f;
        }
        else if (Projectile.rotation < 0f)
        {
            Projectile projectile4 = Projectile;
            projectile4.rotation += (float)Math.PI * 2f;
        }
        player.heldProj = Projectile.whoAmI;
        player.itemTime = 2;
        player.itemAnimation = 2;
        player.itemRotation = Projectile.rotation;
    }

    public override bool PreDraw(ref Color lightColor)
    {
        Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
        Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, (Rectangle?)null, Color.White, Projectile.rotation, new Vector2((float)(texture.Width / 2), (float)(texture.Height / 2)), 1f, (SpriteEffects)(Projectile.spriteDirection /*!*/= -1), 0f);
        return false;
    }
}
