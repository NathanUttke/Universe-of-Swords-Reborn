using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BlizzardRage : ModItem
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
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 20;
		Item.damage = 51;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.NorthPoleSnowflake;
		Item.shootSpeed = 25f;
		Item.value = 450500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		Item.alpha = 100;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = Main.rand.Next(1, 4);
        Vector2 mousePos = Main.MouseWorld;
        if (mousePos.Y > player.Center.Y - 200f)
        {
            mousePos.Y = player.Center.Y - 200f;
        }
        for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 newPosition = player.Center + new Vector2(-Main.rand.Next(400) * player.direction, -600);
            newPosition.Y -= 100 * i;
            Vector2 newVelocity = Vector2.Normalize(mousePos - newPosition) * Item.shootSpeed;
			Projectile.NewProjectile(source, newPosition, newVelocity, type, damage / 2, knockback, player.whoAmI, 0f, Main.rand.Next(5));
		}
		return false;
	}	
}
