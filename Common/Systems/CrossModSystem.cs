using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if (bossChecklist.Version < new Version(1, 3, 1))
            {
                return;
            }

            string bossName = "Evil Flying Blade";

            int bossType = ModContent.NPCType<SwordBossNPC>();

            Func<bool> downedSword = () => DownedBossSystem.downedSwordBoss;

            Func<bool> available = () => true;

            int summonItem = ModContent.ItemType<SwordBossSummon>();

            string spawnInfo = $"Use [i:{ModContent.ItemType<SwordBossSummon>()}] at any time in any biome.";

            string despawnInfo = null;

            float weight = 12.0f;

            bossChecklist.Call(
                "AddBoss",
                Mod,
                bossName,
                bossType,
                weight,
                downedSword,
                available,
                null,
                summonItem,
                spawnInfo,
                despawnInfo);


        }
    }
}
