using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DeusExcalibur : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'The Sword of (My) Life and (Your) Death'");
	}

	public override void SetDefaults()
	{
		Item.damage = 200;
		Item.crit = 10;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
		Item.width = 88;
		Item.height = 88;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 12f;
		Item.value = Item.sellPrice(1, 0, 0, 0);
		Item.rare = ItemRarityID.Purple;
		Item.scale = 2.5f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
		Item.useTurn = true;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{											
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.IceTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity.X += (float)player.direction * 0f;
			Main.dust[dust].velocity.Y += 0f;
			dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.PinkTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity.X += (float)player.direction * 0f;
			Main.dust[dust].velocity.Y += 0f;
		}
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.TrueExcalibur, 1);
		val.AddIngredient(Mod, "CrystalExcalibur", 1);
		val.AddIngredient(Mod, "LunarOrb", 1);
		val.AddIngredient(Mod, "Orichalcon", 5);
		val.AddIngredient(Mod, "UpgradeMatter", 8);
		val.AddTile(TileID.DemonAltar);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		int healingAmt = damage / 15;
		player.statLife += healingAmt;
		player.HealEffect(healingAmt, true);
	}
}
