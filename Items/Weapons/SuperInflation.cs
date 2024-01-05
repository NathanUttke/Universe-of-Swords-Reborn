using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SuperInflation : ModItem
{
    public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("'Throw money at ALL your problems'\n15% more damage if the player has a gold coin.");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 10f;
		Item.useTime = 48;
		Item.useAnimation = 20;
		Item.damage = 130;
        //Item.shoot = ProjectileID.GoldCoin;
        Item.shoot = ModContent.ProjectileType<SuperInflationHoldoutProj>();
        Item.shootSpeed = 9f;
		Item.value = 0;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
        Item.noMelee = true;
        Item.noUseGraphic = true;
	}

    /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int i = 0; i < 3; i++)
        {
            float f = 0.25f * i * MathHelper.TwoPi;
            Vector2 vector51 = player.RotatedRelativePoint(player.itemLocation) + f.ToRotationVector2() * MathHelper.Lerp(20f, 60f, 0.25f * i);
            vector51.Y -= player.height / 2f;

            Vector2 v5 = Main.MouseWorld - vector51;
            Vector2 vector52 = velocity.SafeNormalize(Vector2.UnitY) * Item.shootSpeed;
            v5 = v5.SafeNormalize(vector52) * Item.shootSpeed;
            v5 = Vector2.Lerp(v5, vector52, 0.25f);
            Projectile coinProj = Projectile.NewProjectileDirect(source, vector51, v5, type, damage / 3, knockback, player.whoAmI);
            coinProj.timeLeft = 40;
        }

        return false;
    }*/

    public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<Inflation>(), 1)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 50)
		.AddIngredient(ModContent.ItemType<Orichalcon>(), 8)
		.AddIngredient(ItemID.LunarBar, 5)
		.AddTile(TileID.LunarCraftingStation)
		.Register();
	}

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
		player.itemLocation = player.Center;
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (player.HasItem(ItemID.GoldCoin))
        {
            damage *= 1.15f;
        }
    }

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
        ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.Keybrand, new ParticleOrchestraSettings
        {
            PositionInWorld = target.Center,
            MovementVector = player.itemRotation.ToRotationVector2() * 5f * 0.1f + Main.rand.NextVector2Circular(2f, 2f)

        }, player.whoAmI);

        if (!target.HasBuff(BuffID.Midas))
        {
            target.AddBuff(BuffID.Midas, 500);
        }
    }
}
