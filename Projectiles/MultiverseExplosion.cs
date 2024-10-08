using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class MultiverseExplosion : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.Flames}";

        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 7;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(140);
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 25;
            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[0] = 1f;
                SoundEngine.PlaySound(SoundID.Item88, Projectile.position);
            }

            if ((Projectile.frameCounter += 3) >= Main.projFrames[Type])
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Type])
                {
                    Projectile.Kill();
                }
            }
        }


        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Main.instance.LoadProjectile(ProjectileID.StardustTowerMark);
            Texture2D textureGlow = TextureAssets.Projectile[ProjectileID.StardustTowerMark].Value;

            Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Type], 0, Projectile.frame);
            Vector2 drawOriginGlow = textureGlow.Size() / 2;

            Color drawColor = new Color(255, 100, 255, 255) * Projectile.Opacity * 0.5f;
            Color drawColorGlow = new Color(255, 150, 255, 0) * Projectile.Opacity * 0.5f;
            Color backColor = new Color(106, 100, 200, 255) * Projectile.Opacity * 0.5f;

            Main.EntitySpriteDraw(textureGlow, Projectile.Center - Main.screenPosition, null, drawColorGlow, Projectile.rotation, drawOriginGlow, Projectile.scale * 2.25f, SpriteEffects.None);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, drawColor with { A = 90 }, Projectile.rotation, sourceRectangle.Size() / 2, Projectile.scale * 1.25f, SpriteEffects.None);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, drawColor with { A = 50 }, Projectile.rotation, sourceRectangle.Size() / 2, Projectile.scale, SpriteEffects.None);

            return false;
        }
    }
}
