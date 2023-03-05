using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheForce : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.scale = 1f;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 28;
		Item.useAnimation = 28;
		Item.damage = 30;
		Item.knockBack = 5.5f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.Starfury;
		Item.shootSpeed = 20f;
		Item.value = 74800;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		
		
		
		
					
		if (Main.rand.Next(1) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.MagicMirror, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
				
														Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.Starfury, 1);
		val.AddIngredient(Mod, "MasterSword", 1);
		val.AddIngredient(Mod, "LavaSword", 1);
		val.AddIngredient(ItemID.HellstoneBar, 15);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddIngredient(Mod, "SwordMatter", 150);
		val.AddTile(TileID.DemonAltar);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(69, 360, false);
		target.AddBuff(24, 360, false);
		target.AddBuff(72, 360, false);
	}
}
