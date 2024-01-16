using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class WaterBoltSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 66;
		Item.useAnimation = 33;
		Item.damage = 13;
		Item.knockBack = 6f;
		Item.shoot = ProjectileID.WaterBolt;
		Item.shootSpeed = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 48500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		Item.ResearchUnlockCount = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage / 2, knockback, player.whoAmI);
		proj.timeLeft = 70;
        proj.DamageType = DamageClass.MeleeNoSpeed;
        return false;
    }
}
