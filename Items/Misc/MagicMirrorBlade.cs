using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Misc;

public class MagicMirrorBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Magic Mirror Blade");
		// Tooltip.SetDefault("'Magic Mirror and sword fused together'");
	}

	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item6;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = false;
		Item.ResearchUnlockCount = 1;
    }

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		if (Main.rand.NextBool(2))
		{
			Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.1f);
		}
		if (player.itemTime == 0)
		{
			player.itemTime = (int)(Item.useTime / PlayerLoader.UseTimeMultiplier(player, Item));
		}
		else
		{
			if (player.itemTime != (int)(Item.useTime / PlayerLoader.UseTimeMultiplier(player, Item)) / 2)
			{
				return;
			}
			for (int d = 0; d < 70; d++)
			{
				Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default, 1.5f);
			}
			player.grappling[0] = -1;
			player.grapCount = 0;
			for (int p = 0; p < 1000; p++)
			{
				if (Main.projectile[p].active && Main.projectile[p].owner == player.whoAmI && Main.projectile[p].aiStyle == 7)
				{
					Main.projectile[p].Kill();
				}
			}
			player.Spawn(PlayerSpawnContext.RecallFromItem);
			for (int d2 = 0; d2 < 70; d2++)
			{
				Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.5f);
			}
		}
	}
	public override void AddRecipes()
	{	
		CreateRecipe()
		.AddIngredient(ItemID.MagicMirror, 1)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 50)
		.Register();
		CreateRecipe()
		.AddIngredient(ItemID.IceMirror, 1)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 50)
		.Register();
	}
}
