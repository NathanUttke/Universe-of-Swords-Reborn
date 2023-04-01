using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

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
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.damage = 120;
        Item.knockBack = 15f;
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
        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.FragmentSolar, 15);
        val.AddIngredient(ItemID.FragmentVortex, 15);
        val.AddIngredient(ItemID.FragmentNebula, 15);
        val.AddIngredient(ItemID.FragmentStardust, 15);
        val.AddIngredient(ItemID.LunarBar, 10);
        val.AddIngredient(Mod, "LunarOrb", 1);
        val.AddTile(TileID.LunarCraftingStation);
        val.Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(69, 360, false);
        target.AddBuff(24, 360, false);
        target.AddBuff(31, 360, false);
        target.AddBuff(44, 360, false);
    }
}
