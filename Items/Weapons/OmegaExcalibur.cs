using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class OmegaExcalibur : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.damage = 77;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item1;
		Item.value = 680000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= -3f * player.gravDir;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
											
				if (Main.rand.Next(2) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.IceTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity.X += (float)player.direction * 2f;
			Main.dust[dust].velocity.Y += 0.2f;
		}
	}

	public override void AddRecipes()
	{
		
																								Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.Excalibur, 1);
		val.AddIngredient(ItemID.SoulofFright, 10);
		val.AddIngredient(ItemID.SoulofMight, 10);
		val.AddIngredient(ItemID.SoulofSight, 10);
		val.AddIngredient(ItemID.HallowedBar, 10);
		val.AddIngredient(ItemID.LightShard, 1);
		val.AddIngredient(Mod, "Orichalcon", 1);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddIngredient(Mod, "SwordMatter", 150);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
