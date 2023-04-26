using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Uriziel : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Sword of great warrior called Uriziel");
	}

	public override void SetDefaults()
	{
		Item.width = 110;
		Item.height = 110;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 13;
		Item.useAnimation = 13;
		Item.damage = 130;
		Item.knockBack = 15f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 30, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 200);
		val.AddIngredient(Mod, "UpgradeMatter", 4);
		val.AddIngredient(Mod, "WeirdSword", 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(69, 360, false);
		target.AddBuff(24, 360, false);
	}
}
