using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Items.Weapons;
using UniverseOfSwordsMod.Items.Weapons.BossDrops;

namespace UniverseOfSwordsMod.Items.Consumables
{
    internal class SwordBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword Boss Bag");
            ItemID.Sets.BossBag[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Purple;
            Item.expert = true;    
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SwordStaff>(), 3, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<InnosWrath>(), 3, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SwordMatter>(), 3, 2, 5));
        }
    }
}
