using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class MoltenShard : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Inflicts On Fire! debuff");
	}

	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 56;
		Item.scale = 1f;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 36;
		Item.knockBack = 7f;
		Item.shoot = Mod.Find<ModProjectile>("MoltenShard").Type;
		Item.shootSpeed = 5f;
		Item.UseSound = SoundID.Item20;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		
		
		
		
					
		if (Main.rand.Next(2) == 0)
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Flare, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
												Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "PoisonCrystallus", 1);
		val.AddIngredient(ItemID.HellstoneBar, 18);
		val.AddIngredient(ItemID.Obsidian, 10);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(24, 400, false);
	}
}
