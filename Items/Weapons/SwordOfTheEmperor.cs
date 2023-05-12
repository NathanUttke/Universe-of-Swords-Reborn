using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SwordOfTheEmperor : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sword of The Emperor");
        Tooltip.SetDefault("'Grant them the Emperor's mercy. Let the heretics burn!'");
    }

    public override void SetDefaults()
    {
        Item.width = 100;
        Item.height = 100;        
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.damage = 90;
        Item.knockBack = 3f;
        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(0, 8, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 15)
            .AddIngredient(ItemID.HallowedBar, 75)
            .AddIngredient(ModContent.ItemType<Orichalcon>(), 25)
            .AddIngredient(ItemID.BrokenHeroSword, 1)
            .AddIngredient(ItemID.GoldBar, 25)
            .AddIngredient(ItemID.Terragrim, 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
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

        if (crit && Main.rand.NextBool(5) && !target.HasBuff(BuffID.Midas))
        {
            target.AddBuff(BuffID.Midas, 200, true);
        }
    }
    public override void OnHitPvp(Player player, Player target, int damage, bool crit)
    {
        if (!target.HasBuff(BuffID.Weak))
        {
            target.AddBuff(BuffID.Weak, 300, true);
        }
    }
}
