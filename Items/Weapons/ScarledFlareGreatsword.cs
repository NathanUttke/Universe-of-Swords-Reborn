using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ScarledFlareGreatsword : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Scarlet Flare Greatsword");
	}

	public override void SetDefaults()
	{
		Item.width = 120;
		Item.height = 120;
		Item.rare = ItemRarityID.Red;

		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 20;

		Item.damage = 120;
		Item.knockBack = 6f;
		Item.scale = 1f;
		Item.crit = 6;
		Item.noUseGraphic = true;
		Item.noMelee = true;
		Item.shootSpeed = 20f;
		Item.shoot = ProjectileType<ScarledGreatswordProjectile>();
		Item.UseSound = SoundID.Item169;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
        return false;
    }
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }
	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.RedTorch, 0f, 0f, 100, default, 1.75f);
			Main.dust[dust].noGravity = true;
		}
	}
    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (!target.HasBuff(BuffID.OnFire))
		{
            target.AddBuff(BuffID.OnFire, 600, false);
        }
	}
	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemType<SwordMatter>(), 50)
		.AddIngredient(ItemType<RedFlareLongsword>(), 1)
		.AddIngredient(ItemType<ScarledFlareGreatsword>(), 1)
		.AddIngredient(ItemType<TheNightmareAmalgamation>(), 1)
        .AddIngredient(ItemID.BrokenHeroSword, 1)
        .AddTile(TileID.LunarCraftingStation)
		.Register();
	}
}
