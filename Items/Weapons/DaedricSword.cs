using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DaedricSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Left click to shoot red beam projectile\nRight click to swing weapon and steal life from enemies");
	}

	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 58;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.knockBack = 6f;
		Item.damage = 30;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.knockBack = 6f;
			Item.damage = 30;
			Item.shoot = ProjectileID.None;
		}
		else
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.knockBack = 4f;
			Item.damage = 25;
			Item.shootSpeed = 20f;
			Item.shoot = Mod.Find<ModProjectile>("ScarletFlareBolt").Type;
		}
		return base.CanUseItem(player);
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		if (player.altFunctionUse == 2)
		{
			int healingAmt = damage / 17;
			player.statLife += healingAmt;
			player.HealEffect(healingAmt, true);
		}
		else
		{
			target.AddBuff(24, 400, false);
		}
	}
}
