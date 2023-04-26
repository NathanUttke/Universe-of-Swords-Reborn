using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Projectiles;
using System.Diagnostics.Tracing;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Items.Placeable;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SwordOfTheMultiverse : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword of the Multiverse");
		Tooltip.SetDefault("'WARNING! Do NOT craft this Sword! Crafting it will break the game AND your sanity!'");
	}

	public override void SetDefaults()
	{
		Item.width = 94;
		Item.height = 112;
		Item.rare = ItemRarityID.Expert;
		
		Item.useTime = 18;
		Item.useAnimation = 18;        

        Item.damage = 190;
        Item.DamageType = DamageClass.Melee;
        Item.crit = 70;
        Item.knockBack = 2f;

		Item.value = Item.sellPrice(22, 0, 0, 0);

        Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item169;

        Item.channel = true;
        Item.autoReuse = true;

        Item.shoot = ModContent.ProjectileType<SwordOfTheMultiverseProjectile>();
        Item.shootSpeed = 12f;

		SacrificeTotal = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Projectile.NewProjectile(source, position, velocity / 2, Item.shoot, (int)(Item.damage * 1.25f), 3f, player.whoAmI);
		return true;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            Dust dust = Main.dust[Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.DemonTorch, 0f, 0f, 100, default, 2f)];
            dust.noGravity = true;
        }
    }

    public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<GreatswordOfTheCosmos>(), 1)
            .AddIngredient(ModContent.ItemType<SwordOfTheUniverseV2>(), 1)
			.AddIngredient(ModContent.ItemType<DamascusBar>(), 50)
            .AddIngredient(ModContent.ItemType<Orichalcon>(), 30)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 15)
            .AddIngredient(ModContent.ItemType<UselessWeapon>(), 1)
			.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (!target.HasBuff(ModContent.BuffType<EmperorBlaze>()))
		{
            target.AddBuff(ModContent.BuffType<EmperorBlaze>(), 800, true);
        }		
	}
}
