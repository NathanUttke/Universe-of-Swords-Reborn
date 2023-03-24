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
        Item.width = 35;
        Item.height = 35;
        Item.scale = 1.5f;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 1f;
        Item.useTime = 18;
        Item.useAnimation = 18;
        Item.damage = 280;
        Item.UseSound = SoundID.Item15;
        Item.shoot = ProjectileID.NebulaArcanum;
        Item.shootSpeed = 10f;
        Item.value = 650000;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.X -= 3f * (float)player.direction;
        player.itemLocation.Y -= -3f * (float)player.direction;
    }

    public override void AddRecipes()
    {
        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.FragmentNebula, 80);
        val.AddIngredient(ItemID.FragmentSolar, 80);
        val.AddIngredient(Mod, "LunarOrb", 1);
        val.AddIngredient(Mod, "PowerOfTheGalactic", 1);
        val.AddIngredient(ItemID.LunarBar, 40);
        val.AddIngredient(ItemID.PortalGun, 1);
        val.AddIngredient(ItemID.NebulaArcanum, 1);
        val.AddIngredient(ItemID.TrueExcalibur, 1);
        val.AddIngredient(ItemID.LargeAmethyst, 4);
        val.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 4);
        val.AddTile(TileID.LunarCraftingStation);
        val.Register();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float spread = 0.087f;
        float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
        double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
        double deltaAngle = spread / 1f;
        for (int i = 0; i < 3; i++)
        {
            double offsetAngle = startAngle + deltaAngle * (double)i;
            Vector2 vel = new(baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle));
            Projectile proj = Projectile.NewProjectileDirect(source, position, vel, Item.shoot, damage, knockback, player.whoAmI, 0f, 0f);

            proj.DamageType = DamageClass.Melee;
        }
        return false;
    }
}
