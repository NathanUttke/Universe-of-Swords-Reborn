using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Golem : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Ancient sword that was inside Golems body");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 21;
		Item.useAnimation = 21;
		Item.damage = 90;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item12;
		Item.value = 280000;
		Item.shoot = ProjectileID.HeatRay;
		Item.shootSpeed = 10f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
	}
}
