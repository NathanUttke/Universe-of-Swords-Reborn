using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GemSlayer : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Inflicts Midas debuff on enemies");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 24;
		Item.useAnimation = 24;
		Item.damage = 29;
		Item.knockBack = 5.7f;
		Item.UseSound = SoundID.Item1;
		Item.value = 20000;
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
		val.AddIngredient(Mod, "TopazSword", 1);
		val.AddIngredient(Mod, "SapphireSword", 1);
		val.AddIngredient(Mod, "EmeraldSword", 1);
		val.AddIngredient(Mod, "AmethystSword", 1);
		val.AddIngredient(Mod, "EmeraldSword", 1);
		val.AddIngredient(Mod, "AmberSword", 1);
		val.AddIngredient(Mod, "DiamondSword", 1);
		val.AddIngredient(Mod, "RubySword", 1);
		val.AddIngredient(Mod, "SwordMatter", 60);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
	}
}
