﻿
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.Graphics.Shaders;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class ScarletGreatswordProjectile : DragonsDeathProjectile
    {
        public override string Texture => "UniverseOfSwordsMod/Items/Weapons/ScarletFlareGreatsword";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 4;
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
            Projectile.scale = 1f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 18;
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

        private readonly float shootSpeed = 25f;
        private const float maxTime = 40f;
        Player Owner => Main.player[Projectile.owner];
        public override void AI()
        {
            
            Vector2 playerCenter = Owner.RotatedRelativePoint(Owner.MountedCenter);

            if (!Owner.active || Owner.dead || Owner.noItems || Owner.CCed)
            {
                Projectile.Kill();
                return;
            }          
            

            // Get the cursor's position

            Vector2 velocity = new(Main.mouseX + Main.screenPosition.X - playerCenter.X, Main.mouseY + Main.screenPosition.Y - playerCenter.Y);
            velocity.Normalize();

            Lighting.AddLight(Owner.Center, 0.8f, 0.45f, 0.1f);

            int velocityXSign = Math.Sign(Projectile.velocity.X);
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

            // Spawn a projectile every 8 ticks

            if (Projectile.ai[0] == 8f && Main.myPlayer == Projectile.owner)
            {                
                Projectile.NewProjectile(Projectile.GetSource_FromAI(), playerCenter, velocity * shootSpeed, ModContent.ProjectileType<FlareCore>(), (int)(Projectile.damage * 2f), Projectile.knockBack, Owner.whoAmI);
                Projectile.ai[0] += 1f;
            }

            Projectile.rotation += MathHelper.TwoPi * 2f / maxTime * velocityXSign;
            bool halfUseTime = Projectile.ai[0] == (int)(maxTime / 2f);
            if (Projectile.ai[0] >= maxTime || (halfUseTime && !Owner.controlUseItem))
            {
                Projectile.Kill();
            }
            else if (halfUseTime)
            {
                Vector2 mousePosition = Main.MouseWorld;
                int mouseDirection = ((Owner.DirectionTo(mousePosition).X > 0f) ? 1 : (-1));
                if (mouseDirection != Projectile.velocity.X)
                {
                    Owner.ChangeDir(mouseDirection);
                    Projectile.velocity = new Vector2(mouseDirection, 0f);
                    Projectile.netUpdate = true;
                    Projectile.rotation -= MathHelper.Pi;
                }
            }

            Projectile.position = playerCenter - Projectile.Size / 2f;
            Projectile.Center = Owner.Center;
            
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
            SpriteBatch spriteBatch = Main.spriteBatch;

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, new Vector2(0f * Main.player[Projectile.owner].direction, texture.Height), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
