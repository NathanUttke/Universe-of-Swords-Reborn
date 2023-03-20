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
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
		Item.width = 54;
		Item.height = 54;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.rare = ItemRarityID.LightPurple;
		Item.scale = 1.1f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
		Item.useTurn = true;
	}
	public override void MeleeEffects(Player player, Rectangle hitbox)
	{											
		if (Main.rand.NextBool(2))
		{
			Dust dust = Main.dust[Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PinkTorch, 0f, 0f, 100, default, 2f)];
			dust.noGravity = true;
			dust.velocity.X += player.direction * 0f;
			dust.velocity.Y += 0f;
			Dust dust2 = Main.dust[Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.VilePowder, 0f, 0f, 100, default, 2f)];
			dust2.noGravity = true;
			dust2.velocity.X += player.direction * 0f;
			dust2.velocity.Y += 0f;
		}
	}
	public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ItemID.AncientBattleArmorMaterial, 1)
			.AddIngredient(ItemID.FrostCore, 1)
			.AddIngredient(ItemID.LightShard, 1)
			.AddIngredient(ItemID.DarkShard, 1)
			.AddIngredient(ItemID.SoulofNight, 10)
			.AddIngredient(ItemID.SoulofLight, 10)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
