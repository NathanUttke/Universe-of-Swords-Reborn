using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class MasterSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Great for impersonating pot smashers'");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 23;
		Item.useAnimation = 25;
		Item.damage = 25;
		Item.knockBack = 4.1f;
		Item.UseSound = SoundID.Item1;
		Item.value = 9800;
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
		val.AddIngredient(Mod, "SwordMatter", 80);
		val.AddRecipeGroup("IronBar", 20);
		val.AddIngredient(ItemID.CopperBroadsword, 1);
		val.AddTile(TileID.Anvils);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(Mod, "SwordMatter", 80);
		val2.AddRecipeGroup("IronBar", 20);
		val2.AddIngredient(ItemID.TinBroadsword, 1);
		val2.AddTile(TileID.Anvils);
		val2.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
	}
}
