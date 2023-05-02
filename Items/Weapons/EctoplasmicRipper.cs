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
		Item.damage = 75;
		Item.crit = 2;
		Item.DamageType = DamageClass.Magic; 
		Item.width = 54;
		Item.height = 54;

		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.useStyle = ItemUseStyleID.Swing;

		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 1, 40, 0);
		Item.rare = ItemRarityID.Cyan;
		Item.scale = 1.25f;
		Item.UseSound = SoundID.Item103;
		Item.autoReuse = true;
		Item.useTurn = true;

		Item.mana = 15;
        SacrificeTotal = 1;
    }

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{				
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.MagicMirror, 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ItemID.SpectreBar, 15)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		int healingAmt = damage / 8;
		if (Main.rand.NextBool(3))
		{
            player.statMana += healingAmt;
            player.HealEffect(healingAmt, true);
        }		
	}
}
