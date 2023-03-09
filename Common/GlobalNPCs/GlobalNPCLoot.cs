using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items;
using Terraria.ID;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.GameContent.ItemDropRules;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.NPCs;

public class UniverseOfSwordsModGlobalNPC : GlobalNPC
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
            npc.lifeRegen -= 120000;
            if (damage < 2)
            {
                damage = 40000;
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
            int dust = Dust.NewDust(((Entity)npc).position - new Vector2(2f, 2f), ((Entity)npc).width + 4, ((Entity)npc).height + 4, ((GlobalNPC)this).Mod.Find<ModDust>("EmperorBlaze").Type, ((Entity)npc).velocity.X * 0.4f, ((Entity)npc).velocity.Y * 0.4f, 100, default(Color), 3.5f);
            Main.dust[dust].noGravity = true;
            Dust obj = Main.dust[dust];
            obj.velocity *= 0.5f;
            Main.dust[dust].velocity.Y -= 0.5f;
            if (Main.rand.NextBool(8))
            {
                Main.dust[dust].noGravity = false;
                Dust obj2 = Main.dust[dust];
                obj2.scale *= 0.7f;
            }
        }
        Lighting.AddLight(((Entity)npc).position, 0.1f, 0.2f, 0.7f);
    }

    public override void SetupShop(int type, Chest shop, ref int nextSlot)
    {
        if (Main.rand.NextBool(2) && type == 368)
        {
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Skooma").Type, false);
            nextSlot++;
        }
    }

    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
    {
        PlayerNameCondition playerNameCondition = new();
        LeadingConditionRule leadingConditionRule = new(playerNameCondition);
        Conditions.NotExpert condition = new();
        if (npc.lifeMax > 5 && !NPCID.Sets.CountsAsCritter[npc.type])
        {
            npcLoot.Add(ItemDropRule.WithRerolls(ModContent.ItemType<SwordMatter>(), 3, 1));
        }
        if (npc.boss && npc.type == NPCID.EyeofCthulhu)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<CthulhuJudge>()));
        }
        if (npc.type == NPCID.KingSlime)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<StickyGlowstickSword>()));
        }
        if (npc.boss && System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<TheEater>()));
        }
        if (npc.type == NPCID.BrainofCthulhu)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<TheBrain>()));
        }
        if (npc.type == NPCID.SkeletronHead)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<SwordOfPower>()));
        }
        if (npc.type == NPCID.SkeletronPrime)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<PrimeSword>()));
        }
        if (npc.type == NPCID.Spazmatism)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<TwinsSword>()));
        }
        if (npc.type == NPCID.TheDestroyer)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<DestroyerSword>()));
        }
        if (npc.type == NPCID.Plantera)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<Executioner>()));
        }
        if (npc.type == NPCID.Golem)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<Golem>()));
        }
        if (npc.type == NPCID.CultistBoss)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<Doomsday>()));
        }
        if (npc.type == NPCID.DukeFishron)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<Sharkron>()));
        }
        if (npc.type == NPCID.Paladin)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<PaladinSword>(), 7, 1));
        }
        if (npc.type == NPCID.Vampire)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<DraculaSword>(), 40, 2));
        }
        if (npc.type == NPCID.VampireBat)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<DraculaSword>(), 50, 2));
        }
        if (npc.type == NPCID.MartianSaucerCore)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<MartianSaucerCore>(), 2, 1));
        }
        if (npc.type == NPCID.Frankenstein)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<FingerOfDoom>(), 40, 2));
        }
        if (npc.type == NPCID.Unicorn)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<GiantUnicornHorn>(), 15, 1));
        }
        if (npc.type == NPCID.GreekSkeleton)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<CaesarSword>(), 15, 1));
        }
        if (npc.type == NPCID.PirateShip)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<GiantUnicornHorn>(), 5, 1));
        }
        if (npc.type == NPCID.BigMimicHallow)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<SwordShard>(), 3, 1));
        }
        if (npc.type == NPCID.BigMimicCrimson)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<DartSword>(), 3, 1));
        }
        if (npc.type == NPCID.BigMimicCorruption)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<ClingerSword>(), 3, 1));
        }
        if (npc.type == NPCID.BigMimicJungle)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<RottenSword>(), 3, 1));
        }
        if (npc.type == NPCID.RedDevil)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<DevilBlade>(), 15, 1));
        }
        if (npc.type == NPCID.Demon)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<DeathSword>(), 40, 1));
        }
        if (npc.type == NPCID.GoblinWarrior)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<Sting>(), 30, 1));
        }
        if (npc.type == NPCID.LunarTowerNebula || npc.type == NPCID.LunarTowerStardust || npc.type == NPCID.LunarTowerSolar || npc.type == NPCID.LunarTowerVortex || npc.type == NPCID.LunarTowerStardust)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<InnosWrath>(), 5, 1));
        }
        if (npc.type == NPCID.GoblinPeon)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<GoblinKnife>(), 20, 1));
        }
        if (npc.type == NPCID.FireImp)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<Fireball>(), 30, 1));
        }
        if (npc.type == NPCID.GiantBat)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<BatSlayer>(), 50, 1));
        }
        if (npc.type == NPCID.Piranha)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<Biter>(), 80, 1));
        }
        if (npc.type == NPCID.DungeonSlime)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<SlimeKiller>(), 10, 1));
        }
        if (npc.type == NPCID.TheGroom)
        {
            npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<UselessWeapon>()));
        }
        if (npc.type == NPCID.Werewolf)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<WolfDestroyer>(), 30, 1));
        }
        if (npc.type == NPCID.Wraith)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<WraithBlade>(), 50, 1));
        }
        if (npc.type == NPCID.Zombie || npc.type == NPCID.ArmedZombie || npc.type == NPCID.BaldZombie || npc.type == NPCID.PincushionZombie || npc.type == NPCID.SlimedZombie || npc.type == NPCID.SwampZombie || npc.type == NPCID.TwiggyZombie || npc.type == NPCID.FemaleZombie)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<ZombieKnife>(), 50, 1));
        }
        if (npc.type == NPCID.PossessedArmor)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<PossessedSword>(), 40, 1));
        }
        if (npc.type == NPCID.Mimic)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<ElBastardo>(), 4, 1));
        }
        if (npc.type == NPCID.GiantCursedSkull)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<WeirdSword>(), 30, 1));
        }
        if (npc.type == NPCID.DarkCaster)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<WaterBoltSword>(), 40, 1));
        }
        if (npc.type == NPCID.Harpy)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<FeatherDuster>(), 30, 1));
        }
        if (System.Array.IndexOf(new int[] { NPCID.WyvernBody, NPCID.WyvernHead, NPCID.WyvernTail }, npc.type) > -1)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<SkyPower>(), 10, 1));
        }
        if (npc.type == NPCID.RustyArmoredBonesAxe || npc.type == NPCID.RustyArmoredBonesFlail || npc.type == NPCID.RustyArmoredBonesSword || npc.type == NPCID.RustyArmoredBonesSwordNoArmor)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<RustySword>(), 150, 1));
        }
        if (npc.type == NPCID.BlueArmoredBones || npc.type == NPCID.BlueArmoredBonesMace || npc.type == NPCID.BlueArmoredBonesNoPants || npc.type == NPCID.BlueArmoredBonesSword)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<MagnetSword>(), 150, 1));
        }
        if (npc.type == NPCID.HellArmoredBones || npc.type == NPCID.HellArmoredBonesMace || npc.type == NPCID.HellArmoredBonesSword || npc.type == NPCID.HellArmoredBonesSpikeShield)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<SwordOfFlames>(), 150, 1));
        }
        if (npc.type == NPCID.MossHornet || npc.type == NPCID.Arapaima || npc.type == NPCID.FlyingSnake)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<DragonsDeath>(), 1250, 1));
        }
        if (npc.type == NPCID.Crab)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<OceanRoar>(), 50, 1));
        }
        if (npc.type == NPCID.BlackRecluse || npc.type == NPCID.BlackRecluseWall)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<PoisonSword>(), 70, 1));
        }
        if (npc.type == NPCID.GoblinSummoner)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<PhantomScimitar>(), 6, 1));
        }
        if (npc.type == NPCID.GraniteGolem)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<WitherBane>(), 30, 1));
        }
        if (npc.type == NPCID.DungeonGuardian)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<HaloOfHorrors>(), 100, 1));
        }
        if (npc.type == NPCID.DrManFly)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<HeisenbergsFlask>(), 30, 1));
        }
        if (npc.type == NPCID.Stylist)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<Extase>(), 4, 1));
        }
        if (npc.type == NPCID.MoonLordCore)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<StarMaelstorm>(), 100, 1));
        }
        if (npc.type == NPCID.RedDevil)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<ScarletFlareCore>(), 100, 1));
        }
        if (npc.type == NPCID.Demon)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<DaedricSword>(), 60, 1));
        }
        if (npc.type == NPCID.Golem)
        {
            npcLoot.Add(ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<SolBlade>(), 100, 1));
        }
        if (npc.type == NPCID.MoonLordCore && npc.boss)
        {
            IItemDropRule rule = ItemDropRule.ExpertGetsRerolls(ModContent.ItemType<SwordOfTheMultiverse>(), 100, 1);
            leadingConditionRule.OnSuccess(rule);
            npcLoot.Add(leadingConditionRule);
        }
        
    }
    public override bool PreKill(NPC npc)
    {
        if (npc.type == NPCID.Plantera && !NPC.downedPlantBoss)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The world has been cursed with Black Ore"), new Color(41, 55, 41));
            }

            //in single player
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText("The world has been cursed with Black Ore", new Color(41, 55, 41));
            }
            //gen ore
            for (int i = 0; i < Main.maxTilesX / 4200 * 50; i++)
            {
                int num = WorldGen.genRand.Next(0, Main.maxTilesX);
                int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 300);
                Tile tile = Framing.GetTileSafely(num, Y);
                WorldGen.OreRunner(num, Y, (double)WorldGen.genRand.Next(8, 10), WorldGen.genRand.Next(3, 4), Mod.Find<ModTile>("BlackOreTile").Type);
            }
        }
        return true;
    }
}
