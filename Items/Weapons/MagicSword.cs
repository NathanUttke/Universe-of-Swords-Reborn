using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons;

public class MagicSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("You're wizard!");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 35;
		Item.knockBack = 8.55f;
		Item.UseSound = new SoundStyle($"{nameof(UniverseOfSwordsMod)}/Sounds/Item/Spell");
		Item.shoot = ProjectileID.EnchantedBeam;
		Item.shootSpeed = 10f;
		Item.value = 110000;
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
		val.AddIngredient(Mod, "TheForce", 1);
		val.AddIngredient(ItemID.MagicMissile, 1);
		val.AddIngredient(Mod, "SwordMatter", 100);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
