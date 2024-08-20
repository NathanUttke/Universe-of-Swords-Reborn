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
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.Size = new(128);
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 10f;
		Item.useTime = 48;
		Item.useAnimation = 20;
		Item.damage = 130;
        Item.shoot = ModContent.ProjectileType<SuperInflationHoldoutProj>();
        Item.shootSpeed = 1f;
		Item.value = 0;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.MeleeNoSpeed; 
        Item.noMelee = true;
        Item.noUseGraphic = true;
	}

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
            PositionInWorld = target.Center + Main.rand.NextVector2Circular(24f, 24f)
        }, player.whoAmI);
        target.AddBuff(BuffID.Midas, 500);
    }
}
