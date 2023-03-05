using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PoisonCrystallus : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Inflicts Poisoned debuff");
	}

	public override void SetDefaults()
	{
		Item.width = 44;
		Item.height = 54;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 22;
		Item.knockBack = 6f;
		Item.shoot = Mod.Find<ModProjectile>("Poison").Type;
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		
		
		
		
					
		if (Main.rand.Next(2) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.JungleGrass, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
																								Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "CorruptCrystallus", 1);
		val.AddIngredient(ItemID.Stinger, 14);
		val.AddIngredient(ItemID.JungleSpores, 9);
		val.AddTile(TileID.Anvils);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(Mod, "CrimsonCrystallus", 1);
		val2.AddIngredient(ItemID.Stinger, 14);
		val2.AddIngredient(ItemID.JungleSpores, 9);
		val2.AddTile(TileID.Anvils);
		val2.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(20, 300, false);
	}
}
