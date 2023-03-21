using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 15;
		Item.knockBack = 6f;
		Item.shoot = ProjectileID.VilethornBase;
		Item.shootSpeed = 20f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		
		
		
		
								if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.GrassBlades, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
				
																												Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.Vilethorn, 1);
		val.AddIngredient(ItemID.Seed, 10);
		val.AddIngredient(ItemID.Daybloom, 5);
		val.AddIngredient(ItemID.DirtBlock, 100);
		val.AddIngredient(Mod, "SwordMatter", 40);
		val.AddTile(TileID.Anvils);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(ItemID.TheRottedFork, 1);
		val2.AddIngredient(ItemID.Seed, 10);
		val2.AddIngredient(ItemID.Daybloom, 5);
		val2.AddIngredient(ItemID.DirtBlock, 100);
		val2.AddIngredient(Mod, "SwordMatter", 40);
		val2.AddTile(TileID.Anvils);
		val2.Register();
	}
}
