using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class WoodenArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Shoots Wooden Arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.White;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 60;
		Item.useAnimation = 30;
		Item.damage = 8;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.WoodenArrowFriendly;
		Item.shootSpeed = 10f;
		Item.value = 3500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		Item.ResearchUnlockCount = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
        proj.timeLeft = 20;
        proj.DamageType = DamageClass.MeleeNoSpeed;
        return false;
    }

    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ItemID.WoodenArrow, 500)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 10)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
