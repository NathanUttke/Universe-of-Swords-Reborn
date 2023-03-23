using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Items.Weapons;

public class NatureSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Sword made out of only pure ingredients given from Mother Nature'");
	}

	public override void SetDefaults()
	{
		Item.width = 72;
		Item.height = 72;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 50;
		Item.useAnimation = 25;
		Item.damage = 15;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        if (Main.rand.NextBool(3))
		{
			UniverseUtils.SummonSuperStarSlash(target.position, target.GetSource_OnHit(target), 10, player.whoAmI, ProjectileID.SeedlerThorn);
			//Projectile.NewProjectileDirect(target.GetSource_OnHit(target), target.Center, new Vector2(0f, -20f), ProjectileID.VilethornBase, 8, 3f, player.whoAmI);
		}
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
	{	
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Grass, 0f, 0f, 100, default, 1f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{					
		CreateRecipe()
		.AddIngredient(ItemID.Vilethorn, 1)
		.AddIngredient(ItemID.Seed, 10)
		.AddIngredient(ItemID.Daybloom, 5)
		.AddIngredient(ItemID.DirtBlock, 100)
		.AddIngredient(Mod, "SwordMatter", 40)
		.AddTile(TileID.Anvils)
		.Register();
		CreateRecipe()
		.AddIngredient(ItemID.TheRottedFork, 1)
		.AddIngredient(ItemID.Seed, 10)
		.AddIngredient(ItemID.Daybloom, 5)
		.AddIngredient(ItemID.DirtBlock, 100)
		.AddIngredient(Mod, "SwordMatter", 40)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
