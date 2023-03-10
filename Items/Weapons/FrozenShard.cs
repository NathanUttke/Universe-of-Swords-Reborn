using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FrozenShard : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Inflicts Frostburn debuff");
	}

	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 56;
		Item.rare = ItemRarityID.Cyan;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 66;
		Item.knockBack = 8f;
		Item.shoot = Mod.Find<ModProjectile>("Frozen").Type;
		Item.shootSpeed = 5f;
		Item.UseSound = SoundID.Item28;
		Item.value = Item.sellPrice(0, 15, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{				
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Frost, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "VenomShard", 1);
		val.AddIngredient(ItemID.FrostCore, 2);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(44, 500, false);
	}
}
