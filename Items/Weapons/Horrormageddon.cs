using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Horrormageddon : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 82;
		Item.height = 82;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 15;
		Item.damage = 125;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ModContent.ProjectileType<DemonScytheClone>();
		Item.shootSpeed = 14f;
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.TheHorsemansBlade, 1)
		.AddIngredient(ModContent.ItemType<DeathSword>(), 1)
        .AddIngredient(ModContent.ItemType<ElBastardo>(), 1)
        .AddIngredient(ModContent.ItemType<SwordMatter>(), 45)
        .AddIngredient(ModContent.ItemType<LunarOrb>(), 1)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		for (int i = -1; i <= 1; i++)
		{
			Vector2 newVelocity = velocity.RotatedBy(MathHelper.ToRadians(15 * i));
			Projectile.NewProjectileDirect(source, position + velocity, newVelocity, type, damage, knockback / 2f, player.whoAmI);
        }
        return false;
    }
}
