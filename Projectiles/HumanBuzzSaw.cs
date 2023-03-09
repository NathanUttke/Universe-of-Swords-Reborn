using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class HumanBuzzSaw : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Human Buzz Saw");
    }

    public override void SetDefaults()
    {
        Projectile.width = 30;
        Projectile.height = 30;
        Projectile.scale = 4f;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.DamageType = DamageClass.MeleeNoSpeed;

        Projectile.ignoreWater = true;
        Projectile.friendly = true;
        Projectile.ownerHitCheck = true;
        Projectile.hide = true;

        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 15;

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
            SoundEngine.PlaySound(SoundID.Item22, Projectile.position);
        }
        
        if (Main.myPlayer == Projectile.owner && (!player.channel || !player.controlUseItem  || player.noItems || player.CCed))
        {
            Projectile.Kill();
        }

        Projectile.Center = player.MountedCenter + new Vector2(45f * player.direction, 0f);
        Projectile.position.X += player.width / 2 * player.direction;
        Projectile.spriteDirection = player.direction;

        Projectile.rotation += 0.3f * player.direction;
    }

    public override bool PreDraw(ref Color lightColor)
    {
        Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
        Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, new Vector2((float)(texture.Width / 2), (float)(texture.Height / 2)), 1f, (SpriteEffects)(Projectile.spriteDirection /*!*/= -1), 0f);
        return false;
    }
}
