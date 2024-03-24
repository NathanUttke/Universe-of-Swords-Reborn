using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SolBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Unleashes small spread of meteors");
	}

	public override void SetDefaults()
	{
		Item.width = 82;
		Item.height = 86;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;

		Item.useTime = 30;
		Item.useAnimation = 20;

		Item.damage = 85;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item70;
		Item.shootSpeed = 12f;
		Item.shoot = ModContent.ProjectileType<Armageddon>();
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Orange, 1.5f);
		}
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
        for (int i = -1; i <= 1; i++)
        {
            Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.ToRadians(15f * i));
            Projectile.NewProjectileDirect(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI, 0f, 0f);
        }
        return false;
	}
}
