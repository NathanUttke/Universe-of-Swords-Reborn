﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Consumables;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Common.GlobalNPCs
{
    public class GlobalNPCShop : GlobalNPC
    {
        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            shop[nextSlot++] = ModContent.ItemType<Skooma>();
            if (NPC.downedGolemBoss)
            {
                shop[nextSlot++] = ModContent.ItemType<Apocalypse>();
            }
            if (NPC.downedPlantBoss)
            {
                shop[nextSlot++] = ModContent.ItemType<Executioner>();
            }
        }
    }
}
