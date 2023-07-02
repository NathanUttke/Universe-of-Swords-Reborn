using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Items.Misc;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Common.GlobalItems
{
    public class BossBags : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            var entitySource = player.GetSource_OpenItem(arg);

            if (context == "bossBag")
            {
                switch (arg)
                {
                    case ItemID.EyeOfCthulhuBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<CthulhuJudge>(), 1);
                        break;
                    case ItemID.EaterOfWorldsBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<TheEater>(), 1);
                        break;
                    case ItemID.BrainOfCthulhuBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<TheBrain>(), 1);
                        break;
                    case ItemID.SkeletronBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<SwordOfPower>(), 1);
                        break;
                    case ItemID.WallOfFleshBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<BiggoronSword>(), 1);
                        break;
                    case ItemID.DestroyerBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<DestroyerSword>(), 1);
                        break;
                    case ItemID.TwinsBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<TwinsSword>(), 1);
                        break;                    
                    case ItemID.SkeletronPrimeBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<PrimeSword>(), 1);
                        break;
                    case ItemID.PlanteraBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<Executioner>(), 1);
                        break;
                    case ItemID.FishronBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<DragonsDeath>(), 1);
                        break;
                    case ItemID.GolemBossBag:
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<SolBlade>(), 1);
                        break;
                }
            }
        }
    }
}
