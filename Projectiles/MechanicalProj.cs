using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent;
using UniverseOfSwordsMod.Dusts;
using Terraria.Audio;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class MechanicalProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.scale = 1f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 4;
            Projectile.alpha = 0;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 40;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 12;
            Projectile.ArmorPenetration = 20;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 28f)
            {
                Projectile.scale *= 0.98f;
                Projectile.alpha += 16;
                Projectile.velocity *= 0.9f;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            Color projColor = Color.White with { A = 127 } * Projectile.Opacity;
            Color projColor2 = projColor;

            Vector2 drawOrigin = texture.Size() / 2;          

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.oldPos[i] + Projectile.Size / 2 - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
                
                projColor2 *= 0.6f;

                Main.spriteBatch.Draw(texture, drawPos, texture.Frame(), projColor2, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }            
            
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), texture.Frame(), Color.IndianRed with { A = 0 } * Projectile.Opacity, Projectile.rotation, drawOrigin, Projectile.scale * 1.125f, SpriteEffects.None, 0);
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), texture.Frame(), projColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
