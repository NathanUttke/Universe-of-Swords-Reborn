using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class VenomArrowSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 44;
		Item.useAnimation = 22;
		Item.damage = 45;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.VenomArrow;
		Item.shootSpeed = 10f;
		Item.value = 36500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
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
			.AddIngredient(ItemID.VenomArrow, 500)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
