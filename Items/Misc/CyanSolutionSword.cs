using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Misc;

public class CyanSolutionSword : ModItem
{
	public override void SetStaticDefaults()
	{
        Item.ResearchUnlockCount = 1;
        On_ItemFilters.Tools.FitsFilter += Tools_FitsFilter;
    }

    private bool Tools_FitsFilter(On_ItemFilters.Tools.orig_FitsFilter orig, ItemFilters.Tools self, Item entry)
    {
        if (Item.type == Type)
        {
            return true;
        }
        return orig(self, entry);
    }

    public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.scale = 1.3f;
		Item.rare = ItemRarityID.Lime;			
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item34;			
		Item.value = 830000;
		Item.autoReuse = true;
        Item.shoot = ProjectileID.HallowSpray;
        Item.shootSpeed = 20f;
    }

    public override void AddRecipes()
	{		
		CreateRecipe()
        .AddIngredient(ModContent.ItemType<SwordMatter>(), 30)
        .AddIngredient(ItemID.BlueSolution, 300)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
