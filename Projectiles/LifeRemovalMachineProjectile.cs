﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Mono.Cecil;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class LifeRemovalMachineProjectile : ModProjectile
    {
        public override string Texture => "UniverseOfSwordsMod/Items/Weapons/LifeRemovalMachine";

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

        private readonly float shootSpeed = 30f;
        private const float maxTime = 50f;
        public override void AI()
        {

            Player player = Main.player[Projectile.owner];
            Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter);

            Vector2 velocity = new(Main.mouseX + Main.screenPosition.X - playerCenter.X, Main.mouseY + Main.screenPosition.Y - playerCenter.Y);
            velocity.Normalize();


            if (player.dead)
            {
                Projectile.Kill();
                return;
            }

            Lighting.AddLight(player.Center, 0.8f, 0.45f, 0.1f);

            int velocityXSign = Math.Sign(Projectile.velocity.X);
            Projectile.velocity = new Vector2(velocityXSign, 0f);
            if (Projectile.ai[0] == 0f)
            {
                Projectile.rotation = new Vector2(velocityXSign, 0f - player.gravDir).ToRotation() + -MathHelper.PiOver4 + MathHelper.Pi;
                if (Projectile.velocity.X < 0f)
                {
                    Projectile.rotation -= MathHelper.PiOver2;
                }
            }
            Projectile.ai[0] += 1f;

            // Spawn a projectile every 5 ticks

            if (Projectile.ai[0] == 5f || Projectile.ai[0] == 25f)
            {
                float numberProjectiles = 3;
                float rotation = MathHelper.ToRadians(10f);
                playerCenter += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 4f;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = Utils.RotatedBy(velocity, (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.25f;
                    Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), playerCenter, perturbedSpeed * shootSpeed, ProjectileID.DeathLaser, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    proj.DamageType = DamageClass.Melee;
                    proj.timeLeft = 80;
                    proj.usesLocalNPCImmunity = true;
                    proj.localNPCHitCooldown = 20;
                    proj.hostile = false;
                    proj.friendly = true;
                }                
                Projectile.ai[0] += 1f;
            }

            Projectile.rotation += MathHelper.TwoPi * 2f / maxTime * velocityXSign;
            bool isInHalfMaxTime = Projectile.ai[0] == (int)(maxTime / 2f);
            if (Projectile.ai[0] >= maxTime || (isInHalfMaxTime && !player.controlUseItem))
            {
                Projectile.Kill();
            }
            else if (isInHalfMaxTime)
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

            Projectile.position = playerCenter - Projectile.Size / 2f;
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