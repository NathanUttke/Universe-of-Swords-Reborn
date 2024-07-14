using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FrostburnArrowSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 44;
		Item.useAnimation = 22;
		Item.damage = 15;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.FrostburnArrow;
		Item.shootSpeed = 10f;
		Item.value = 39500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile frostArrow = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
        frostArrow.timeLeft = 30;
        frostArrow.DamageType = DamageClass.MeleeNoSpeed;
		frostArrow.extraUpdates = 1;
        return false;
    }

    public override void AddRecipes()
	{				
		CreateRecipe()
			.AddIngredient(ItemID.FrostburnArrow, 500)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 12)
			.AddIngredient(ItemID.ShadowScale, 10)
			.AddTile(TileID.Anvils)
			.Register();
        CreateRecipe()
            .AddIngredient(ItemID.FrostburnArrow, 500)
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 12)
            .AddIngredient(ItemID.TissueSample, 10)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
