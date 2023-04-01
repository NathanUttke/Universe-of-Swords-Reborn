using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PumpkinBoom : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 65;
		Item.knockBack = 6.5f;
		Item.UseSound = SoundID.Item1;
		Item.shootSpeed = 10f;
		Item.value = 360500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<PumpkinSword>(), 1)
			.AddIngredient(Mod, "Orichalcon", 1)
			.AddIngredient(Mod, "SwordMatter", 100)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
