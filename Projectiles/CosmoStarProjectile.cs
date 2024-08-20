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
                for (int i = 0; i < 10; i++)
                {
                    Vector2 spinPoint = Vector2.Zero;
                    spinPoint += -Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 10);
                    spinPoint = spinPoint.RotatedBy(Projectile.velocity.ToRotation());
                    Dust ringDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Alpha: 100, newColor: Color.LightCyan, Scale: 0.5f);
                    ringDust.position = Projectile.Center + spinPoint;
                    ringDust.velocity = spinPoint.SafeNormalize(Vector2.UnitY) * 2f;                  
                }
            }
            Projectile.rotation += Projectile.direction * 0.4f; 
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[ProjectileID.Starfury].Value;
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");

            SpriteBatch spriteBatch = Main.spriteBatch;
            Color drawColor = Color.LightCyan with { A = 0 };
            Color drawColorTrail = Color.Cyan with { A = 0 };

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + (Projectile.Size / 2f);

                drawColorTrail *= 0.7f;
                drawColor *= 0.7f;

                spriteBatch.Draw(texture, drawPos, null, drawColor, Projectile.rotation, Projectile.Size / 2f, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos, null, drawColor * 0.5f, Projectile.rotation, Projectile.Size / 2f, (Projectile.scale * 1.5f) - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                spriteBatch.Draw(glowTexture, drawPos, null, drawColorTrail * 0.75f, Projectile.rotation, glowTexture.Size() / 2f, (Projectile.scale * 0.75f) - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            //Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White with { A = 0 }, Projectile.rotation, Projectile.Size / 2f, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Cyan, 0.75f);
                dust.velocity *= 4f;
            }
        }
    }
}
