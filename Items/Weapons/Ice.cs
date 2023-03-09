using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Ice : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Winter is coming'");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.scale = 1.5f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 12;
		Item.useAnimation = 12;
		Item.damage = 100;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item1;
		Item.value = 200000;
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
		val.AddIngredient(Mod, "UpgradeMatter", 4);
		val.AddIngredient(Mod, "Orichalcon", 1);
		val.AddIngredient(Mod, "Orcrist", 1);
		val.AddIngredient(Mod, "Glamdring", 1);
		val.AddIngredient(Mod, "Sting", 1);
		val.AddIngredient(ItemID.Sapphire, 10);
		val.AddIngredient(ItemID.Ruby, 10);
		val.AddIngredient(ItemID.Emerald, 10);
		val.AddIngredient(ItemID.Topaz, 10);
		val.AddIngredient(ItemID.Amethyst, 10);
		val.AddIngredient(ItemID.Diamond, 10);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(44, 360, false);
	}
}
