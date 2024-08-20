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
    public override string Texture => ModContent.GetInstance<Items.Weapons.HumanBuzzSaw>().Texture;

    public override void SetDefaults()
    {
        Projectile.Size = new(102);
        Projectile.scale = 1f;
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

    Player Owner => Main.player[Projectile.owner];

    public override void AI()
    {
        if (!Owner.channel || !Owner.controlUseItem || Owner.noItems || Owner.CCed)
        {
            Projectile.Kill();
        }

        SetPlayerValues();

        if (Projectile.soundDelay <= 0)
        {
            Projectile.soundDelay = 30;
            SoundEngine.PlaySound(SoundID.Item22, Projectile.position);
        }       

        Vector2 unitVectorTowardsMouse = Owner.MountedCenter.DirectionTo(Main.MouseWorld);
        Owner.ChangeDir((unitVectorTowardsMouse.X > 0f).ToDirectionInt());

        Projectile.Center = Owner.RotatedRelativePoint(Owner.Center, true);
        Projectile.velocity = unitVectorTowardsMouse;
        Projectile.position.X += Owner.width / 2 * Owner.direction;
        Projectile.spriteDirection = Owner.direction;

        Projectile.rotation += 0.3f * Owner.direction;

        Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 8f * Projectile.direction, Alpha: 100);
    }

    private void SetPlayerValues()
    {
        Owner.heldProj = Projectile.whoAmI;
        Owner.SetDummyItemTime(2);
        Owner.itemTime = Owner.itemAnimation = 2;
        Owner.itemRotation = Projectile.rotation;
    }

    public override bool PreDraw(ref Color lightColor)
    {
        Texture2D texture = TextureAssets.Projectile[Type].Value;
        Color drawColor = Projectile.GetAlpha(lightColor);
        Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, drawColor, Projectile.rotation, texture.Size() / 2f, Projectile.scale, SpriteEffects.None, 0f);
        return false;
    }
}
