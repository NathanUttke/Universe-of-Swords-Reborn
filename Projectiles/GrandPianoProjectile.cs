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
    public class GrandPianoProjectile : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<GrandPiano>().Texture;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.Size = new(142);
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
            Projectile.light = 0.33f;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[1] += 1f;
                if (Projectile.ai[1] >= 30f)
                {
                    Projectile.ai[0] = 1f;
                    Projectile.ai[1] = 0f;
                    Projectile.netUpdate = true;
                }
            }
            else
            {
                float acceleration = 2f; 
                Vector2 playerProjCenterDistance = owner.Center - Projectile.Center;                
                float playerProjDistance = Vector2.Distance(owner.Center, Projectile.Center);

                if (playerProjDistance > 3000f)
                {
                    Projectile.Kill();
                }          
                
                playerProjDistance = 15f / playerProjDistance;
                playerProjCenterDistance.X *= playerProjDistance;
                playerProjCenterDistance.Y *= playerProjDistance;

                if (Projectile.velocity.X < playerProjCenterDistance.X)
                {
                    Projectile.velocity.X += acceleration;
                    if (Projectile.velocity.X < 0f && playerProjCenterDistance.X > 0f)
                    {
                        Projectile.velocity.X += acceleration;
                    }
                }
                else if (Projectile.velocity.X > playerProjCenterDistance.X)
                {
                    Projectile.velocity.X -= acceleration;
                    if (Projectile.velocity.X > 0f && playerProjCenterDistance.X < 0f)
                    {
                        Projectile.velocity.X -= acceleration;
                    }
                }
                if (Projectile.velocity.Y < playerProjCenterDistance.Y)
                {
                    Projectile.velocity.Y += acceleration;
                    if (Projectile.velocity.Y < 0f && playerProjCenterDistance.Y > 0f)
                    {
                        Projectile.velocity.Y += acceleration;
                    }
                }
                else if (Projectile.velocity.Y > playerProjCenterDistance.Y)
                {
                    Projectile.velocity.Y -= acceleration;
                    if (Projectile.velocity.Y > 0f && playerProjCenterDistance.Y < 0f)
                    {
                        Projectile.velocity.Y -= acceleration;
                    }
                }

                if (Main.myPlayer == Projectile.owner)
                {
                    if (Projectile.Hitbox.Intersects(owner.Hitbox))
                    {
                        Projectile.Kill();
                    }
                }
            }

            Lighting.AddLight(Projectile.position, 0.25f, 0.25f, 0.25f);
            Projectile.rotation += 0.25f * Projectile.direction;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = texture.Size() / 2f;
            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                if (j % 3 != 0)
                {
                    continue;                    
                }

                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);

                Color color = Projectile.GetAlpha(lightColor);
                color *= 0.25f;

                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            return true;
        }
    }
}
