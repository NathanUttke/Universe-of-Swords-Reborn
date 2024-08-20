using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent;
using Terraria;
using Terraria.ID;

namespace UniverseOfSwordsMod.Utilities
{
    public static partial class UniverseUtils
    {
        public static void DrawPrettyStarSparkle(float opacity, SpriteEffects dir, Vector2 drawpos, Color drawColor, Color shineColor, float flareCounter, float fadeInStart, float fadeInEnd, float fadeOutStart, float fadeOutEnd, float rotation, Vector2 scale, Vector2 fatness)
        {
            Texture2D sparkleTexture = TextureAssets.Extra[ExtrasID.SharpTears].Value;
            Color bigColor = shineColor * opacity * 0.5f;
            bigColor.A = 0;
            Vector2 origin = sparkleTexture.Size() / 2f;
            Color smallColor = drawColor * 0.5f;
            float lerpValue = Utils.GetLerpValue(fadeInStart, fadeInEnd, flareCounter, clamped: true) * Utils.GetLerpValue(fadeOutEnd, fadeOutStart, flareCounter, clamped: true);
            Vector2 scaleLeftRight = new Vector2(fatness.X * 0.5f, scale.X) * lerpValue;
            Vector2 scaleUpDown = new Vector2(fatness.Y * 0.5f, scale.Y) * lerpValue;
            bigColor *= lerpValue;
            smallColor *= lerpValue;
            // Bright, large part
            Main.EntitySpriteDraw(sparkleTexture, drawpos, null, bigColor, MathHelper.PiOver2 + rotation, origin, scaleLeftRight, dir);
            Main.EntitySpriteDraw(sparkleTexture, drawpos, null, bigColor, 0f + rotation, origin, scaleUpDown, dir);
            // Dim, small part
            Main.EntitySpriteDraw(sparkleTexture, drawpos, null, smallColor, MathHelper.PiOver2 + rotation, origin, scaleLeftRight * 0.6f, dir);
            Main.EntitySpriteDraw(sparkleTexture, drawpos, null, smallColor, 0f + rotation, origin, scaleUpDown * 0.6f, dir);
        }
    }
}
