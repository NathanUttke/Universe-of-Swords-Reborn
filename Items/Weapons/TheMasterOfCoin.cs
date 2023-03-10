using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheMasterOfCoin : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("The Master of Coin");
        Tooltip.SetDefault("'End your financial problems with this sword'");
    }

    public override void SetDefaults()
    {
        Item.width = 48;
        Item.height = 48;
        Item.rare = ItemRarityID.Purple;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.UseSound = SoundID.Item43;
        Item.shoot = ProjectileID.CoinPortal;
        Item.shootSpeed = 10f;
        Item.value = Item.sellPrice(0, 0, 0, 1);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.Y -= 1f * player.gravDir;
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
            Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), Item.shoot, damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);
        }
        return false;
    }

    public override void AddRecipes()
    {

        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.LuckyCoin, 1);
        val.AddIngredient(ItemID.GoldCrown, 10);
        val.AddIngredient(ItemID.GoldOre, 999);
        val.AddIngredient(ItemID.FlaskofGold, 60);
        val.AddIngredient(Mod, "Inflation", 1);
        val.AddIngredient(ItemID.PlatinumCoin, 9);
        val.AddIngredient(ItemID.GoldCoin, 99);
        val.AddIngredient(ItemID.SilverCoin, 999);
        val.AddIngredient(ItemID.CopperCoin, 999);
        val.AddTile(TileID.LunarCraftingStation);
        val.Register();
        Recipe val2 = CreateRecipe(1);
        val2.AddIngredient(ItemID.LuckyCoin, 1);
        val2.AddIngredient(ItemID.PlatinumCrown, 10);
        val2.AddIngredient(ItemID.PlatinumOre, 999);
        val2.AddIngredient(ItemID.FlaskofGold, 60);
        val2.AddIngredient(Mod, "Inflation", 1);
        val2.AddIngredient(ItemID.PlatinumCoin, 9);
        val2.AddIngredient(ItemID.GoldCoin, 99);
        val2.AddIngredient(ItemID.SilverCoin, 999);
        val2.AddIngredient(ItemID.CopperCoin, 999);
        val2.AddTile(TileID.LunarCraftingStation);
        val2.Register();
    }
}
