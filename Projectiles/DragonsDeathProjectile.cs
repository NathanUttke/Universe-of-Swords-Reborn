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
    internal class DragonsDeathProjectile : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<DragonsDeath>().Texture;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.hide = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float projRotation = Projectile.rotation - MathHelper.PiOver4 + MathHelper.Pi * Math.Sign(Projectile.velocity.X);
            float collisionPoint = 0f;
            float boxSize = 160f;

            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center + projRotation.ToRotationVector2() * (0f - boxSize), Projectile.Center + projRotation.ToRotationVector2() * boxSize, 40f * Projectile.scale, ref collisionPoint);
        }

        private const float UseTime = 50f;
        Player Owner => Main.player[Projectile.owner];
        public override void AI()
        {            
            if (Owner.dead || Owner.CCed || Owner.noItems || !Owner.active)
            {
                Projectile.Kill();
                return;
            }

            Vector2 vector = Owner.RotatedRelativePoint(Owner.MountedCenter);
            int velocityXSign = Math.Sign(Projectile.velocity.X);

            Lighting.AddLight(Owner.Center, 0.75f, 0.9f, 1.15f);
            
            Projectile.velocity = new Vector2(velocityXSign, 0f);
            if (Projectile.ai[0] == 0f)
            {
                Projectile.rotation = new Vector2(velocityXSign, 0f - Owner.gravDir).ToRotation() + -MathHelper.PiOver4 + MathHelper.Pi;
                if (Projectile.velocity.X < 0f)
                {
                    Projectile.rotation -= MathHelper.PiOver2;
                }
            }
            
            Projectile.ai[0] += 1f;
            Projectile.rotation += MathHelper.TwoPi * 2f / UseTime * velocityXSign;
            bool halfUseTime = Projectile.ai[0] == (int)(UseTime / 2f);
            if (Projectile.ai[0] >= UseTime || (halfUseTime && !Owner.controlUseItem))
            {
                Projectile.Kill();                
            }
            else if (halfUseTime)
            {
                Vector2 mousePosition = Main.MouseWorld;
                int mouseDirection = (Owner.DirectionTo(mousePosition).X > 0f) ? 1 : (-1);
                if (mouseDirection != Projectile.velocity.X)
                {
                    Owner.ChangeDir(mouseDirection);
                    Projectile.velocity = new Vector2(mouseDirection, 0f);
                    Projectile.netUpdate = true;
                    Projectile.rotation -= MathHelper.Pi;
                }
            }

            //Projectile.position = vector - Projectile.Size / 2f;
            //Projectile.Center = Owner.Center;
            Projectile.Center = Owner.MountedCenter;
            Projectile.timeLeft = 2;

            SetPlayerValues();
        }

        public void SetPlayerValues()
        {
            Projectile.spriteDirection = Projectile.direction;
            Owner.ChangeDir(Projectile.direction);
            Owner.heldProj = Projectile.whoAmI;
            Owner.SetDummyItemTime(2);
            Owner.itemRotation = MathHelper.WrapAngle(Projectile.rotation);
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.PiOver2);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = new(0f * Owner.direction, texture.Height);
            SpriteBatch spriteBatch = Main.spriteBatch;
            Color projColor = new(255, 255, 255, 0);

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                projColor *= 0.7f;
                spriteBatch.Draw(texture, Projectile.oldPos[i] - Main.screenPosition , null, projColor, Projectile.oldRot[i], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
