using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DragonsDeath : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Dragon's Death");
		Tooltip.SetDefault("'It's great for impersonating dragon hunters'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 140;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item169;
		Item.noMelee = true;
		Item.noUseGraphic = true;
		Item.shoot = ModContent.ProjectileType<DragonsDeathProjectile>();
		Item.shootSpeed = 1f;
		Item.value = 490500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.MeleeNoSpeed; 
		SacrificeTotal = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        return base.Shoot(player, source, position, velocity, type, damage, knockback);
    }
}
