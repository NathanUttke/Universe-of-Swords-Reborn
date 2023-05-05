using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TwinsSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Whoosh, whoosh!");
	}

	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 20;
		Item.damage = 60;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 160000;
		Item.shoot = ModContent.ProjectileType<TwinsProjectile>();
		Item.shootSpeed = 5.2f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<TwinsProjectile>(), (int)(Item.damage * 0.75f), knockback, player.whoAmI);  
		return false;
    }
}
