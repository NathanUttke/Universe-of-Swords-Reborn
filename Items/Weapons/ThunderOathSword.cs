using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ThunderOathSword : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Thunder Oath Sword");
		Tooltip.SetDefault("'Most electrifying experience yet'");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.3f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 40;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item92;
		Item.shoot = ProjectileID.Electrosphere;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 2, 0, 0);
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
		val.AddIngredient(ItemID.BrokenHeroSword, 1);
		val.AddIngredient(ItemID.Starfury, 1);
		val.AddIngredient(Mod, "UpgradeMatter", 2);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
