using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class OrcWarSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Big and heavy sword of orcs that requires a lot of strenght to wield");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.9f;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 55;
		Item.useAnimation = 55;
		Item.damage = 45;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 29000;
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{
		
																								Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.IronBar, 25);
		val.AddIngredient(Mod, "BiggoronSword", 1);
		val.AddIngredient(Mod, "SwordMatter", 70);
		val.AddTile(TileID.Anvils);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(ItemID.LeadBar, 25);
		val2.AddIngredient(Mod, "BiggoronSword", 1);
		val2.AddIngredient(Mod, "SwordMatter", 70);
		val2.AddTile(TileID.Anvils);
		val2.Register();
	}
}
