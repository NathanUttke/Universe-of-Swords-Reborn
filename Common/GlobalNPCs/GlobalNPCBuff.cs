using Microsoft.Xna.Framework;
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
            ApplyBlazeDebuff(npc, ref damage);
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            DrawBlaze(npc);
        }

        #region Blaze Debuff 
        public void ApplyBlazeDebuff(NPC npc, ref int damage)
        {
            if (!eBlaze)
            {
                return;
            }

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

        public void DrawBlaze(NPC npc)
        {
            if (!eBlaze)
            {
                return;
            }

            if (Main.rand.Next(8) < 6)
            {
                Dust dust = Dust.NewDustDirect(npc.Center, npc.width, npc.height, ModContent.DustType<EmperorBlaze>());
                dust.velocity.X = 0;
                dust.velocity.Y *= 0.5f;
                dust.velocity.Y -= 0.5f;
            }
            Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
        }

        #endregion
    }
}
