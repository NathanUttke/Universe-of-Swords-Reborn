using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PurpleSolutionSpreader : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Infinite biome spreading? Awesome!");
	}

	public override void SetDefaults()
	{
        Item.CloneDefaults(ModContent.ItemType<HallowSolutionSpreader>());
    }

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
	
	public override bool AltFunctionUse(Player player)
    {
		return true;
    }

    public override bool? UseItem(Player player)
    {
		if (player.altFunctionUse == 2 && player.inventory[player.selectedItem].type == ModContent.ItemType<PurpleSolutionSpreader>())
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.SetDefaults(ModContent.ItemType<RedSolutionSpreader>());
        }
		else
		{
			Item.shoot = ProjectileID.CorruptSpray;
			Item.shootSpeed = 15f;			
		}		
		return true;
    }	

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 200);
		val.AddIngredient(ItemID.PurpleSolution, 100);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
