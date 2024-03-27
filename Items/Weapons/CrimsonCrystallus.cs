using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CrimsonCrystallus : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 44;
		Item.height = 52;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 50;
		Item.useAnimation = 25;
		Item.damage = 18;
		Item.knockBack = 5f;
		Item.shoot = ModContent.ProjectileType<Tier2CProjectile>();
		Item.shootSpeed = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{					
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 100, Color.Salmon, 1.25f);
			Main.dust[dust].noGravity = true;
		}
	}
    public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<Crystallus>(), 1)
		.AddIngredient(ItemID.CrimtaneBar, 12)
		.AddIngredient(ItemID.TissueSample, 8)
		.AddTile(TileID.Anvils)
		.Register();
        CreateRecipe()
		.AddIngredient(ModContent.ItemType<CorruptCrystallus>(), 1)
		.AddTile(TileID.DemonAltar)
		.Register();
    }
}
