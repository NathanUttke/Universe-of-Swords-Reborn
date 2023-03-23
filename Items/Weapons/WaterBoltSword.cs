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
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 66;
		Item.useAnimation = 33;
		Item.damage = 14;
		Item.knockBack = 6f;
		Item.shoot = ProjectileID.WaterBolt;
		Item.shootSpeed = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 48500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		SacrificeTotal = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, (int)(damage*0.25f), knockback, player.whoAmI);
		proj.tileCollide = false;
		proj.timeLeft = 140;
        proj.DamageType = DamageClass.MeleeNoSpeed;
        return false;
    }

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
		velocity = velocity.RotatedBy(MathHelper.ToRadians(20f));
    }
}
