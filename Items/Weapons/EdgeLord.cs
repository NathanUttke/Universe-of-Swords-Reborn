using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class EdgeLord : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("'Blood for the Blood God! Skulls for the skull throne! Milk for the Khorne flakes!'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 90;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item169;
		Item.shoot = ModContent.ProjectileType<EdgeLordProjectile>();
		Item.shootSpeed = 20f;
		Item.value = 800000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
        Item.holdStyle = ItemHoldStyleID.HoldGolfClub;
    }

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.MoonStone, 1)
			.AddIngredient(ItemID.HellstoneBar, 50)
			.AddIngredient(ItemID.SunStone, 1)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 35)
			.AddIngredient(ItemID.DeathSickle, 1)			
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (!target.HasBuff(BuffID.Bleeding))
		{
			target.AddBuff(BuffID.Bleeding, 400);
		}

        if (Main.rand.NextBool(3) && !NPCID.Sets.CountsAsCritter[target.type] && target.type != NPCID.TargetDummy)
        {
            float stealDamage = Main.rand.Next(1, 5);
            if ((int)stealDamage != 0 && !(Main.player[player.whoAmI].lifeSteal <= 0f))
            {
                Main.player[player.whoAmI].lifeSteal -= stealDamage;
                int playerOwner = player.whoAmI;
                Projectile.NewProjectile(Projectile.GetSource_None(), target.Center.X, target.Center.Y, 0f, 0f, ProjectileID.VampireHeal, 0, 0f, playerOwner, playerOwner, stealDamage);
            }
        }
    }
}
