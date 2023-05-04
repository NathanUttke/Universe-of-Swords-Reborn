using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CosmoStorm : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'Sword that shatters galaxies'");
    }

    public override void SetDefaults()
    {
        Item.width = 86;
        Item.height = 86;
        Item.rare = ItemRarityID.Red;
        Item.knockBack = 3f;

        Item.useTime = 70;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item15;

        Item.damage = 130;
        Item.DamageType = DamageClass.Melee;

        Item.shoot = ProjectileID.NebulaArcanum;
        Item.shootSpeed = 10f;
        Item.value = 650000;
        Item.autoReuse = true;
        SacrificeTotal = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.FragmentNebula, 30)
        .AddIngredient(ItemID.FragmentSolar, 30)
        .AddIngredient(Mod, "LunarOrb", 1)
        .AddIngredient(Mod, "PowerOfTheGalactic", 1)
        .AddIngredient(ItemID.LunarBar, 20)
        .AddIngredient(ItemID.NebulaArcanum, 1)
        .AddIngredient(ItemID.TrueExcalibur, 1)
        .AddIngredient(ItemID.LargeAmethyst, 4)
        .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 5)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, Item.shoot, damage, knockback, player.whoAmI, 0f, 0f);
        proj.tileCollide = false;
        proj.DamageType = DamageClass.Melee;
   
        return false;
    }
}
