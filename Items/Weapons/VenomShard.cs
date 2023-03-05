using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class VenomShard : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Inflicts Venom debuff");
	}

	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 56;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 56;
		Item.knockBack = 7f;
		Item.shoot = Mod.Find<ModProjectile>("Venom").Type;
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item17;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		
		
		
		
								if (Main.rand.Next(2) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.TeleportationPotion, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
										Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "MoltenShard", 1);
		val.AddIngredient(ItemID.SpiderFang, 10);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(70, 400, false);
	}
}
