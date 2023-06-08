using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.GameContent.ItemDropRules;
using UniverseOfSwordsMod.Items.Weapons;
using UniverseOfSwordsMod.Common.ItemDropRules.Conditions;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Items.Accessories;
using UniverseOfSwordsMod.Items.Misc;

namespace UniverseOfSwordsMod.Common.GlobalNPCs
{
    public class UniverseOfSwordsModGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            PlayerNameCondition playerNameCondition = new();
            LeadingConditionRule leadingConditionRule = new(playerNameCondition);
            Conditions.NotExpert notExpertCondition = new();
            Conditions.IsExpert isExpertCondition = new();

            if (npc.lifeMax > 10 && !NPCID.Sets.CountsAsCritter[npc.type] && !npc.immortal && !npc.SpawnedFromStatue && !npc.friendly)
            {
                npcLoot.Add(ItemDropRule.WithRerolls(ModContent.ItemType<SwordMatter>(), 1, 3, 1, 2));
            }
            if (npc.boss && System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1)
            {
                npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<TheEater>()));
            }

            switch (npc.type)
            {
                case NPCID.GoblinWarrior:
                case NPCID.GoblinThief:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoblinKnife>(), 3, 1, 1));
                    break;
                case NPCID.EnchantedSword:
                    npcLoot.Add(new DropBasedOnExpertMode(ItemDropRule.Common(ModContent.ItemType<SwordMatter>(), 1, 4, 8), ItemDropRule.Common(ModContent.ItemType<SwordMatter>(), 1, 8, 12)));
                    break;
                case NPCID.EyeofCthulhu:
                    npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<CthulhuJudge>()));
                    break;
                case NPCID.BrainofCthulhu:
                    npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<TheBrain>()));
                    break;
                case NPCID.SkeletronHead:
                    npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<SwordOfPower>()));
                    break;
                case NPCID.SkeletronPrime:
                    npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<PrimeSword>()));
                    break;
                case NPCID.Spazmatism:
                    npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<TwinsSword>()));
                    break;
                case NPCID.TheDestroyer:
                    npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<DestroyerSword>(), 1, 1, 1));
                    break;
                case NPCID.Plantera:
                    npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<Executioner>(), 1, 1, 1));
                    break;
                case NPCID.CultistBoss:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Doomsday>(), 1, 1, 1));
                    break;
                case NPCID.MartianSaucerCore:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<MartianSaucerCore>(), 2, 1));
                    break;
                case NPCID.Frankenstein:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<FingerOfDoom>(), 40, 2));
                    break;
                case NPCID.Unicorn:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<GiantUnicornHorn>(), 15, 1));
                    break;
                case NPCID.GreekSkeleton:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<CaesarSword>(), 15, 1));
                    break;
                case NPCID.PirateShip:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<DutchmanSword>(), 5, 1));
                    break;
                case NPCID.BigMimicCorruption:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<ClingerSword>(), 3, 1));
                    break;
                case NPCID.LunarTowerNebula:
                case NPCID.LunarTowerStardust:
                case NPCID.LunarTowerSolar:
                case NPCID.LunarTowerVortex:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<InnosWrath>(), 5, 1));
                    break;
                case NPCID.GiantBat:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<BatSlayer>(), 50, 1));
                    break;
                case NPCID.TheGroom:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<UselessWeapon>(), 30, 1));
                    break;
                case NPCID.Mimic:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<ElBastardo>(), 4, 1));
                    break;
                case NPCID.DarkCaster:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<WaterBoltSword>(), 40, 1));
                    break;
                case NPCID.DukeFishron:
                    npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<DragonsDeath>(), 4, 1));
                    break;
                case NPCID.Crab:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<OceanRoar>(), 50, 1));
                    break;
                case NPCID.DungeonGuardian:
                    npcLoot.Add(ItemDropRule.ByCondition(isExpertCondition, ModContent.ItemType<HaloOfHorrors>(), 100, 1));
                    break;
                case NPCID.RedDevil:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<ScarletFlareCore>(), 50, 1));
                    break;
                case NPCID.Demon:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<DeathSword>(), 40, 1));
                    break;
                case NPCID.Golem:
                    npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<SolBlade>(), 8, 1));
                    break;
                case NPCID.WallofFlesh:
                    npcLoot.Add(ItemDropRule.ByCondition(notExpertCondition, ModContent.ItemType<BiggoronSword>()));
                    break;
                case NPCID.IceQueen:
                    npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<BlizzardRage>(), 4, 1));
                    break;
                case NPCID.MoonLordCore:                    
                    IItemDropRule rule = ItemDropRule.ByCondition(isExpertCondition, ModContent.ItemType<GnomBlade>(), 300, 1);
                    leadingConditionRule.OnSuccess(rule);
                    npcLoot.Add(leadingConditionRule);
                    break;
            }
        }        
    }
}
