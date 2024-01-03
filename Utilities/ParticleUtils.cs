using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Drawing;
using Terraria.GameContent;
using Terraria.Graphics.Renderers;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace UniverseOfSwordsMod.Utilities
{
    public partial class UniverseUtils
    {
        private static ParticlePool<FadingParticle> _poolFading = new(200, GetNewFadingParticle);

        private static ParticlePool<PrettySparkleParticle> _poolPrettySparkle = new(200, GetNewPrettySparkleParticle);

        private static PrettySparkleParticle GetNewPrettySparkleParticle()
        {
            return new PrettySparkleParticle();
        }

        private static FadingParticle GetNewFadingParticle()
        {
            return new FadingParticle();
        }
        public static void Spawn_TrueNightsEdgeCyan(ParticleOrchestraSettings settings)
        {
            float num = 30f;
            float num2 = 0f;
            for (float i = 0f; i < 3f; i += 2f)
            {
                PrettySparkleParticle prettySparkleParticle = _poolPrettySparkle.RequestParticle();
                Vector2 vector = (MathHelper.PiOver4 + MathHelper.PiOver4 * i + num2).ToRotationVector2() * 4f;                
                prettySparkleParticle.ColorTint = new Color(114, 224, 184, 127);                
                prettySparkleParticle.LocalPosition = settings.PositionInWorld;
                prettySparkleParticle.Rotation = vector.ToRotation();
                prettySparkleParticle.Scale = new Vector2(4f, 1f) * 1.1f;
                prettySparkleParticle.FadeInNormalizedTime = 5E-06f;
                prettySparkleParticle.FadeOutNormalizedTime = 0.95f;
                prettySparkleParticle.TimeToLive = num;
                prettySparkleParticle.FadeOutEnd = num;
                prettySparkleParticle.FadeInEnd = num / 2f;
                prettySparkleParticle.FadeOutStart = num / 2f;
                prettySparkleParticle.AdditiveAmount = 0.35f;
                prettySparkleParticle.LocalPosition -= vector * num * 0.25f;
                prettySparkleParticle.Velocity = vector;
                prettySparkleParticle.DrawVerticalAxis = false;
                if (i == 1f)
                {
                    prettySparkleParticle.Scale *= 1.5f;
                    prettySparkleParticle.Velocity *= 1.5f;
                    prettySparkleParticle.LocalPosition -= prettySparkleParticle.Velocity * 4f;
                }
                Main.ParticleSystem_World_OverPlayers.Add(prettySparkleParticle);
            }
            for (float j = 0f; j < 3f; j += 2f)
            {
                PrettySparkleParticle prettySparkleParticle2 = _poolPrettySparkle.RequestParticle();
                Vector2 vector2 = (MathHelper.PiOver4 + MathHelper.PiOver4 * j + num2).ToRotationVector2() * 4f;
                prettySparkleParticle2.ColorTint = new Color(141, 255, 255);               
                prettySparkleParticle2.LocalPosition = settings.PositionInWorld;
                prettySparkleParticle2.Rotation = vector2.ToRotation();
                prettySparkleParticle2.Scale = new Vector2(4f, 1f) * 0.7f;
                prettySparkleParticle2.FadeInNormalizedTime = 5E-06f;
                prettySparkleParticle2.FadeOutNormalizedTime = 0.95f;
                prettySparkleParticle2.TimeToLive = num;
                prettySparkleParticle2.FadeOutEnd = num;
                prettySparkleParticle2.FadeInEnd = num / 2f;
                prettySparkleParticle2.FadeOutStart = num / 2f;
                prettySparkleParticle2.LocalPosition -= vector2 * num * 0.25f;
                prettySparkleParticle2.Velocity = vector2;
                prettySparkleParticle2.DrawVerticalAxis = false;
                if (j == 1f)
                {
                    prettySparkleParticle2.Scale *= 1.5f;
                    prettySparkleParticle2.Velocity *= 1.5f;
                    prettySparkleParticle2.LocalPosition -= prettySparkleParticle2.Velocity * 4f;
                }
                Main.ParticleSystem_World_OverPlayers.Add(prettySparkleParticle2);
            }
        }
    }
}
