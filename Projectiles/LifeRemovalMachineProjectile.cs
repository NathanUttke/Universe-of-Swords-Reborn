using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{
    public class LifeRemovalMachineProjectile : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<LifeRemovalMachine>().Texture;

        const float ShootSpeed = 14f;
        const float MaxTime = 50f;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            Projectile.Size = new(128);
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            Projectile.hide = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.scale = 1.25f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 17;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float projRotation = Projectile.rotation - MathHelper.PiOver4 + MathHelper.Pi * Math.Sign(Projectile.velocity.X);
            float collisionPoint = 0f;
            float boxSize = 160f * Projectile.scale;

            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center + projRotation.ToRotationVector2() * (0f - boxSize), Projectile.Center + projRotation.ToRotationVector2() * boxSize, 40f, ref collisionPoint);
        }

        Player Owner => Main.player[Projectile.owner];

        public override void AI()
        {
            bool isInHalfMaxTime = Projectile.ai[0] == (int)(MaxTime / 2f);
            Vector2 playerCenter = Owner.RotatedRelativePoint(Owner.MountedCenter);

            if (!Owner.active || Owner.dead || Owner.noItems || Owner.CCed)
            {
                Projectile.Kill();
                return;
            }


            Vector2 velocity = Vector2.Normalize(Main.MouseWorld - playerCenter);

            Lighting.AddLight(Owner.Center, 0.8f, 0.45f, 0.1f);

            int velocityXSign = Math.Sign(Projectile.velocity.X);
            Projectile.velocity = Vector2.UnitX * velocityXSign;
            if (Projectile.ai[0] == 0f)
            {
                Projectile.rotation = new Vector2(velocityXSign, 0f - Owner.gravDir).ToRotation() - MathHelper.PiOver4 + MathHelper.Pi;
                if (Projectile.velocity.X < 0f)
                {
                    Projectile.rotation -= MathHelper.PiOver2;
                }
            }
            Projectile.ai[0] += 1f;

            // Spawn a projectile every 5 or 25 ticks

            if ((Projectile.ai[0] == 5f || Projectile.ai[0] == 25f) && Main.myPlayer == Projectile.owner)
            {
                for (int i = -1; i <= 1; i++)
                {
                    Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.ToRadians(i * 5f));
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), playerCenter, perturbedSpeed * ShootSpeed, ModContent.ProjectileType<DestroyerLaser>(), (int)(Projectile.damage * 1.5f), Projectile.knockBack, Owner.whoAmI);
                }                
                Projectile.ai[0] += 1f;
            }

            Projectile.rotation += MathHelper.TwoPi * 2f / MaxTime * velocityXSign;            
            if (Projectile.ai[0] >= MaxTime || (isInHalfMaxTime && !Owner.controlUseItem))
            {
                Projectile.Kill();
            }
            if (isInHalfMaxTime)
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
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.Pi + MathHelper.PiOver4);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = new(0f * Owner.direction, texture.Height);
            SpriteBatch spriteBatch = Main.spriteBatch;
            Color projColor = new(255, 255, 255, 127);

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                projColor *= 0.7f;
                spriteBatch.Draw(texture, Projectile.oldPos[i] - Main.screenPosition + Projectile.Size / 2f, null, projColor, Projectile.oldRot[i], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
