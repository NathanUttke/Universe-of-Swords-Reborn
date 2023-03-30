using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BoneArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Bone arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 50;
		Item.useAnimation = 25;
		Item.damage = 20;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.BoneArrow;
		Item.shootSpeed = 10f;
		Item.value = 14800;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
		proj.DamageType = DamageClass.MeleeNoSpeed;
		return false;
    }

	public override void AddRecipes()
	{				
		CreateRecipe()
			.AddIngredient(ItemID.BoneArrow, 500)
			.AddIngredient(Mod, "SwordMatter", 200)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
