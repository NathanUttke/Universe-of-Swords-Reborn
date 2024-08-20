using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{
    public class GnomBladeHoldoutProj : SwordHoldoutProj
    {
        public override string Texture => ModContent.GetInstance<GnomBlade>().Texture;
        public override float SwordSize => 90f;

        public override int ProjectileToShoot => ModContent.ProjectileType<GnomeProj>(); 

        public override Color TrailColor => Color.Cyan;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.extraUpdates = 1;
            Projectile.scale = 1.5f;
        }

        Player Owner => Main.player[Projectile.owner];

        public override void AI()
        {
            base.AI();
            //Projectile.scale = 0.5f + MathF.Sin(Timer * 0.1f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.SmoothStep(-1.75f, 1.75f, RotationTimer / 8f) * Owner.direction;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float _ = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, Projectile.Center + Projectile.rotation.ToRotationVector2() * SwordSize * Projectile.scale, 20f, ref _);
        }

        public override void CreateDust()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDustDirect(Projectile.position + Projectile.rotation.ToRotationVector2() * SwordSize * Projectile.scale, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor:Color.Cyan);
                Dust.NewDustDirect(Projectile.position + Projectile.rotation.ToRotationVector2() * SwordSize * Projectile.scale, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor:Color.Red);
            }
        }

        public override void SetPlayerValues()
        {
            Owner.heldProj = Projectile.whoAmI;
            Owner.itemRotation = Projectile.rotation;
            Owner.SetDummyItemTime(2);
        }
    }
}
