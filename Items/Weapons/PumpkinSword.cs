using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PumpkinSword : ModItem
{
    public override void SetDefaults()
    {	
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.Blue;
		
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;	
        Item.UseSound = SoundID.Item1 with { Pitch = 0.35f };			
		
        Item.damage = 12;
        Item.knockBack = 3.4f;
        Item.value = 1888;
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee; 
        Item.ResearchUnlockCount = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
			.AddIngredient(ItemID.Pumpkin, 15)
			.AddTile(TileID.WorkBenches)
			.Register();
    }
}
