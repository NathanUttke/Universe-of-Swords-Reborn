
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
    public class ScarletGreatswordProjectile : BaseSpinningProj
    {
        public override string Texture => ModContent.GetInstance<ScarletFlareGreatsword>().Texture;
        public override float UseTime => 40f;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 60;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(120);
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.hide = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.scale = 1.25f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 18;
            Projectile.timeLeft = 40;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float projRotation = Projectile.rotation - MathHelper.PiOver4 + MathHelper.Pi * Math.Sign(Projectile.velocity.X);
            float collisionPoint = 0f;
            float boxSize = 160f * Projectile.scale;

            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center + projRotation.ToRotationVector2() * -boxSize, Projectile.Center + projRotation.ToRotationVector2() * boxSize, 40f, ref collisionPoint);
        }

        Player Owner => Main.player[Projectile.owner];
        public override void AI()
        {      
            base.AI();
            Vector2 playerCenter = Owner.RotatedRelativePoint(Owner.MountedCenter);        

            // Get the cursor's position
            Vector2 velocity = Vector2.Normalize(Main.MouseWorld - playerCenter);

            Lighting.AddLight(Owner.Center, 0.8f, 0.45f, 0.1f);

            // Spawn a projectile every 8 ticks
            Projectile.ai[0]++;
            if (Projectile.ai[0] == 8f && Main.myPlayer == Projectile.owner)
            {
                Projectile.netUpdate = true;
                Projectile.NewProjectile(Projectile.GetSource_FromAI(), playerCenter, velocity * Owner.inventory[Owner.selectedItem].shootSpeed, ModContent.ProjectileType<FlareCore>(), (int)(Projectile.damage * 2f), Projectile.knockBack, Owner.whoAmI);
                Projectile.ai[0]++;
            }

            SetPlayerValues();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.myPlayer != Projectile.owner)
            {
                return;
            }

            if (!target.active || target.immortal || NPCID.Sets.CountsAsCritter[target.type] || target.SpawnedFromStatue)
            {
                return;
            }

            if (Owner.GetModPlayer<UniversePlayer>().swordTimer == 0)
            {
                Owner.GetModPlayer<UniversePlayer>().swordTimer = 20;
            }
            else
            {
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                Vector2 offsetPosition = new(target.position.X + Main.rand.Next(-800, 800), target.position.Y + Main.rand.Next(600, 900));
                Vector2 spawnVelocity = Vector2.Normalize(target.Center - offsetPosition) * 30f;

                Projectile.NewProjectileDirect(Projectile.GetSource_OnHit(target), offsetPosition, spawnVelocity, ModContent.ProjectileType<ScarletRedBolt>(), Projectile.damage / 2, 5f, Projectile.owner, 0f, 0f);
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = new(0f * Owner.direction, texture.Height);
            SpriteBatch spriteBatch = Main.spriteBatch;
            Color projColor = Color.Salmon with { A = 0 };

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                projColor *= 0.75f;
                spriteBatch.Draw(texture, Projectile.oldPos[i] - Main.screenPosition + Projectile.Size / 2f, null, projColor * 2f, Projectile.oldRot[i], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
