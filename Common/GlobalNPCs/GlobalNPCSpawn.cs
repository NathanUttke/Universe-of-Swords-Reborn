using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace UniverseOfSwordsMod.Common.GlobalNPCs
{
    public class GlobalNPCSpawn : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode && spawnInfo.Player.ZoneForest && !Main.IsItDay())
            {
                pool[NPCID.EnchantedSword] = SpawnCondition.OverworldDay.Chance * 0.25f;
            }
        }
    }
}
