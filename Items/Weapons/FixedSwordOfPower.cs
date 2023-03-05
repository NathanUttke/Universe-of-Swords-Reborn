using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FixedSwordOfPower : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Inflicts Midas debuff on enemies");
	}

	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 35;
		Item.scale = 1.7f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 37;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item1;
		Item.value = 18000;
		Item.shoot = ProjectileID.Bone;
		Item.shootSpeed = 20f;
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
		val.AddIngredient(Mod, "SwordOfPower", 1);
		val.AddIngredient(ItemID.Bone, 20);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddIngredient(Mod, "SwordMatter", 110);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
	}
}
