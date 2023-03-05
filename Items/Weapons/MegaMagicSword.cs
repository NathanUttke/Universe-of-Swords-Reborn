using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons;

public class MegaMagicSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.scale = 1.3f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 12;
		Item.useAnimation = 12;
		Item.damage = 82;
		Item.knockBack = 10.7f;
		Item.UseSound = new SoundStyle($"{nameof(UniverseOfSwordsMod)}/Sounds/Item/Spell");
		Item.shoot = ProjectileID.SwordBeam;
		Item.shootSpeed = 20f;
		Item.value = 410000;
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
		val.AddIngredient(Mod, "MagicSword", 1);
		val.AddIngredient(Mod, "Orichalcon", 1);
		val.AddIngredient(Mod, "SwordMatter", 100);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
