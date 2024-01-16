using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class StoneSword : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("'You Rock!'");
	}

	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 35;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Blue;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 8;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item1;
		Item.value = 100;
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}
	public override void AddRecipes()
	{			
		CreateRecipe()
            .AddIngredient(ItemID.StoneBlock, 20)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
