using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Materials;
using static Terraria.Player;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SwordOfTheEmperor : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
    {
        Item.Size = new(100);  
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 22;
        Item.useAnimation = 22;
        Item.UseSound = SoundID.Item169;
        Item.damage = 90;
        Item.knockBack = 4.5f;
        Item.scale = 1.25f;
        Item.crit = 10;        
        Item.value = Item.sellPrice(0, 5, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        Item.holdStyle = ItemHoldStyleID.HoldGolfClub;
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

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        UniversePlayer modPlayer = player.GetModPlayer<UniversePlayer>();

        for (int i = 0; i < 4; i++)
        {
            modPlayer.GetPointOnSwungItemPath(Item.width, Item.height, 1f * Main.rand.NextFloat(), player.GetAdjustedItemScale(Item), out var location, out var outwardDirection);
            Vector2 velocity = outwardDirection.RotatedBy(MathHelper.PiOver2 * player.direction * player.gravDir);
            Dust.NewDustPerfect(location, ModContent.DustType<GlowDust>(), velocity, 100, new Color(255, 232, 174));
        }
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.Keybrand, new ParticleOrchestraSettings
        {
            PositionInWorld = target.Center + Main.rand.NextVector2Circular(24f, 24f)
        }, player.whoAmI);

        target.AddBuff(ModContent.BuffType<Buffs.EmperorBlaze>(), 400, true);
        target.AddBuff(BuffID.Ichor, 400, true);

        if (hit.Crit && Main.rand.NextBool(5))
        {
            target.AddBuff(BuffID.Midas, 200, true);
        }
    }
    public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
    {
        target.AddBuff(BuffID.Weak, 300, true);
    }
}
