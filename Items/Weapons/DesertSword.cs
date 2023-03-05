using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DesertSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.6f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 26;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 10, 0);
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
		val.AddIngredient(ItemID.AntlionMandible, 5);
		val.AddIngredient(ItemID.SandBlock, 50);
		val.AddIngredient(Mod, "SwordMatter", 40);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
