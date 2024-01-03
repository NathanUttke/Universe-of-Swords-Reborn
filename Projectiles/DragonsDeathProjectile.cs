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
        public override void AI()
        {
            float useTime = 50f; 
            Player player = Main.player[Projectile.owner];
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter);
            if (player.dead)
            {
                Projectile.Kill();
                return;
            }

            Lighting.AddLight(player.Center, 0.75f, 0.9f, 1.15f);
            int velocityXSign = Math.Sign(Projectile.velocity.X);
            Projectile.velocity = new Vector2(velocityXSign, 0f);
            if (Projectile.ai[0] == 0f)
            {
                Projectile.rotation = new Vector2(velocityXSign, 0f - player.gravDir).ToRotation() + -MathHelper.PiOver4 + MathHelper.Pi;
                if (Projectile.velocity.X < 0f)
                {
                    Projectile.rotation -= (float)Math.PI / 2f;
                }
            }
            Projectile.alpha -= 128;
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
            //_ = Projectile.ai[0] / useTime;
            Projectile.ai[0] += 1f;
            Projectile.rotation += MathHelper.TwoPi * 2f / useTime * velocityXSign;
            bool halfUseTime = Projectile.ai[0] == (int)(useTime / 2f);
            if (Projectile.ai[0] >= useTime || (halfUseTime && !player.controlUseItem))
            {
                Projectile.Kill();
                player.reuseDelay = 2;
            }
            else if (halfUseTime)
            {
                Vector2 mousePosition = Main.MouseWorld;
                int mouseDirection = ((player.DirectionTo(mousePosition).X > 0f) ? 1 : (-1));
                if (mouseDirection != Projectile.velocity.X)
                {
                    player.ChangeDir(mouseDirection);
                    Projectile.velocity = new Vector2(mouseDirection, 0f);
                    Projectile.netUpdate = true;
                    Projectile.rotation -= MathHelper.Pi;
                }
            }
            if ((Projectile.ai[0] == 1f || (Projectile.ai[0] == (int)(useTime / 2f) && Projectile.active)) && Projectile.owner == Main.myPlayer)
            {
                Vector2 mouseWorld3 = Main.MouseWorld;
                _ = player.DirectionTo(mouseWorld3) * 0f;
            }       

            Projectile.position = vector - Projectile.Size / 2f;
            Projectile.Center = player.Center;
            Projectile.spriteDirection = Projectile.direction;
            Projectile.timeLeft = 2;

            player.ChangeDir(Projectile.direction);
            player.heldProj = Projectile.whoAmI;
            player.SetDummyItemTime(2);
            player.itemRotation = MathHelper.WrapAngle(Projectile.rotation);
            player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.PiOver2);
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
