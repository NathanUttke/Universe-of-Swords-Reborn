using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Horrormageddon : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Where you see an army, I see a graveyard'");
	}

	public override void SetDefaults()
	{
		Item.width = 82;
		Item.height = 82;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 15;
		Item.damage = 105;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item71;
		Item.shoot = ProjectileID.DeathSickle;
		Item.shootSpeed = 12f;
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.TheHorsemansBlade, 1)
        .AddIngredient(ModContent.ItemType<ElBastardo>(), 1)
        .AddIngredient(ModContent.ItemType<InnosWrath>(), 1)
        .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 6)
        .AddIngredient(ModContent.ItemType<LunarOrb>(), 1)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.InfernoFriendlyBlast, (int)(damage * 1.25f), knockback, player.whoAmI, 0f, 0f);
		return false;
	}
}
