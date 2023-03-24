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
		Item.useTime = 24;
		Item.useAnimation = 24;
		Item.damage = 29;
		Item.knockBack = 5.7f;
		Item.UseSound = SoundID.Item1;
		Item.value = 20000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(Mod, "TopazSword", 1)
		.AddIngredient(Mod, "SapphireSword", 1)
		.AddIngredient(Mod, "EmeraldSword", 1)
		.AddIngredient(Mod, "AmethystSword", 1)
		.AddIngredient(Mod, "EmeraldSword", 1)
		.AddIngredient(Mod, "AmberSword", 1)
		.AddIngredient(Mod, "DiamondSword", 1)
		.AddIngredient(Mod, "RubySword", 1)
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 1)
		.AddTile(TileID.Anvils)
		.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
	}
}
