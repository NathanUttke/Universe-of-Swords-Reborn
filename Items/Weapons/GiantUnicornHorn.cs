using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GiantUnicornHorn : ModItem
{
    public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Fabolous!");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightPurple;

		Item.useStyle = ItemUseStyleID.Rapier;
		Item.useTime = 20;
		Item.useAnimation = 20;
        Item.UseSound = SoundID.Item1;

        Item.damage = 55;
		Item.scale = 1.25f;
		Item.knockBack = 7f;

		Item.shoot = ModContent.ProjectileType<UnicornHornProjectile>();
		Item.shootSpeed = 5f;
		
		Item.value = 153000;
		Item.autoReuse = true;
		Item.noMelee = true;
		Item.noUseGraphic = true;
		Item.DamageType = DamageClass.MeleeNoSpeed; 
		SacrificeTotal = 1;
	}

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
		velocity = velocity.RotatedByRandom(MathHelper.ToRadians(20f));
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectile(source, position, velocity * 2.25f, ModContent.ProjectileType<UnicornHornProjectile2>(), 33, knockback, player.whoAmI);
        return true;
    }
}
