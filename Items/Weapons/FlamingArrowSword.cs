using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FlamingArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Flaming arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.White;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 18;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.FireArrow;
		Item.shootSpeed = 10f;
		Item.value = 4500;
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
			.AddIngredient(ItemID.FlamingArrow, 500)
			.AddIngredient(Mod, "SwordMatter", 200)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
