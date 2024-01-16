using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using rail;
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
            Projectile.ArmorPenetration = 10;
            Projectile.timeLeft = 40;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White;       
        public override void AI()
        {            
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.DarkCyan with { A = 0 }, 2f);
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
                int direction = Main.rand.Next(-1, 2) * 1;
                Vector2 screenPos = Main.screenPosition;
                if (direction < 0)
                {
                    screenPos.X += Main.screenWidth;
                }
                screenPos.Y += Main.rand.Next(Main.screenHeight);
                //Vector2 screenPosition = new(screenPos.X, screenPos.Y);
                Vector2 targetPos = new(target.Center.X - screenPos.X, target.Center.Y - screenPos.Y);
                targetPos.X += Main.rand.Next(-50, 51) * 0.1f;
                targetPos.Y += Main.rand.Next(-50, 51) * 0.1f;
                float targetDist = targetPos.Length();
                targetDist = 24f / targetDist;
                targetPos.X *= targetDist;
                targetPos.Y *= targetDist;
                Projectile gnomProj = Projectile.NewProjectileDirect(target.GetSource_OnHit(target), screenPos, targetPos, Type, (int)(Projectile.damage * 0.75f), Projectile.knockBack, Projectile.owner, 0f, 1f);
                gnomProj.timeLeft = 100;
                gnomProj.penetrate = -1;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;            
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");
            Vector2 drawOriginGlow = glowTexture.Size() / 2f;

            Vector2 drawOrigin = texture.Size() / 2f;

            spriteBatch.Draw(texture, (Projectile.Center - Main.screenPosition) + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);

                Color gnomTrailColor = new(11 + j * 16, 127, 255 - j * 16, 40 - j);                
                Color trailColorGlow = new(11 + j * 16, 127, 255 - j * 16, 0);
                gnomTrailColor *= 0.75f;
                trailColorGlow *= 0.75f;

                spriteBatch.Draw(glowTexture, drawPos, null, trailColorGlow, Projectile.rotation, drawOriginGlow, 1f - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos, null, gnomTrailColor, Projectile.rotation, drawOrigin, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);                
            }            

            return false;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
            Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, Vector2.Zero, ProjectileID.SolarWhipSwordExplosion, (int)(Projectile.damage * 0.95f), 4f, Projectile.owner, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);
        }
    }
}
