using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class EdgeLord : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Blood for the Blood God! Skulls for the skull throne! Milk for the Khorne flakes!'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 21;
		Item.useAnimation = 21;
		Item.damage = 100;
		Item.knockBack = 11f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ModContent.ProjectileType<EdgeLordProjectile>();
		Item.shootSpeed = 22f;
		Item.value = 800000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<TheBrain>(), 1)
			.AddIngredient(ItemID.MoonStone, 1)
			.AddIngredient(ItemID.HellstoneBar, 50)
			.AddIngredient(ItemID.SunStone, 1)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 1)
			.AddIngredient(ItemID.DeathSickle, 1)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<TheEater>(), 1)
			.AddIngredient(ItemID.MoonStone, 1)
			.AddIngredient(ItemID.HellstoneBar, 50)
            .AddIngredient(ItemID.SunStone, 1)
            .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 1)
			.AddIngredient(ItemID.DeathSickle, 1)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }
    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (!target.HasBuff(BuffID.Bleeding))
		{
			target.AddBuff(BuffID.Bleeding, 400);
		}
	}
}
