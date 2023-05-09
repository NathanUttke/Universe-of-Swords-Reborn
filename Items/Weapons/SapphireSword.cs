using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SapphireSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 38;
		Item.height = 44;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Blue;

		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
        Item.UseSound = SoundID.Item1;

        Item.damage = 15;
		Item.knockBack = 3f;		
		Item.value = Item.sellPrice(0, 0, 20, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{					
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.BlueTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
								Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.Sapphire, 5);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
