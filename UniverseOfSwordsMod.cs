using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace UniverseOfSwordsMod
{
    public class UniverseOfSwordsMod : Mod
    {        
        public override void Load()
        {

            if (Main.netMode != NetmodeID.Server)
            {
                Ref<Effect> PowerGalacticShader = new(ModContent.Request<Effect>("UniverseOfSwordsMod/Assets/Effects/PowerOfTheGalacticShader", AssetRequestMode.ImmediateLoad).Value);
                GameShaders.Misc["GalacticShader"] = new MiscShaderData(PowerGalacticShader, "PowerGalacticPass").UseProjectionMatrix(true);
            }
        }
    }
}

