using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class HolyArrowSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 50;
		Item.useAnimation = 25;
		Item.damage = 40;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.HolyArrow;
		Item.shootSpeed = 10f;
		Item.value = 30700;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}
	
	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, (int)(damage * 0.5f), knockback, player.whoAmI);
		proj.timeLeft = 30;
        proj.DamageType = DamageClass.MeleeNoSpeed;
        return false;
    }

	public override void AddRecipes()
	{				
		CreateRecipe()
			.AddIngredient(ItemID.HolyArrow, 500)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 30)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
