using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class GreatswordOfTheCosmosProj : SwordHoldoutProj
    {
        public override string Texture => ModContent.GetInstance<GreatswordOfTheCosmos>().Texture;
        public override float SwordSize => 100f;

        public override int ProjectileToShoot => ModContent.ProjectileType<CosmoStarProjectile>();

        public override Color TrailColor => Color.Violet;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.scale = 1.5f;
        }

        public enum SwordState : int
        {
            SwingDownwards = 0,
            SwingUpwards = 1
        }

        public SwordState SwingDirection
        {
            get => (SwordState)Projectile.ai[0];
            set => Projectile.ai[0] = (float)value;
        }

        Player Owner => Main.player[Projectile.owner];

        public override void AI()
        {
            base.AI();
            float swingDir = SwingDirection == SwordState.SwingDownwards ? 1f : -1f;
            Projectile.Center = Owner.Center;
            Projectile.timeLeft = Owner.itemAnimation;
            Projectile.scale = 1.5f + MathF.Sin(1f - Owner.itemAnimation / (float)Owner.itemAnimationMax - 0.5f);
            Projectile.rotation = Projectile.velocity.ToRotation() + (Owner.itemAnimation / (float)Owner.itemAnimationMax - 0.5f) * (swingDir * -Owner.direction * 4f - Owner.direction * 0.3f) + MathHelper.PiOver4;
            if (SwingDirection == SwordState.SwingUpwards)
            {
                Projectile.rotation -= MathHelper.PiOver4;
            }

            if (Owner.itemAnimation <= Owner.itemAnimationMax * 0.4)
            {
                Projectile.alpha += 16;
            }
            if (Owner.direction == -1)
            {
                Projectile.rotation -= MathHelper.PiOver2;
                if (SwingDirection == SwordState.SwingUpwards)
                {
                    Projectile.rotation += MathHelper.PiOver2;
                }
            }
        }

        public override void Shoot()
        {
            if (Owner.itemAnimation < Owner.itemAnimationMax * 0.333 && Main.myPlayer == Projectile.owner)
            {
                Vector2 newPosition = Owner.RotatedRelativePoint(Owner.Center);
                Vector2 mousVel = Vector2.Normalize(Main.MouseWorld - newPosition) * 12f;

                for (int i = 0; i < 3; i++)
                {
                }
                Vector2 offsetPosition = new(newPosition.X, Owner.Top.Y - Main.rand.Next(200, 400));
                Vector2 newVelocity = new(mousVel.X, Owner.HeldItem.shootSpeed * 12f);

                Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), offsetPosition, newVelocity, ProjectileToShoot, Projectile.damage, 5f, Projectile.owner);

            }
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float _ = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, Projectile.Center + Projectile.rotation.ToRotationVector2() * SwordSize * Projectile.scale, 20f, ref _);
        }

        public override void CreateDust()
        {

        }
    }
}
