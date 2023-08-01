using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Misc;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Common.GlobalItems
{
    public class BossBags : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (ItemID.Sets.BossBag[item.type] || ItemID.Sets.PreHardmodeLikeBossBag[item.type])
            {
                switch (item.type)
                {
                    case ItemID.EyeOfCthulhuBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CthulhuJudge>(), 1, 1, 1));
                        break;
                    case ItemID.EaterOfWorldsBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheEater>(), 1, 1, 1));
                        break;
                    case ItemID.BrainOfCthulhuBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheBrain>(), 1, 1, 1));
                        break;
                    case ItemID.SkeletronBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SwordOfPower>(), 1, 1, 1));
                        break;
                    case ItemID.WallOfFleshBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BiggoronSword>(), 1, 1, 1));
                        break;
                    case ItemID.DestroyerBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DestroyerSword>(), 1, 1, 1));
                        break;
                    case ItemID.TwinsBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TwinsSword>(), 1, 1, 1));
                        break;
                    case ItemID.SkeletronPrimeBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<PrimeSword>(), 1, 1, 1));
                        break;
                    case ItemID.PlanteraBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Executioner>(), 1, 1, 1));
                        break;
                    case ItemID.FishronBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DragonsDeath>(), 1, 1, 1)); 
                        break;
                    case ItemID.GolemBossBag:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SolBlade>(), 1, 1, 1));
                        break;
                }
            }
        }
    }
}
