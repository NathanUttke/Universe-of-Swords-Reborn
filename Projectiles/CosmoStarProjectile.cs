using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using UniverseOfSwordsMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace UniverseOfSwordsMod.Projectiles
{
    public class CosmoStarProjectile : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.Starfury}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 24;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.timeLeft = 100;
            Projectile.localNPCHitCooldown = 20;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[0] = 1f;
                for (int i = 0; i < 16; i++)
                {
                    Vector2 spinPoint = -Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 16f) * new Vector2(4f, 16f);
                    spinPoint = spinPoint.RotatedBy(Projectile.velocity.ToRotation());
                    Dust ringDust = Dust.NewDustDirect(Projectile.position, 1, 1, DustID.Clentaminator_Cyan);
                    ringDust.noGravity = true;
                    ringDust.position = Projectile.Center + spinPoint;
                    ringDust.velocity = spinPoint.SafeNormalize(Vector2.UnitY) * 2f;                  
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, 1, 1, DustID.Clentaminator_Cyan, Scale:0.6f);
                dust.noGravity = true;
                dust.position = Projectile.Center - Projectile.velocity / 10f * i;
                dust.velocity *= 0f;
                dust.rotation = dust.velocity.ToRotation();
            }

            Projectile.rotation += Projectile.direction * 0.4f; 
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[ProjectileID.Starfury].Value;
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");

            SpriteBatch spriteBatch = Main.spriteBatch;
            Color drawColor = Color.Cyan with { A = 0 };
            Color drawColorLight = Color.White with { A = 0 };
            Color colorStart = Color.Cyan with { A = 0 };
            Color colorEnd = Color.Blue with { A = 0 };

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = Projectile.oldPos[j] - Main.screenPosition + (Projectile.Size / 2f);

                colorStart = Color.Lerp(colorStart, colorEnd, j * 0.25f) * Utils.GetLerpValue(1f, 0f, j * 0.1f) * 0.5f;
                drawColor *= 0.7f;
                drawColorLight *= 0.7f;

                spriteBatch.Draw(texture, drawPos, null, colorStart, Projectile.rotation, Projectile.Size / 2f, Projectile.scale, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos, null, drawColorLight, Projectile.rotation, Projectile.Size / 2f, Projectile.scale, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos, null, drawColor * 0.25f, Projectile.rotation, Projectile.Size / 2f, Projectile.scale * 1.5f, SpriteEffects.None, 0);
                spriteBatch.Draw(glowTexture, drawPos, null, colorStart * 0.5f, Projectile.rotation, glowTexture.Size() / 2f, Projectile.scale * 0.75f, SpriteEffects.None, 0);
            }

            return false;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            /*for (int i = 0; i < 30; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, 1, 1, DustID.Clentaminator_Cyan, Scale: 0.75f);
                dust.noGravity = true;
                dust.velocity *= 2f;
            }*/
            for (int i = 0; i < 5; i++)
            {
                Dust explodeDust = Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<GlowDust>(), Projectile.velocity, 100, Color.Cyan, 3f);
                explodeDust.velocity = -Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 20f * 16f) * 6f;
            }
        }
    }
}
