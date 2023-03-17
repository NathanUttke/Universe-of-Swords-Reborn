using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Nightlight : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 56;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Purple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 84;
		Item.knockBack = 8f;
		Item.shoot = Mod.Find<ModProjectile>("Nightlight").Type;
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 20, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
											
																		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.PinkTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.VilePowder, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
												Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "FrozenShard", 1);
		val.AddIngredient(ItemID.SoulofNight, 15);
		val.AddIngredient(ItemID.SoulofLight, 15);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
