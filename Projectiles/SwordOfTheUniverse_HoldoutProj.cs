using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{
    public class SwordOfTheUniverseHoldoutProj : BaseSpinningProj
    {
        public override string Texture => ModContent.GetInstance<SwordOfTheUniverse>().Texture;
        public override float SwordSize => 128f * Projectile.scale;
        public override float UseTime => 40f; 
        Player Owner => Main.player[Projectile.owner];

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 60;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.scale = 1.5f;
            Projectile.alpha = 0;
            Projectile.timeLeft = 40;
        }

        public override void AI()
        {
            base.AI();
            if (Projectile.ai[0] % 8f == 0f && Projectile.owner == Main.myPlayer)
            {
                Vector2 spawnPos = Owner.RotatedRelativePoint(Owner.MountedCenter);
                Vector2 spawnVelocity = Main.rand.NextVector2Unit() * 10f;

                Projectile.NewProjectile(Projectile.GetSource_FromAI(), spawnPos, spawnVelocity, ModContent.ProjectileType<SwordOfTheUniverseProjectile>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner, Main.rand.Next(0, 3));
            }

            Lighting.AddLight(Projectile.Center, Main.DiscoColor.ToVector3());
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float projRotation = Projectile.rotation - MathHelper.PiOver4 + MathHelper.Pi * Math.Sign(Projectile.velocity.X);
            float collisionPoint = 0f;
            float boxSize = 128f * Projectile.scale;

            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center + projRotation.ToRotationVector2() * -boxSize, Projectile.Center + projRotation.ToRotationVector2() * boxSize, 40f, ref collisionPoint);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = new(0f * Owner.direction, texture.Height);
            SpriteBatch spriteBatch = Main.spriteBatch;
            Color projColor = Main.DiscoColor with { A = 0 };

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                projColor *= 0.75f;
                spriteBatch.Draw(texture, Projectile.oldPos[i] - Main.screenPosition + Projectile.Size / 2f, null, projColor, Projectile.oldRot[i], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
