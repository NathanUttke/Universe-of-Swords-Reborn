using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace UniverseOfSwordsMod.Common.Systems
{
    public class DownedBossSystem : ModSystem
    {
        public static bool downedSwordBoss = false;

        public override void OnWorldLoad()
        {
            downedSwordBoss = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (downedSwordBoss)
            {
                tag["downedSwordBoss"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedSwordBoss = tag.ContainsKey("downedSwordBoss");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = downedSwordBoss;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedSwordBoss = flags[0];
        }
    }
}
