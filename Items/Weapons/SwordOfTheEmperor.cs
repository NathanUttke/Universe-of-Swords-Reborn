using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SwordOfTheEmperor : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 100;
        Item.height = 100;        
        Item.rare = ItemRarityID.Red;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 22;
        Item.useAnimation = 22;
        Item.UseSound = SoundID.Item169;

        Item.damage = 90;
        Item.knockBack = 4.5f;
        Item.scale = 1.25f;
        Item.crit = 8;
        
        Item.value = Item.sellPrice(0, 5, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        Item.ResearchUnlockCount = 1;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 40)  
            .AddIngredient(ModContent.ItemType<Orichalcon>(), 12)
            .AddIngredient(ItemID.BrokenHeroSword, 1)
            .AddIngredient(ItemID.GoldBar, 25)
            .AddIngredient(ItemID.BreakerBlade, 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.Keybrand, new ParticleOrchestraSettings
        {
            PositionInWorld = target.Center,
            MovementVector = player.itemRotation.ToRotationVector2() * 5f * 0.1f + Main.rand.NextVector2Circular(2f, 2f)

        }, player.whoAmI);

        if (!target.HasBuff(ModContent.BuffType<EmperorBlaze>()))
        {
            target.AddBuff(ModContent.BuffType<EmperorBlaze>(), 400, true);
        }

        if (!target.HasBuff(BuffID.Weak))
        {
            target.AddBuff(BuffID.Weak, 400, true);
        }

        if (!target.HasBuff(BuffID.Ichor))
        {
            target.AddBuff(BuffID.Ichor, 400, true);
        }

        if (hit.Crit && Main.rand.NextBool(5) && !target.HasBuff(BuffID.Midas))
        {
            target.AddBuff(BuffID.Midas, 200, true);
        }
    }
    public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
    {
        if (!target.HasBuff(BuffID.Weak))
        {
            target.AddBuff(BuffID.Weak, 300, true);
        }
    }
}
