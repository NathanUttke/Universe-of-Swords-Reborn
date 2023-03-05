using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class AncientKatana : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 68;
		Item.rare = ItemRarityID.LightPurple;
		Item.scale = 1.4f;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 9;
		Item.useAnimation = 9;
		Item.damage = 70;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.value = 600000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{

		
		
		
								if (Main.rand.Next(3) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.PortalBoltTrail, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
																						Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 250);
		val.AddIngredient(Mod, "Orichalcon", 1);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.SoulofMight, 10);
		val.AddIngredient(ItemID.SoulofLight, 10);
		val.AddIngredient(ItemID.ChlorophyteBar, 20);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddIngredient(ItemID.Katana, 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
