using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GemSlayer : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Inflicts Midas debuff on enemies");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 25;
		Item.scale = 1.1f;
		Item.knockBack = 5.5f;
		Item.UseSound = SoundID.Item1;
		Item.value = 20000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<TopazSword>(), 1)
		.AddIngredient(ModContent.ItemType<SapphireSword>(), 1)
		.AddIngredient(ModContent.ItemType<EmeraldSword>(), 1)
		.AddIngredient(ModContent.ItemType<AmethystSword>(), 1)
		.AddIngredient(ModContent.ItemType<AmberSword>(), 1)
		.AddIngredient(ModContent.ItemType<DiamondSword>(), 1)
		.AddIngredient(ModContent.ItemType<RubySword>(), 1)
		.AddIngredient(ItemID.ShadowScale, 15)
		.AddTile(TileID.TinkerersWorkbench)
		.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
	}
}
