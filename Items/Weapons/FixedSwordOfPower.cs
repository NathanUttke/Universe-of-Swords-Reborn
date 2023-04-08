using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Items.Misc;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FixedSwordOfPower : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword Of Power");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 40;
		Item.useAnimation = 20;
		Item.damage = 35;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.value = 18000;
		Item.shoot = ProjectileID.Bone;
		Item.shootSpeed = 16f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<SwordOfPower>(), 1)
            .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 1)
            .AddIngredient(ItemID.Bone, 150)
			.AddTile(TileID.Anvils)
			.Register();
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Projectile.NewProjectile(source, position, velocity, type, (int)(damage * 0.5f + Main.rand.Next(0, 10)), knockback, player.whoAmI);
		return false;
    }
}
