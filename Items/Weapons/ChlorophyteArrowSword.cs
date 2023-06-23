using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ChlorophyteArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Chlorophyte arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 40;
		Item.useAnimation = 20;
		Item.damage = 68;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.ChlorophyteArrow;
		Item.shootSpeed = 10f;
		Item.value = 78500;
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
			.AddIngredient(ItemID.ChlorophyteArrow, 500)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 15)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
