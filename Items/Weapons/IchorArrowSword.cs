using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class IchorArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Shoots Ichor arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 44;
		Item.useAnimation = 22;
		Item.damage = 40;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.IchorArrow;
		Item.shootSpeed = 10f;
		Item.value = 38500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
		proj.timeLeft = 50;
		proj.DamageType = DamageClass.MeleeNoSpeed;
		return false;
    }

	public override void AddRecipes()
	{				
		CreateRecipe()
			.AddIngredient(ItemID.IchorArrow, 500)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
