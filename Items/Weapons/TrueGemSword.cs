using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TrueGemSword : ModItem
{
    public override void SetStaticDefaults()
    {
		DisplayName.SetDefault("True Gem Blade");
    }
    public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 20;
		Item.shoot = ProjectileID.EmeraldBolt;
		Item.shootSpeed = 10f;
		Item.damage = 20;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	
	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		int projToShoot = Utils.SelectRandom(Main.rand, ProjectileID.EmeraldBolt, ProjectileID.DiamondBolt, ProjectileID.AmethystBolt, ProjectileID.TopazBolt, ProjectileID.SapphireBolt, ProjectileID.RubyBolt, ProjectileID.AmberBolt);
        Projectile gemProj = Projectile.NewProjectileDirect(source, position, velocity, projToShoot, damage, knockback, player.whoAmI);
		gemProj.DamageType = DamageClass.MeleeNoSpeed;
        return false;
    }

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.YellowTorch, 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
			dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.TintableDustLighted, 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
		}
	}

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ModContent.ItemType<TopazSword>(), 1)
        .AddIngredient(ModContent.ItemType<SapphireSword>(), 1)
        .AddIngredient(ModContent.ItemType<EmeraldSword>(), 1)
        .AddIngredient(ModContent.ItemType<AmethystSword>(), 1)
        .AddIngredient(ModContent.ItemType<AmberSword>(), 1)
        .AddIngredient(ModContent.ItemType<DiamondSword>(), 1)
        .AddIngredient(ModContent.ItemType<RubySword>(), 1)
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 2)
        .AddIngredient(ItemID.ShadowScale, 15)
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
	}
}
