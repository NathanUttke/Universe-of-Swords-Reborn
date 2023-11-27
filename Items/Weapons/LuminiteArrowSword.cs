using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class LuminiteArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Shoots Luminite arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 26;
		Item.useAnimation = 13;
		Item.damage = 105;
		Item.knockBack = 9f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.MoonlordArrow;
		Item.shootSpeed = 20f;
		Item.value = 220500;
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
			.AddIngredient(ItemID.MoonlordArrow, 500)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 40)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}
