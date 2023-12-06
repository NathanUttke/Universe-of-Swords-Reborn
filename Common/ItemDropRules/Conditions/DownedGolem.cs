using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace UniverseOfSwordsMod.Common.ItemDropRules.Conditions
{
    public class DownedGolem : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info) => NPC.downedGolemBoss;
        public bool CanShowItemDropInUI() => true;
        public string GetConditionDescription() => null;
    }
}
