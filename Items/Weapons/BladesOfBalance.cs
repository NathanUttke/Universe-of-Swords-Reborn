using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BladesOfBalance : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Blades of Balance");
	}

	public override void SetDefaults()
	{
		Item.damage = 51;
		Item.crit = 2;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
		Item.width = 54;
		Item.height = 54;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 7f;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.rare = ItemRarityID.LightPurple;
		Item.scale = 1.2f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
		Item.useTurn = true;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
											
																		if (Main.rand.Next(2) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.PinkTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity.X += (float)player.direction * 0f;
			Main.dust[dust].velocity.Y += 0f;
			dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.VilePowder, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity.X += (float)player.direction * 0f;
			Main.dust[dust].velocity.Y += 0f;
		}
	}

	public override void AddRecipes()
	{
		
																		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
		val.AddIngredient(ItemID.FrostCore, 1);
		val.AddIngredient(ItemID.LightShard, 1);
		val.AddIngredient(ItemID.DarkShard, 1);
		val.AddIngredient(ItemID.SoulofNight, 10);
		val.AddIngredient(ItemID.SoulofLight, 10);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
