﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Common.GlobalNPCs
{
    public class GlobalNPCBuff : GlobalNPC
    {
        public bool eBlaze;

        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            eBlaze = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (eBlaze)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 80;
                if (damage < 2)
                {
                    damage = 100;
                }
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (!eBlaze)
            {
                return;
            }
            if (Main.rand.Next(8) < 6)
            {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<EmperorBlaze>(), 0f, 0f, 100, default, 3.5f);
                Main.dust[dust].noGravity = true;
                Dust obj = Main.dust[dust];
                obj.velocity.X = 0;
                obj.velocity.Y *= 0.5f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(8))
                {
                    Main.dust[dust].noGravity = false;
                    Dust obj2 = Main.dust[dust];
                    obj2.scale *= 0.7f;
                }
            }
            Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
        }
    }
}
