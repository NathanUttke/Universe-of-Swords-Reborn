using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class GnomeProj : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.GardenGnome}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 13;
            ProjectileID.Sets.TrailingMode[Type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.width = 32;
            Projectile.height = 30;
            Projectile.alpha = 64;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;            
            Projectile.scale = 1.125f;
            Projectile.light = 0.25f;           
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 40;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White;       
        public override void AI()
        {            
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;


            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor: Color.DarkCyan, Scale: 2f);
            }
        }
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.ai[1] == 1f || target.immortal || NPCID.Sets.CountsAsCritter[target.type])
            {
                return;
            }            

            for (int i = 0; i < 3; i++)
            {
                int direction = Utils.SelectRandom(Main.rand, -1, 1);
                Vector2 screenPos = Main.screenPosition;
                if (direction < 0)
                {
                    screenPos.X += Main.screenWidth;
                }
                screenPos.Y += Main.rand.Next(Main.screenHeight);
                Vector2 targetPos = Vector2.Normalize(target.Center - screenPos + Utils.RandomVector2(Main.rand, -5, 6)) * 24f;
                Projectile gnomProj = Projectile.NewProjectileDirect(target.GetSource_OnHit(target), screenPos, targetPos, Type, (int)(Projectile.damage * 0.75f), Projectile.knockBack, Projectile.owner, 0f, 1f);
                gnomProj.timeLeft = 100;
                gnomProj.penetrate = -1;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;            
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D glowTexture = TextureAssets.Extra[ExtrasID.FallingStar].Value;
            Vector2 drawOriginGlow = glowTexture.Size() / 2f;
            Vector2 drawOrigin = texture.Size() / 2f;
            float timer = (float)Main.timeForVisualEffects / 60f;

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = Projectile.oldPos[j] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);

                Color gnomTrailColor = Color.Lerp(Color.DeepSkyBlue, Color.OrangeRed, j * 0.1f) * Utils.GetLerpValue(1f, 0f, j * 0.05f);
                gnomTrailColor.A = 0;
                gnomTrailColor *= 0.5f;

                for (float i = 0f; i < 1f; i += 0.5f)
                {
                    float newTimer = timer % 0.5f / 0.5f;
                    newTimer = (newTimer + i) % 1f;
                    float doubleTimer = newTimer * 2f;
                    if (doubleTimer > 1f)
                    {
                        doubleTimer = 2f - doubleTimer;
                    }
                    spriteBatch.Draw(texture, drawPos, null, gnomTrailColor * doubleTimer, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
                    spriteBatch.Draw(glowTexture, drawPos, null, gnomTrailColor * 0.35f * doubleTimer, Projectile.rotation, drawOriginGlow, 0.75f + newTimer * 0.3f, SpriteEffects.None, 0);
                }
            }
            spriteBatch.Draw(glowTexture, Projectile.Center - Main.screenPosition + Vector2.UnitY.RotatedBy(MathHelper.TwoPi * timer * 4f + MathHelper.TwoPi / 3f), null, Color.DeepSkyBlue with { A = 0 } * 0.125f, Projectile.rotation, drawOriginGlow, Projectile.scale, SpriteEffects.None, 0);
            spriteBatch.Draw(glowTexture, Projectile.Center - Main.screenPosition + Vector2.UnitY.RotatedBy(MathHelper.TwoPi * timer * 2f + MathHelper.Pi + MathHelper.PiOver4), null, Color.DeepSkyBlue with { A = 0 } * 0.125f, Projectile.rotation, drawOriginGlow, Projectile.scale, SpriteEffects.None, 0);


            return false;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
            if (Projectile.owner == Main.myPlayer)
            {
                Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, ProjectileID.SolarWhipSwordExplosion, Projectile.damage, 4f, Projectile.owner, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);
            }
        }
    }
}
