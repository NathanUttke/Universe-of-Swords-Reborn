using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BetterShroomiteBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Bigger and better!");
	}

	public override void SetDefaults()
	{
		Item.width = 68;
		Item.height = 68;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 75;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item1;
		Item.value = 380000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		Item.scale = 1.20f;
		SacrificeTotal = 1;
	}

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
		UniverseUtils.EmitHammushProjectiles(player, player.whoAmI, Item, hitbox, Item.damage, ProjectileID.Mushroom);
    }

    public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<ShroomiteBlade>(), 1)
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 3)
		.AddIngredient(ItemID.ShroomiteBar, 15)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
