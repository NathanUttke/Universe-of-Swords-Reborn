using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace UniverseOfSwordsMod.Graphics;

public struct AlternateFinalFractalHelper
{
    public const int TotalIllusions = 1;

    public const int FramesPerImportantTrail = 60;

    private static readonly VertexStrip _vertexStrip = new();

    public Color ColorStart;

    public Color ColorEnd;

    public void Draw(Projectile proj, string shaderName)
    {
        MiscShaderData miscShaderData = GameShaders.Misc[shaderName];
        miscShaderData.UseShaderSpecificData(new Vector4(1, 0, 0, 0.6f));
        miscShaderData.Apply();
        _vertexStrip.PrepareStrip(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f, proj.oldPos.Length, includeBacksides: false);
        _vertexStrip.DrawTrail();
        Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    private Color StripColors(float progressOnStrip)
    {
        Color result = Color.Lerp(ColorStart, ColorEnd, Utils.GetLerpValue(0f, 0.7f, progressOnStrip, clamped: true)) * (1f - Utils.GetLerpValue(0f, 0.98f, progressOnStrip, clamped: true));
        result.A /= 2;
        return result;
    }

    private float StripWidth(float progressOnStrip)
    {
        return 74f;
    }
}
