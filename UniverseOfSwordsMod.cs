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
        internal static UniverseOfSwordsMod Instance;

        internal Mod BombusApisBee = null;
        internal Mod CalamityMod = null;
        public override void Load()
        {
            Instance = this;

            BombusApisBee = null;
            ModLoader.TryGetMod("BombusApisBee", out BombusApisBee);
            CalamityMod = null;
            ModLoader.TryGetMod("CalamityMod", out CalamityMod);

            if (Main.netMode != NetmodeID.Server)
            {
                Ref<Effect> PowerGalacticShader = new(ModContent.Request<Effect>("UniverseOfSwordsMod/Assets/Effects/PowerOfTheGalacticShader", AssetRequestMode.ImmediateLoad).Value);
                GameShaders.Misc["GalacticShader"] = new MiscShaderData(PowerGalacticShader, "PowerGalacticPass").UseProjectionMatrix(true);
            }
        }        

        public override void Unload()
        {
            BombusApisBee = null;
            CalamityMod = null;
        }
    }
}

