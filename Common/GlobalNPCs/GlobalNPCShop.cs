using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Consumables;

namespace UniverseOfSwordsMod.Common.GlobalNPCs
{
    public class GlobalNPCShop : GlobalNPC
    {
        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            shop[nextSlot++] = ModContent.ItemType<Skooma>();
        }
    }
}
