using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class MagicMirrorBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Magic Mirror Blade");
		Tooltip.SetDefault("'Magic Mirror and sword fused together'");
	}

	public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 64;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.UseSound = SoundID.Item6;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		if (Utils.NextBool(Main.rand, 2))
		{
			Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.1f);
		}
		if (player.itemTime == 0)
		{
			player.itemTime = (int)((float)Item.useTime / PlayerLoader.UseTimeMultiplier(player, Item));
		}
		else
		{
			if (player.itemTime != (int)((float)Item.useTime / PlayerLoader.UseTimeMultiplier(player, Item)) / 2)
			{
				return;
			}
			for (int d = 0; d < 70; d++)
			{
				Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default(Color), 1.5f);
			}
			player.grappling[0] = -1;
			player.grapCount = 0;
			for (int p = 0; p < 1000; p++)
			{
				if (((Entity)Main.projectile[p]).active && Main.projectile[p].owner == player.whoAmI && Main.projectile[p].aiStyle == 7)
				{
					Main.projectile[p].Kill();
				}
			}
			player.Spawn(PlayerSpawnContext.RecallFromItem);
			for (int d2 = 0; d2 < 70; d2++)
			{
				Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.5f);
			}
		}
	}

	public override void AddRecipes()
	{
		
				
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.MagicMirror, 1);
		val.Register();
	}
}
