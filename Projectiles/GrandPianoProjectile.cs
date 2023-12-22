using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class GrandPianoProjectile : ModProjectile
    {
        public override string Texture => "UniverseOfSwordsMod/Items/Weapons/GrandPiano";
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 142;
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
    }
}
