using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DirtSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 36;
		Item.rare = ItemRarityID.White;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 32;
		Item.useAnimation = 32;
		Item.damage = 6;
		Item.knockBack = 3f;
		Item.UseSound = SoundID.Item1;
		Item.value = 15;
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	public override void AddRecipes()
	{				
		CreateRecipe()
		.AddIngredient(ItemID.DirtBlock, 30)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 5)
		.AddTile(TileID.WorkBenches)
		.Register();
	}
}
