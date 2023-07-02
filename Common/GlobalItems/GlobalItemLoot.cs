using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Items.Consumables;
using Terraria;

namespace UniverseOfSwordsMod.Common.GlobalItems
{
    public class GlobalItemLoot : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {            
            if (ItemID.Sets.IsFishingCrate[item.type] || ItemID.Sets.IsFishingCrateHardmode[item.type])
            {
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<DamascusOre>(), 7, 6, 23));
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<DamascusBar>(), 8, 2, 7));
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<MeleePowerPotion>(), 7, 1, 3));
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SwordMatter>(), 40, 1, 2));
            }                     
        }
    }
}
