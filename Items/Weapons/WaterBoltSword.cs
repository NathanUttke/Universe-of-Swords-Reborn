using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class WaterBoltSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.Size = new(64);
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 50;
		Item.useAnimation = 50;
		Item.damage = 13;
		Item.knockBack = 6f;
		Item.shoot = ModContent.ProjectileType<WaterBoltProj>();
		Item.shootSpeed = 4f;
		Item.UseSound = SoundID.Item1;
		Item.value = 48500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectileDirect(source, position + velocity * 8f, velocity, type, damage / 2, knockback, player.whoAmI);
        return false;
    }
}
