using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace UniverseOfSwordsMod.Projectiles
{
    public class DragonsDeathProjectile : BaseSpinningProj
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        Player Owner => Main.player[Projectile.owner];

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = new(0f * Owner.direction, texture.Height);
            SpriteBatch spriteBatch = Main.spriteBatch;
            Color projColor = new(255, 255, 255, 0);

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                projColor *= 0.75f;
                spriteBatch.Draw(texture, Projectile.oldPos[i] - Main.screenPosition + Projectile.Size / 2f, null, projColor, Projectile.oldRot[i], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
