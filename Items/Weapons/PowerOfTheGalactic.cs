using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PowerOfTheGalactic : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Sword made from all galactic elements");
    }

    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 26;
        Item.useAnimation = 13;
        Item.damage = 120;
        Item.knockBack = 8f;
        Item.scale = 1.25f;
        Item.shootSpeed = 10f;
        Item.UseSound = SoundID.Item1;
        Item.value = 650500;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.FragmentSolar, 15)
        .AddIngredient(ItemID.FragmentVortex, 15)
        .AddIngredient(ItemID.FragmentNebula, 15)
        .AddIngredient(ItemID.FragmentStardust, 15)
        .AddIngredient(ItemID.LunarBar, 8)
        .AddIngredient(ModContent.ItemType<LunarOrb>(), 1)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(69, 360, false);
        target.AddBuff(24, 360, false);
        target.AddBuff(31, 360, false);
        target.AddBuff(44, 360, false);
    }
}
