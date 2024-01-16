using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class UnholyArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Shoots Unholy arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Blue;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 50;
		Item.useAnimation = 25;
		Item.damage = 15;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.UnholyArrow;
		Item.shootSpeed = 10f;
		Item.value = 8500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
        proj.timeLeft = 30;
        proj.DamageType = DamageClass.MeleeNoSpeed;
        return false;
    }

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.UnholyArrow, 500)			
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 15)			
			.AddTile(TileID.Anvils)
			.Register();
	}
}
