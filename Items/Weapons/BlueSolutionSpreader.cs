using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BlueSolutionSpreader : ModItem
{
    public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Infinite biome spreading? Awesome!\nRight click to change to Green Solution Spreader");
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
		if (player.altFunctionUse == 2 && player.inventory[player.selectedItem].type == ModContent.ItemType<BlueSolutionSpreader>())
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.SetDefaults(ModContent.ItemType<GreenSolutionSpreader>());
        }
		else
		{            
            Item.shoot = ProjectileID.MushroomSpray;
			Item.shootSpeed = 20f;			
		}
		return true;
    }

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 200);
		val.AddIngredient(ItemID.DarkBlueSolution, 300);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
