using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Apocalypse : ModItem
{
    public override void SetStaticDefaults()
    {
        // Tooltip.SetDefault("Weapon that causes apocalypse");
    }

    public override void SetDefaults()
    {
        Item.width = 60;
        Item.height = 60;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 45;
        Item.useAnimation = 15;
        Item.damage = 110;
        Item.knockBack = 12f;
        Item.UseSound = SoundID.Item116;
        Item.shoot = ProjectileID.ApprenticeStaffT3Shot;
        Item.shootSpeed = 10f;
        Item.value = Item.sellPrice(0, 5, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        Item.ResearchUnlockCount = 1;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Orange, 1.5f);
            Main.dust[dust].noGravity = true;
        }
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float spread = 0.75f;
        float baseSpeed = velocity.Length();
        float startAngle = velocity.ToRotation() - spread / 2f;
        float deltaAngle = spread / 4f;
        for (int i = 0; i < 3; i++)
        {
            float offsetAngle = startAngle + deltaAngle * i;
            Projectile newProj = Projectile.NewProjectileDirect(source, position, baseSpeed * offsetAngle.ToRotationVector2(), type, damage, knockback, player.whoAmI, 0f, 0f);
            newProj.DamageType = DamageClass.MeleeNoSpeed;
        }
        return false;
    }

/*    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.ApprenticeStaffT3, 1)
        .AddIngredient(ItemID.HellstoneBar, 20)
        .AddIngredient(ItemID.MeteoriteBar, 20)
        .AddIngredient(ModContent.ItemType<MartianSaucerCore>(), 1)
        .AddIngredient(ModContent.ItemType<SwordMatter>(), 15)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }*/
}
