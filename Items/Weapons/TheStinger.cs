using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheStinger : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots deadly Stingers");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 62;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 23;
		Item.knockBack = 5f;
		Item.shoot = ProjectileID.HornetStinger;
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		
												Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 100);
		val.AddIngredient(ItemID.Vine, 1);
		val.AddIngredient(ItemID.Stinger, 14);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		
		
		
		
								if (Main.rand.Next(4) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Chlorophyte, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}
}
