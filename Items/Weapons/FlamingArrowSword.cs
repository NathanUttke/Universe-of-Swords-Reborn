using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FlamingArrowSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
        Item.Size = new(64);
		Item.rare = ItemRarityID.White;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 60;
		Item.useAnimation = 30;
		Item.damage = 18;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.FireArrow;
		Item.shootSpeed = 10f;
		Item.value = 4500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
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
			.AddIngredient(ItemID.FlamingArrow, 500)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
