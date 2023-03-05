using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CalculatorSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Sprite was made in the calculator. True story.");
	}

	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 52;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 20;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.buyPrice(0, 0, 20, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{

		
		
		
					
		if (Main.rand.Next(4) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.WhiteTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
																								Recipe val = CreateRecipe(1);
		val.AddRecipeGroup("IronBar", 5);
		val.AddIngredient(ItemID.CopperBar, 10);
		val.AddIngredient(Mod, "SwordMatter", 20);
		val.AddTile(TileID.Anvils);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddRecipeGroup("IronBar", 5);
		val2.AddIngredient(ItemID.TinBar, 10);
		val2.AddIngredient(Mod, "SwordMatter", 20);
		val2.AddTile(TileID.Anvils);
		val2.Register();
	}
}
