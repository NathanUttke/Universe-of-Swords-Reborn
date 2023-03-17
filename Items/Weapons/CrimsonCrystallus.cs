using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CrimsonCrystallus : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 44;
		Item.height = 54;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 19;
		Item.knockBack = 5f;
		Item.shoot = Mod.Find<ModProjectile>("Tier2CProjectile").Type;
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{					
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Adamantite, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "Crystallus", 1);
		val.AddIngredient(ItemID.CrimtaneBar, 12);
		val.AddIngredient(ItemID.TissueSample, 8);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
