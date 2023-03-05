using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ShadowbeamSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 68;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item72;
		Item.shoot = ProjectileID.ShadowBeamFriendly;
		Item.shootSpeed = 10f;
		Item.value = 510500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{
		
												Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.ShadowbeamStaff, 1);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddIngredient(Mod, "SwordMatter", 130);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
