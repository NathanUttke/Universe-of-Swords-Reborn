using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using UniverseOfSwordsMod.Buffs;

namespace UniverseOfSwordsMod.Projectiles
{
    public class SwordOfTheMultiverseProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 94;
            Projectile.height = 94;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
            Projectile.scale = 1.1f;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;

            Rectangle sourceRectangle = new(0, startY, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;

            float offsetX = 20f;
            origin.X = Projectile.spriteDirection == -1 ? sourceRectangle.Width - offsetX : offsetX;


            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {     
                Color drawColor2 = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
                drawColor2 *= (8 - i) / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
                Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, drawColor2, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, (SpriteEffects)(Projectile.spriteDirection /*!*/= -1), 0f);
            }            
            return true;
        }
        public override void AI()
        { 
            base.AI();
            Projectile.rotation += 0.5f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] > 30f)
            {
                if (Projectile.ai[0] < 100f)
                {
                    Projectile.velocity *= 1.07f;
                }
                else
                {
                    Projectile.ai[0] = 200f;
                }
            }
            if (Main.rand.NextBool(3))
            {
                Dust swordDust = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.DemonTorch, Projectile.velocity.X, Projectile.velocity.Y, 0, default, 1.5f)];
                swordDust.noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[Projectile.owner];       

            for (int i = 0; i < 12; i++)
            {
                float screenPosX = Main.screenPosition.X;
                float screenPosY = Main.screenPosition.Y;
                if (player.direction < 0)
                {
                    screenPosX += Main.screenWidth + Utils.SelectRandom(Main.rand, -Main.screenWidth, 0, -Main.screenWidth, Main.screenWidth); 
                }
                else
                {
                    screenPosX += Utils.SelectRandom(Main.rand, Main.screenWidth, 0, Main.screenWidth, -Main.screenWidth);
                }
                screenPosY += Main.rand.Next(Main.screenHeight);
                Vector2 screenPositionVec = new(screenPosX, screenPosY);
                float targetPosPlusScreenX = target.Center.X - screenPositionVec.X;
                float targetPosPlusScreenY = target.Center.Y - screenPositionVec.Y;
                targetPosPlusScreenX += Main.rand.Next(-100, 101) * 0.15f;
                targetPosPlusScreenY += Main.rand.Next(-100, 101) * 0.15f;
                float targetPosition = (float)Math.Sqrt(targetPosPlusScreenX * targetPosPlusScreenX + targetPosPlusScreenY * targetPosPlusScreenY);
                targetPosition = 72f / targetPosition;
                targetPosPlusScreenX *= targetPosition;
                targetPosPlusScreenY *= targetPosition;
                Projectile.NewProjectileDirect(Projectile.GetSource_OnHit(target), new Vector2(screenPosX, screenPosY), new Vector2(targetPosPlusScreenX, targetPosPlusScreenY), ModContent.ProjectileType<SwordOfTheMultiverseProjectileSmall>(), 45, 4f, player.whoAmI);
            }

            if (!target.HasBuff(ModContent.BuffType<EmperorBlaze>()))
            {
                target.AddBuff(ModContent.BuffType<EmperorBlaze>(), 300, true);
            }
        }
    }    
}
