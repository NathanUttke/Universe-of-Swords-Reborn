using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class OnyxSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Onyx");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 40;
		Item.knockBack = 7.7f;
		Item.shoot = ProjectileID.BlackBolt;
		Item.shootSpeed = 15f;
		Item.UseSound = SoundID.Item1;
		Item.value = 70500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		
												Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 170);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddIngredient(ItemID.OnyxBlaster, 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
