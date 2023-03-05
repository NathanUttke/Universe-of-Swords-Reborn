using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class RedRuneBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Life Rune Blade");
		Tooltip.SetDefault("'Pulses with red energy of blood'");
	}

	public override void SetDefaults()
	{
		Item.width = 50;
		Item.height = 50;
		Item.scale = 1.2f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 30;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item103;
		Item.value = Item.sellPrice(0, 1, 0, 0);
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
		val.AddIngredient(ItemID.DripplerBanner, 1);
		val.AddIngredient(ItemID.BloodZombieBanner, 1);
		val.AddIngredient(Mod, "DamascusBar", 10);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		int healingAmt = damage / 15;
		player.statLife += healingAmt;
		player.HealEffect(healingAmt, true);
	}
}
