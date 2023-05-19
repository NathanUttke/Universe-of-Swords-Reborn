using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GrandPiano : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Grand Piano");
		Tooltip.SetDefault("'Rage Quit - Horrior'");
	}

	public override void SetDefaults()
	{
		Item.width = 142;
		Item.height = 142;
		Item.rare = ItemRarityID.Orange;
		Item.crit = 11;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 120;
		Item.knockBack = 8f;
		Item.UseSound = new SoundStyle($"{nameof(UniverseOfSwordsMod)}/Sounds/Item/GrandPiano");
		Item.shoot = ProjectileID.WoodenArrowFriendly;
		Item.shootSpeed = 20f;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation = player.Center;
	}
	public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(Mod, "PianoSword1", 1)
		.AddIngredient(Mod, "PianoSword2", 1)
		.AddIngredient(Mod, "PianoSword3", 1)
		.AddIngredient(Mod, "PianoSword4", 1)
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 3)
		.AddTile(TileID.Autohammer)
		.Register();
	}
	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
        Vector2 pointPosition = new Vector2(player.position.X + player.width * 0.5f + (float)(Main.rand.Next(201) * -player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
        Projectile.NewProjectile(source, pointPosition, new Vector2(0f, 20f), ProjectileID.QuarterNote, damage / 2, knockback, player.whoAmI);
        return false;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(20, 360, false);
		target.AddBuff(144, 360, false);
		target.AddBuff(30, 360, false);
		target.AddBuff(72, 360, false);
		target.AddBuff(153, 360, false);
		target.AddBuff(44, 360, false);
		target.AddBuff(137, 360, false);
		target.AddBuff(70, 360, false);
	}
}
