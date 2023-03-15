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
    }

    public override void SetDefaults()
    {
        Item.width = 44;
        Item.height = 44;
        Item.rare = ItemRarityID.Purple;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 32;
        Item.useAnimation = 32;
        Item.UseSound = SoundID.Item43;
        Item.shoot = ProjectileID.CoinPortal;
        Item.shootSpeed = 10f;
        Item.value = Item.sellPrice(10, 1, 10, 0);
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (Main.rand.NextBool(2000) && player.hasLuckyCoin) 
        {
            float spread = 0.087f;
            int projectileToShoot = Utils.SelectRandom<int>(Main.rand, ProjectileID.CoinPortal, ProjectileID.None, ProjectileID.None, ProjectileID.None);
            float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
            double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
            double deltaAngle = spread / 1f;
            double offsetAngle = startAngle + deltaAngle;
            Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), projectileToShoot, damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);
        }    
        return false;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.LuckyCoin, 1)
            .AddIngredient(ItemID.GoldCrown, 10)
            .AddIngredient(ItemID.GoldBar, 20)
            .AddIngredient(ItemID.FlaskofGold, 60)
            .AddIngredient(ModContent.ItemType<Inflation>(), 1)
            .AddIngredient(ItemID.PlatinumCoin, 10)
            .AddIngredient(ItemID.GoldCoin, 1)
            .AddIngredient(ItemID.SilverCoin, 10)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        CreateRecipe()
            .AddIngredient(ItemID.LuckyCoin, 1)
            .AddIngredient(ItemID.PlatinumCrown, 10)
            .AddIngredient(ItemID.PlatinumBar, 20)
            .AddIngredient(ItemID.FlaskofGold, 60)
            .AddIngredient(ModContent.ItemType<Inflation>(), 1)
            .AddIngredient(ItemID.PlatinumCoin, 10)
            .AddIngredient(ItemID.GoldCoin, 1)
            .AddIngredient(ItemID.SilverCoin, 10)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
    }
}
