using Terraria.GameContent.ItemDropRules;

namespace UniverseOfSwordsMod.NPCs
{
    public class PlayerNameCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info) => info.player.name == "Gnome" || info.player.name == "Gnom";
        public bool CanShowItemDropInUI() => true;
        public string GetConditionDescription() => null;
    }
}
