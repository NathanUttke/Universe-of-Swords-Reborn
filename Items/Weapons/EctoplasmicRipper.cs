using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class EctoplasmicRipper : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Steals mana points upon hit");
	}

	public override void SetDefaults()
	{
		Item.damage = 72;
		Item.crit = 2;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
		Item.width = 54;
		Item.height = 54;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 15, 0, 0);
		Item.rare = ItemRarityID.Cyan;
		Item.scale = 1f;
		Item.UseSound = SoundID.Item103;
		Item.autoReuse = true;
		Item.useTurn = true;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		
		
		
		
					
		if (Main.rand.NextBool(1))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.MagicMirror, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
												Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.Ectoplasm, 15);
		val.AddIngredient(ItemID.SpectreBar, 10);
		val.AddIngredient(Mod, "DeathSword", 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		int healingAmt = damage / 8;
		player.statMana += healingAmt;
		player.HealEffect(healingAmt, true);
	}
}
