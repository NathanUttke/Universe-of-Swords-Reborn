using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DiamondSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 42;
		Item.height = 42;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 16;
		Item.knockBack = 3.5f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 25, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{					
		if (Main.rand.NextBool(5))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.WhiteTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ItemID.Diamond, 5)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 5)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
