using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static System.Formats.Asn1.AsnWriter;

namespace UniverseOfSwordsMod.Projectiles
{
    public class ClingerSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Projectile.ownerHitCheck = true;
            Projectile.tileCollide = false;
            Projectile.hide = true;
            Projectile.aiStyle = 140;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
        }        
        public Player Owner => Main.player[Projectile.owner];
        public Vector2 velocityDirection;
        public int SwingDirection => MathF.Sign(Projectile.velocity.X);

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float collisionPoint13 = 0f;
            if (Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, Projectile.Center + (Projectile.velocity * 15f * Projectile.scale), Projectile.scale * 16f, ref collisionPoint13))
            {
                return true;
            }
            return false;
        }
        public override void AI()
        {         

            Owner.direction = SwingDirection;
            Owner.heldProj = Projectile.whoAmI;
            Owner.itemTime = Owner.itemAnimation = 2;
            Owner.itemRotation = Projectile.rotation;

            if (Main.myPlayer == Projectile.owner && (Owner.dead || !Owner.controlUseItem || Owner.noItems || Owner.CCed))
            {
                Projectile.Kill();
            }

            if (Projectile.soundDelay <= 0)
            {
                Projectile.soundDelay = 25;
                SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
            }
            Projectile.Center = Owner.Center;
            Projectile.scale = 1f + (MathF.Sin(Projectile.ai[1] / 4f) * -Owner.direction);
            Projectile.spriteDirection = Owner.direction;
            Projectile.rotation = -MathF.Sin(Projectile.ai[1] / 4f);
            if (Owner.direction < 0)
            {
                Projectile.rotation -= MathHelper.PiOver2;
            }
            //Projectile.rotation = Utils.AngleLerp(2f * SwingDirection, -2f * SwingDirection, MathF.Sin(Projectile.ai[1] / 15f)) - MathHelper.PiOver2 * SwingDirection;
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.PiOver2);
            Projectile.ai[1] += 1f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.HasBuff(BuffID.CursedInferno))
            {
                target.AddBuff(BuffID.CursedInferno, 300);
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteBatch spriteBatch = Main.spriteBatch;

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, new Vector2(0f * Main.player[Projectile.owner].direction, texture.Height), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}