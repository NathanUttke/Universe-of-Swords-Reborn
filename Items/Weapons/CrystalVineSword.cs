using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CrystalVineSword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Crystal Vile Sword");
        Tooltip.SetDefault("Ignores 12 points of enemy defense");
    }

    public override void SetDefaults()
    {
        Item.width = 46;
        Item.height = 46;
        Item.scale = 1f;
        Item.rare = ItemRarityID.LightPurple;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 33;
        Item.useAnimation = 33;
        Item.damage = 50;
        Item.knockBack = 6f;
        Item.UseSound = SoundID.Item1;
        Item.shoot = ProjectileID.CrystalVileShardShaft;
        Item.shootSpeed = 20f;
        Item.value = Item.sellPrice(0, 10, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Magic; 
        SacrificeTotal = 1;
        Item.mana = 12;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float spread = 1.75f;
        float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
        double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
        double deltaAngle = spread / 2f;
        for (int i = 0; i < 25; i++)
        {
            double offsetAngle = startAngle + deltaAngle * i;
            Projectile vileProj = Projectile.NewProjectileDirect(source, new Vector2(position.X, position.Y), new Vector2(baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle)), type, damage, knockback, player.whoAmI, 0f, 0f);
            vileProj.ArmorPenetration = 12;
        }
        return false;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.CrystalVileShard, 1)
            .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 4)
            .AddIngredient(ItemID.NettleBurst, 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.Y -= 1f * player.gravDir;
    }
}
