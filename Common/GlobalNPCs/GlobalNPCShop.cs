using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Common.GlobalNPCs
{
    public class GlobalNPCShop : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (Main.rand.NextBool(2) && type == 368)
            {
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Skooma").Type, false);
                nextSlot++;
            }
        }
    }
}
