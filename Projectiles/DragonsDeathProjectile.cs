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

            if (Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center + projRotation.ToRotationVector2() * (0f - boxSize), Projectile.Center + projRotation.ToRotationVector2() * boxSize, 40f * Projectile.scale, ref collisionPoint))
            {
                return true;
            }

            return false;
        }

        private const float UseTime = 50f;
        Player Owner => Main.player[Projectile.owner];
        public override void AI()
        {            
            
            Vector2 vector = Owner.RotatedRelativePoint(Owner.MountedCenter);
            if (Owner.dead || Owner.CCed || Owner.noItems || !Owner.active)
            {
                Projectile.Kill();
                return;
            }

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

            Projectile.position = vector - Projectile.Size / 2f;
            Projectile.Center = Owner.Center;
            Projectile.spriteDirection = Projectile.direction;
            Projectile.timeLeft = 2;

            Owner.ChangeDir(Projectile.direction);
            Owner.heldProj = Projectile.whoAmI;
            Owner.SetDummyItemTime(2);
            Owner.itemRotation = MathHelper.WrapAngle(Projectile.rotation);
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.PiOver2);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteBatch spriteBatch = Main.spriteBatch;

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, new Vector2(0f * Owner.direction, texture.Height), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
