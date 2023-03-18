using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Apocalypse : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Weapon that causes apocalypse");
    }

    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 68;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 45;
        Item.useAnimation = 15;
        Item.damage = 120;
        Item.knockBack = 12f;
        Item.UseSound = SoundID.Item116;
        Item.shoot = ProjectileID.ApprenticeStaffT3Shot;
        Item.shootSpeed = 10f;
        Item.value = Item.sellPrice(0, 30, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.InfernoFork, 0f, 0f, 100, default(Color), 2f);
            Main.dust[dust].noGravity = true;
        }
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float spread = 0.783f;
        float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
        double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
        double deltaAngle = spread / 4f;
        for (int i = 0; i < 5; i++)
        {
            double offsetAngle = startAngle + deltaAngle * (double)i;
            Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), Item.shoot, damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);
        }
        return false;
    }

    public override void AddRecipes()
    {

        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.ApprenticeStaffT3, 1);
        val.AddIngredient(ItemID.HellstoneBar, 20);
        val.AddIngredient(ItemID.MeteoriteBar, 20);
        val.AddIngredient(Mod, "MartianSaucerCore", 1);
        val.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 3);
        val.AddTile(TileID.LunarCraftingStation);
        val.Register();
    }
}
