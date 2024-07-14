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
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{
    public class NightmareHoldoutProj : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<TheNightmareAmalgamation>().Texture;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(90);
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.aiStyle = -1;
            Projectile.localNPCHitCooldown = 23;
            Projectile.penetrate = -1;
        }

        public Player Owner => Main.player[Projectile.owner];
        public ref float AITimer => ref Projectile.ai[0];

        public override void AI()
        {
            if (Owner.dead || Owner.noItems || Owner.CCed || !Owner.active)
            {
                Projectile.Kill();
            }

            if (!Owner.controlUseItem && AITimer >= 30f)
            {
                Projectile.Kill();
                Owner.reuseDelay = 10;
            }

            if (Projectile.soundDelay <= 0)
            {
                Projectile.soundDelay = 41;
                SoundEngine.PlaySound(SoundID.DD2_JavelinThrowersAttack with { Pitch = -0.5f }, Projectile.position);
            }

            Vector2 unitVectorTowardsMouse = Owner.MountedCenter.DirectionTo(Main.MouseWorld).SafeNormalize(Vector2.UnitX * Owner.direction);
            Owner.ChangeDir((unitVectorTowardsMouse.X > 0f).ToDirectionInt());

            Lighting.AddLight(Projectile.Center, 1f, 0.5f, 1f);

            AITimer++;
            if (AITimer % 48f == 0f && Main.myPlayer == Projectile.owner)
            {
                for (int i = -1; i <= 1; i++)
                {
                    Vector2 playerCenter = Owner.RotatedRelativePoint(Owner.Center);
                    Vector2 velocity = Vector2.Normalize(Main.MouseWorld  - playerCenter);
                    velocity = velocity.RotatedBy(MathHelper.ToRadians(15 * i));
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, velocity * 15f, ModContent.ProjectileType<NightmareProjectile>(), Projectile.damage, 4f, Projectile.owner);
                }
            }
            Projectile.scale = MathHelper.SmoothStep(1.15f, 0.75f, MathF.Sin(AITimer * 0.13f));
            Projectile.Center = Owner.Center;
            Projectile.rotation = MathHelper.Lerp(1.5f * Owner.direction, -1.5f * Owner.direction, MathF.Sin(AITimer * 0.15f)) - MathHelper.PiOver2;
            if (Owner.direction == -1)
            {
                Projectile.rotation -= MathHelper.TwoPi;
            }
            Projectile.spriteDirection = Projectile.direction;
            SetPlayerValues();
        }

        private void SetPlayerValues()
        {
            Owner.heldProj = Projectile.whoAmI;
            Owner.itemRotation = Projectile.rotation;
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.PiOver2);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Weak, 300);
            target.AddBuff(BuffID.Bleeding, 300);
            target.AddBuff(BuffID.ShadowFlame, 800);
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float collisionPoint = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Owner.Center, Owner.Center + Projectile.rotation.ToRotationVector2() * 110f * Projectile.scale, 20, ref collisionPoint);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteEffects spriteEffects = Owner.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            float projRotation = Projectile.rotation + MathHelper.PiOver4;
            Color projColor = Color.White;

            if (Owner.direction == -1)
            {
                projRotation += MathHelper.PiOver2;
            }

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                projColor *= 0.3f;
                Main.spriteBatch.Draw(texture, Owner.Center + Projectile.rotation.ToRotationVector2() * 70f - Main.screenPosition, texture.Frame(), projColor , Projectile.oldRot[i] + MathHelper.PiOver4, texture.Size() / 2, Projectile.scale - i / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }


            Main.spriteBatch.Draw(texture, Owner.Center + Projectile.rotation.ToRotationVector2() * 70f - Main.screenPosition, texture.Frame(), Color.Magenta with { A = 0 } * 0.5f, projRotation, texture.Size() / 2f, Projectile.scale * 1.2f, spriteEffects, 0);
            Main.spriteBatch.Draw(texture, Owner.Center + Projectile.rotation.ToRotationVector2() * 70f - Main.screenPosition, texture.Frame(), Color.White, projRotation, texture.Size() / 2f, Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}
