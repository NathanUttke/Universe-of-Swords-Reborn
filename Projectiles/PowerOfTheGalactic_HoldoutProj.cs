using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{
    public class PowerOfTheGalacticProj : SwordHoldoutProj
    {
        public override string Texture => ModContent.GetInstance<PowerOfTheGalactic>().Texture;
        public override float SwordSize => 90f;

        public override int ProjectileToShoot => ModContent.ProjectileType<GalacticProjectile>();

        public override Color TrailColor => Color.Cyan;

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
            Projectile.scale = 1.5f - MathF.Sin(1f - Owner.itemAnimation / (float)Owner.itemAnimationMax - 0.5f);
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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 300);
        }

        public override void Shoot()
        {
            if (Owner.ItemAnimationEndingOrEnded && Main.myPlayer == Projectile.owner && Projectile.ai[1] == 0f)
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector2 newPosition = Owner.RotatedRelativePoint(Owner.Center);
                    Vector2 newVelocity = Vector2.Normalize(Main.MouseWorld - newPosition) * 12f * Main.rand.NextFloat(1f, 1.5f);
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), newPosition + newVelocity * 4f, newVelocity.RotatedByRandom(MathHelper.ToRadians(45f)), ProjectileToShoot, Projectile.damage / 2, Projectile.knockBack, Owner.whoAmI);
                }
                Projectile.ai[1] = 1f;
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
