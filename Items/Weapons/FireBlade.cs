using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FireBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Fire Blade");
		Tooltip.SetDefault("Inflicts enemies with On Fire!");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 40;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 15;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item20;
		Item.value = Item.sellPrice(0, 0, 25, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{	
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.AshBlock, 100);
		val.AddIngredient(ItemID.Torch, 50);
		val.AddIngredient(Mod, "SwordMatter", 20);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(24, 200, false);
	}
}
