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
        Item.width = 32;
        Item.height = 32;
        Item.scale = 1.5f;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.damage = 288;
        Item.knockBack = 15f;
        Item.shoot = ProjectileID.NebulaBlaze2;
        Item.shootSpeed = 10f;
        Item.UseSound = SoundID.Item1;
        Item.value = 650500;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.Y -= 1f * player.gravDir;
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
        val.AddIngredient(Mod, "SwordMatter", 150);
        val.AddTile(TileID.LunarCraftingStation);
        val.Register();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float spread = 0.174f;
        float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
        double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
        double deltaAngle = spread / 2f;
        for (int i = 0; i < 3; i++)
        {
            double offsetAngle = startAngle + deltaAngle * (double)i;
            Vector2 vel = new(baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle));
            Projectile proj = Projectile.NewProjectileDirect(source, position, vel, Item.shoot, damage, knockback, player.whoAmI, 0f, 0f);

            proj.DamageType = DamageClass.Melee;
        }
        return false;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(69, 360, false);
        target.AddBuff(24, 360, false);
        target.AddBuff(31, 360, false);
        target.AddBuff(44, 360, false);
    }
}
