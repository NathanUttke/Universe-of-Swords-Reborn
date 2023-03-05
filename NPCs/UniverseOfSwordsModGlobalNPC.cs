using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Chat;
using Terraria.Localization;

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
            if (Main.rand.Next(8) == 0)
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
        if (Main.rand.Next(2) == 0 && type == 368)
        {
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Skooma").Type, false);
            nextSlot++;
        }
    }

    public override void OnKill(NPC npc)
    {
        var source = npc.GetSource_Loot();
        if (npc.lifeMax > 5 && npc.value > 0f)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordMatter").Type, 1, false, 0, false, false);

            //if you are in expert mode you have a 25% chance to get 1 extra sword matter per kill
            if (Main.expertMode == true && Main.rand.NextFloat() < .25)
            {
                Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordMatter").Type, 1, false, 0, false, false);
            }
        }
        if (npc.type == NPCID.EyeofCthulhu && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("CthulhuJudge").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.KingSlime && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("StickyGlowstickSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.EaterofWorldsTail && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("TheEater").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BrainofCthulhu && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("TheBrain").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.SkeletronHead && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordOfPower").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.SkeletronPrime && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PrimeSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Spazmatism && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("TwinsSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.TheDestroyer && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DestroyerSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Plantera && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Executioner").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Golem && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Golem").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.CultistBoss && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Doomsday").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.CultistBoss && Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Doomsday").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.DukeFishron && !Main.expertMode)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Sharkron").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Paladin && !Main.expertMode && Main.rand.Next(0, 7) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PaladinSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Paladin && Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PaladinSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Vampire && !Main.expertMode && Main.rand.Next(50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DraculaSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Vampire && Main.expertMode && Main.rand.Next(40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DraculaSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.VampireBat && !Main.expertMode && Main.rand.Next(50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DraculaSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.VampireBat && Main.expertMode && Main.rand.Next(45) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DraculaSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.MartianSaucerCore && !Main.expertMode && Main.rand.Next(0, 2) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("MartianSaucerCore").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.MartianSaucerCore && Main.expertMode && Main.rand.Next(0, 1) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("MartianSaucerCore").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Frankenstein && !Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("FingerofDoom").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Frankenstein && Main.expertMode && Main.rand.Next(0, 30) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("FingerofDoom").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Unicorn && !Main.expertMode && Main.rand.Next(0, 15) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("GiantUnicornHorn").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Unicorn && Main.expertMode && Main.rand.Next(0, 10) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("GiantUnicornHorn").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GreekSkeleton && !Main.expertMode && Main.rand.Next(0, 15) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("CaesarSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GreekSkeleton && Main.expertMode && Main.rand.Next(0, 11) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("CaesarSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.PirateShip && !Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DutchSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.PirateShip && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DutchSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BigMimicHallow && !Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ShardSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BigMimicHallow && Main.expertMode && Main.rand.Next(0, 2) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ShardSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BigMimicCrimson && !Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DartSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BigMimicCrimson && Main.expertMode && Main.rand.Next(0, 2) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DartSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BigMimicCorruption && !Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ClingerSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BigMimicCorruption && Main.expertMode && Main.rand.Next(0, 2) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ClingerSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BigMimicJungle && !Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("RottenSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BigMimicJungle && Main.expertMode && Main.rand.Next(0, 2) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("RottenSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RedDevil && !Main.expertMode && Main.rand.Next(0, 15) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DevilSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RedDevil && Main.expertMode && Main.rand.Next(0, 13) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DevilSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Demon && !Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DeathSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Demon && Main.expertMode && Main.rand.Next(0, 35) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DeathSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GoblinWarrior && !Main.expertMode && Main.rand.Next(0, 30) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Sting").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GoblinWarrior && Main.expertMode && Main.rand.Next(0, 25) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Sting").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerVortex && !Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("InnosWrath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerVortex && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("InnosWrath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerNebula && !Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("InnosWrath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerNebula && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("InnosWrath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerStardust && !Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("InnosWrath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerStardust && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("InnosWrath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerSolar && !Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("InnosWrath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerSolar && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("InnosWrath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerVortex && !Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("BeliarClaw").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerVortex && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("BeliarClaw").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerNebula && !Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("BeliarClaw").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerNebula && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("BeliarClaw").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerStardust && !Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("BeliarClaw").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerStardust && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("BeliarClaw").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerSolar && !Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("BeliarClaw").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.LunarTowerSolar && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("BeliarClaw").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GoblinPeon && !Main.expertMode && Main.rand.Next(0, 20) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("GoblinKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GoblinPeon && Main.expertMode && Main.rand.Next(0, 17) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("GoblinKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.FireImp && !Main.expertMode && Main.rand.Next(0, 30) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Fireball").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.FireImp && Main.expertMode && Main.rand.Next(0, 25) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Fireball").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GiantBat && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("BatSlayer").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GiantBat && Main.expertMode && Main.rand.Next(0, 45) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("BatSlayer").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Piranha && !Main.expertMode && Main.rand.Next(0, 80) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Biter").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Piranha && Main.expertMode && Main.rand.Next(0, 70) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Biter").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.DungeonSlime && !Main.expertMode && Main.rand.Next(0, 10) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SlimeKiller").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.DungeonSlime && Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SlimeKiller").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.TheGroom && !Main.expertMode && Main.rand.Next(0, 1) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("UselessWeapon").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.TheGroom && Main.expertMode && Main.rand.Next(0, 1) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("UselessWeapon").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Werewolf && !Main.expertMode && Main.rand.Next(0, 30) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("WolfDestroyer").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Werewolf && Main.expertMode && Main.rand.Next(0, 25) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("WolfDestroyer").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Wraith && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("WraithBlade").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Wraith && Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("WraithBlade").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Zombie && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Zombie && Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.ArmedZombie && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.ArmedZombie && Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.PossessedArmor && !Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PossessedSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.PossessedArmor && Main.expertMode && Main.rand.Next(0, 35) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PossessedSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BaldZombie && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BaldZombie && Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.PincushionZombie && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.PincushionZombie && Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.SlimedZombie && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.SlimedZombie && Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.SwampZombie && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.SwampZombie && Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.TwiggyZombie && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.TwiggyZombie && Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.FemaleZombie && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.FemaleZombie && Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ZombieKnife").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Mimic && !Main.expertMode && Main.rand.Next(0, 4) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ElBastardo").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Mimic && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ElBastardo").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GiantCursedSkull && !Main.expertMode && Main.rand.Next(0, 30) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("WeirdSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GiantCursedSkull && Main.expertMode && Main.rand.Next(0, 20) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("WeirdSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.DarkCaster && !Main.expertMode && Main.rand.Next(0, 40) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("WaterBoltSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.DarkCaster && Main.expertMode && Main.rand.Next(0, 30) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("WaterBoltSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Harpy && !Main.expertMode && Main.rand.Next(0, 30) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("FeatherDuster").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Harpy && Main.expertMode && Main.rand.Next(0, 20) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("FeatherDuster").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.WyvernHead && !Main.expertMode && Main.rand.Next(0, 10) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SkyPower").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.WyvernHead && Main.expertMode && Main.rand.Next(0, 5) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SkyPower").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RustyArmoredBonesAxe && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("RustySword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RustyArmoredBonesAxe && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("RustySword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RustyArmoredBonesFlail && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("RustySword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RustyArmoredBonesFlail && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("RustySword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RustyArmoredBonesSword && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("RustySword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RustyArmoredBonesSword && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("RustySword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RustyArmoredBonesSwordNoArmor && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("RustySword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RustyArmoredBonesSwordNoArmor && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("RustySword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlueArmoredBones && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("MagnetSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlueArmoredBones && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("MagnetSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlueArmoredBonesMace && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("MagnetSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlueArmoredBonesMace && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("MagnetSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlueArmoredBonesNoPants && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("MagnetSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlueArmoredBonesNoPants && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("MagnetSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlueArmoredBonesSword && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("MagnetSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlueArmoredBonesSword && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("MagnetSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.HellArmoredBones && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordOfFlames").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.HellArmoredBones && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordOfFlames").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.HellArmoredBonesMace && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordOfFlames").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.HellArmoredBonesMace && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordOfFlames").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.HellArmoredBonesSword && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordOfFlames").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.HellArmoredBonesSword && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordOfFlames").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.HellArmoredBonesSpikeShield && !Main.expertMode && Main.rand.Next(0, 150) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordOfFlames").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.HellArmoredBonesSpikeShield && Main.expertMode && Main.rand.Next(0, 120) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SwordOfFlames").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.MossHornet && !Main.expertMode && Main.rand.Next(0, 1250) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DragonsDeath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.MossHornet && Main.expertMode && Main.rand.Next(0, 1050) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DragonsDeath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Arapaima && !Main.expertMode && Main.rand.Next(0, 1250) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DragonsDeath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Arapaima && Main.expertMode && Main.rand.Next(0, 1050) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DragonsDeath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.FlyingSnake && !Main.expertMode && Main.rand.Next(0, 1000) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DragonsDeath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.FlyingSnake && Main.expertMode && Main.rand.Next(0, 900) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DragonsDeath").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Crab && !Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("OceanRoar").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Crab && Main.expertMode && Main.rand.Next(0, 30) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("OceanRoar").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlackRecluse && !Main.expertMode && Main.rand.Next(0, 70) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PoisonSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlackRecluse && Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PoisonSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlackRecluseWall && !Main.expertMode && Main.rand.Next(0, 70) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PoisonSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.BlackRecluseWall && Main.expertMode && Main.rand.Next(0, 50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PoisonSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GoblinSummoner && !Main.expertMode && Main.rand.Next(0, 6) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PhantomScimitar").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GoblinSummoner && Main.expertMode && Main.rand.Next(0, 3) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("PhantomScimitar").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GraniteGolem && !Main.expertMode && Main.rand.Next(0, 30) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("WitherBane").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.GraniteGolem && Main.expertMode && Main.rand.Next(0, 15) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("WitherBane").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.DungeonGuardian && !Main.expertMode && Main.rand.Next(0, 100) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("HaloOfHorrors").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.DungeonGuardian && Main.expertMode && Main.rand.Next(0, 100) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("HaloOfHorrors").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.DrManFly && !Main.expertMode && Main.rand.Next(0, 30) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("HeisenbergsFlask").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.DrManFly && Main.expertMode && Main.rand.Next(0, 20) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("HeisenbergsFlask").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Stylist && !Main.expertMode && Main.rand.Next(4) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Extase").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Stylist && Main.expertMode && Main.rand.Next(2) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("Extase").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.MoonLordCore && !Main.expertMode && Main.rand.Next(100) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("StarMaelstorm").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.MoonLordCore && Main.expertMode && Main.rand.Next(50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("StarMaelstorm").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RedDevil && !Main.expertMode && Main.rand.Next(0, 15) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ScarletFlareCore").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.RedDevil && Main.expertMode && Main.rand.Next(0, 10) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("ScarletFlareCore").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Demon && !Main.expertMode && Main.rand.Next(60) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DaedricSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Demon && Main.expertMode && Main.rand.Next(50) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("DaedricSword").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Golem && !Main.expertMode && Main.rand.Next(100) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SolBlade").Type, 1, false, 0, false, false);
        }
        if (npc.type == NPCID.Golem && Main.expertMode && Main.rand.Next(75) == 0)
        {
            Item.NewItem(source, (int)((Entity)npc).position.X, (int)((Entity)npc).position.Y, ((Entity)npc).width, ((Entity)npc).height, ((GlobalNPC)this).Mod.Find<ModItem>("SolBlade").Type, 1, false, 0, false, false);
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
