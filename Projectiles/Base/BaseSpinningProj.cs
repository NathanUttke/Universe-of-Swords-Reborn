using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{
    public class BaseSpinningProj : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<DragonsDeath>().Texture;

        public override void SetDefaults()
        {
            Projectile.Size = new(128);
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.hide = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.scale = 1.25f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
            Projectile.timeLeft = 50;
        }

        public virtual float SwordSize => 160f;
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float projRotation = Projectile.rotation - MathHelper.PiOver4 + MathHelper.Pi * Math.Sign(Projectile.velocity.X);
            float collisionPoint = 0f;
            float boxSize = SwordSize * Projectile.scale;

            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center + projRotation.ToRotationVector2() * -boxSize, Projectile.Center + projRotation.ToRotationVector2() * boxSize, 40f, ref collisionPoint);
        }

        public virtual float UseTime => 50f;
        Player Owner => Main.player[Projectile.owner];
        public override void AI()
        {
            if (!Owner.active || Owner.dead || Owner.CCed || Owner.noItems)
            {
                Projectile.Kill();
                return;
            }

            int velocityXSign = Math.Sign(Projectile.velocity.X);            
            
            Projectile.velocity = new Vector2(velocityXSign, 0f);
            if (Projectile.ai[0] == 0f)
            {
                Projectile.rotation = new Vector2(velocityXSign, -Owner.gravDir).ToRotation() + -MathHelper.PiOver4 + MathHelper.Pi;
                if (Projectile.velocity.X < 0f)
                {
                    Projectile.rotation -= MathHelper.PiOver2;
                }
            }
            
            Projectile.ai[0] += 1f;
            Projectile.rotation += MathHelper.TwoPi * 2f / UseTime * velocityXSign;
            Projectile.Center = Owner.RotatedRelativePoint(Owner.MountedCenter);

            SetPlayerValues();
        }

        public void SetPlayerValues()
        {
            Projectile.spriteDirection = Projectile.direction;
            Owner.ChangeDir(Projectile.direction);
            Owner.heldProj = Projectile.whoAmI;
            Owner.itemRotation = MathHelper.WrapAngle(Projectile.rotation);
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.Pi + MathHelper.PiOver4);
        }
    }
}
