using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
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
            Projectile.scale = 0.5f + MathF.Sin(Timer * 0.1f);
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
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Cyan, 1f);
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Red, 1f);
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
