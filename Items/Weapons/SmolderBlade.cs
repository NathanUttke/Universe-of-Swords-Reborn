using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SmolderBlade : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 42;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Thrust;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 30;
		Item.knockBack = 2.4f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		
		
		
		
					
		if (Main.rand.NextBool(1))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Flare, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
										Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.HellstoneBar, 10);
		val.AddIngredient(Mod, "SwordMatter", 15);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(24, 300, false);
	}
}
