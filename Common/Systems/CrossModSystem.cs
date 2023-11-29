using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Localization;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Consumables;
using UniverseOfSwordsMod.NPCs.Bosses;

namespace UniverseOfSwordsMod.Common.Systems
{
    public class CrossModSystem : ModSystem
    {
        public override void PostSetupContent()
        {
            BossChecklistCompatibility();
        }
        private void BossChecklistCompatibility()
        {
            if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist))
            {
                return;
            }

            if (bossChecklist.Version < new Version(1, 6))
            {
                return;
            }         

            Func<bool> downedSword = () => DownedBossSystem.downedSwordBoss;

            Func<bool> available = () => true;

            int summonItem = ModContent.ItemType<SwordBossSummon>();

            string spawnInfo = $"Use [i:{ModContent.ItemType<SwordBossSummon>()}] at any time in any biome.";

            string despawnInfo = null;

            float weight = 11.0f;

            bossChecklist.Call(
                "LogBoss",
                Mod,
                "EvilFlyingBlade",
                weight,
                downedSword,
                ModContent.NPCType<SwordBossNPC>(),
                new Dictionary<string, object>
                    {
                    ["spawnItems"] = summonItem,
                    ["spawnInfo"] = Language.GetOrRegister("Mods.UniverseOfSwordsMod.BossChecklist.SwordBossNPC.SpawnInfo")
                    }
                );


        }
    }
}
