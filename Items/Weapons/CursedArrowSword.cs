using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CursedArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Shoots Cursed arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.5f;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 44;
		Item.useAnimation = 22;
		Item.damage = 38;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.CursedArrow;
		Item.shootSpeed = 10f;
		Item.value = 38500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
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
			.AddIngredient(ItemID.CursedArrow, 500)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
