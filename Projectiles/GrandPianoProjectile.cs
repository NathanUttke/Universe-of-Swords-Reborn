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
            Projectile.light = 0.33f;
        }

        public override void AI()
        {
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
                float acceleration = 3f;
                Vector2 vector6 = new(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                float playerWidthPosX = Main.player[Projectile.owner].position.X + (Main.player[Projectile.owner].width / 2) - vector6.X;
                float playerHeightPosY = Main.player[Projectile.owner].position.Y + (Main.player[Projectile.owner].height / 2) - vector6.Y;
                float num64 = (float)Math.Sqrt(playerWidthPosX * playerWidthPosX + playerHeightPosY * playerHeightPosY);
                if (num64 > 3000f)
                {
                    Projectile.Kill();
                }
                num64 = 15f / num64;
                playerWidthPosX *= num64;
                playerHeightPosY *= num64;

                if (Projectile.velocity.X < playerWidthPosX)
                {
                    Projectile.velocity.X += acceleration;
                    if (Projectile.velocity.X < 0f && playerWidthPosX > 0f)
                    {
                        Projectile.velocity.X += acceleration;
                    }
                }
                else if (Projectile.velocity.X > playerWidthPosX)
                {
                    Projectile.velocity.X -= acceleration;
                    if (Projectile.velocity.X > 0f && playerWidthPosX < 0f)
                    {
                        Projectile.velocity.X -= acceleration;
                    }
                }
                if (Projectile.velocity.Y < playerHeightPosY)
                {
                    Projectile.velocity.Y += acceleration;
                    if (Projectile.velocity.Y < 0f && playerHeightPosY > 0f)
                    {
                        Projectile.velocity.Y += acceleration;
                    }
                }
                else if (Projectile.velocity.Y > playerHeightPosY)
                {
                    Projectile.velocity.Y -= acceleration;
                    if (Projectile.velocity.Y > 0f && playerHeightPosY < 0f)
                    {
                        Projectile.velocity.Y -= acceleration;
                    }
                }

                if (Main.myPlayer == Projectile.owner)
                {
                    Rectangle rectangle = new((int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height);
                    Rectangle value = new((int)Main.player[Projectile.owner].position.X, (int)Main.player[Projectile.owner].position.Y, Main.player[Projectile.owner].width, Main.player[Projectile.owner].height);
                    if (rectangle.Intersects(value))
                    {
                        Projectile.Kill();
                    }
                }
            }

            Lighting.AddLight(Projectile.position, 0.25f, 0.25f, 0.25f);
            Projectile.rotation += 0.4f * Projectile.direction;
        }
    }
}
