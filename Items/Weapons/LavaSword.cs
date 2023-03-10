using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class LavaSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Inflicts On Fire! debuff on enemies");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 38;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item1;
		Item.value = 10800;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= -3f * player.gravDir;
		player.itemLocation.X -= 3f * player.gravDir;
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.HellstoneBar, 15);
		val.AddIngredient(ItemID.LavaBucket, 5);
		val.AddIngredient(Mod, "SwordMatter", 110);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(24, 360, false);
	}
}
