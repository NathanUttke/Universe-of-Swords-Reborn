using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class HallowSolutionSpreader : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Infinite biome spreading? Awesome!");
	}

	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.scale = 1.3f;
		Item.rare = ItemRarityID.Lime;	
		
		Item.useTime = 14;
		Item.useAnimation = 14;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item34;	
		
		Item.value = 830000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	
	public override bool AltFunctionUse(Player player)
    {
		return true;
    }

    public override bool? UseItem(Player player)
    {
		if (player.altFunctionUse == 2 && player.inventory[player.selectedItem].type == ModContent.ItemType<HallowSolutionSpreader>())
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.SetDefaults(ModContent.ItemType<BlueSolutionSpreader>());
        }
		else
		{
			Item.shoot = ProjectileID.HallowSpray;
			Item.shootSpeed = 10f;			
		}
		return true;
    }	

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 200);
		val.AddIngredient(ItemID.BlueSolution, 100);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
