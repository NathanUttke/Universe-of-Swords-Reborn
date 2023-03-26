using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GreenSolutionSpreader : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Infinite biome spreading? Awesome!");
	}

	public override void SetDefaults()
	{
        Item.CloneDefaults(ModContent.ItemType<HallowSolutionSpreader>());
    }
	
	public override bool AltFunctionUse(Player player)
    {
		return true;
    }

    public override bool? UseItem(Player player)
    {
		if (player.altFunctionUse == 2 && player.inventory[player.selectedItem].type == ModContent.ItemType<GreenSolutionSpreader>())
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.SetDefaults(ModContent.ItemType<PurpleSolutionSpreader>());
        }
		else
		{
			Item.shoot = ProjectileID.PureSpray;
			Item.shootSpeed = 20f;			
		}
		
		return true;
    }
	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(Mod, "SwordMatter", 200)
			.AddIngredient(ItemID.GreenSolution, 300)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
