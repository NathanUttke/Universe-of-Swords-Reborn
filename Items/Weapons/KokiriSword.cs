using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class KokiriSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 44;
		Item.height = 44;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 12;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item1;
		Item.value = 9000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.Wood, 30);
		val.AddIngredient(ItemID.Ruby, 1);
		val.AddIngredient(Mod, "SwordMatter", 20);
		val.AddTile(TileID.WorkBenches);
		val.Register();
	}
}
