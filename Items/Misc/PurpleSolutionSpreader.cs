using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Misc;

public class PurpleSolutionSpreader : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Infinite biome spreading? Awesome!\nRight click to choose between solutions");
        Item.ResearchUnlockCount = 1;
        Terraria.GameContent.Creative.On_ItemFilters.Tools.FitsFilter += Tools_FitsFilter;
    }

    private bool Tools_FitsFilter(Terraria.GameContent.Creative.On_ItemFilters.Tools.orig_FitsFilter orig, Terraria.GameContent.Creative.ItemFilters.Tools self, Item entry)
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

        Item.shoot = ProjectileID.CorruptSpray;
        Item.shootSpeed = 15f;
    }

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

    public override void AddRecipes()
	{		
		CreateRecipe()
        .AddIngredient(ModContent.ItemType<SwordMatter>(), 30)
        .AddIngredient(ItemID.PurpleSolution, 300)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
