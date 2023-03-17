using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheNightmareAmalgamation : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'The source of your nightmares'");
	}

	public override void SetDefaults()
	{
		Item.width = 110;
		Item.height = 110;
		Item.scale = 0.9f;
		Item.rare = ItemRarityID.Purple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 150;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item71;
		Item.shoot = Mod.Find<ModProjectile>("Nightmare").Type;
		Item.shootSpeed = 15f;
		Item.value = Item.sellPrice(0, 30, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
												for (int i = 0; i < 3; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(12f));
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, Mod.Find<ModProjectile>("Nightmare").Type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
																														if (Main.rand.NextBool(1))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.PurpleTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.PurpleTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(153, 800, false);
	}

	public override void AddRecipes()
	{	
																																																																Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "CthulhuJudge", 1);
		val.AddIngredient(Mod, "StickyGlowstickSword", 1);
		val.AddIngredient(Mod, "TheEater", 1);
		val.AddIngredient(ItemID.BeeKeeper, 1);
		val.AddIngredient(Mod, "SwordOfPower", 1);
		val.AddIngredient(ItemID.BreakerBlade, 1);
		val.AddIngredient(Mod, "PrimeSword", 1);
		val.AddIngredient(Mod, "DestroyerSword", 1);
		val.AddIngredient(Mod, "TwinsSword", 1);
		val.AddIngredient(Mod, "Executioner", 1);
		val.AddIngredient(Mod, "Doomsday", 1);
		val.AddIngredient(Mod, "Sharkron", 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(Mod, "CthulhuJudge", 1);
		val2.AddIngredient(Mod, "StickyGlowstickSword", 1);
		val2.AddIngredient(Mod, "TheBrain", 1);
		val2.AddIngredient(ItemID.BeeKeeper, 1);
		val2.AddIngredient(Mod, "SwordOfPower", 1);
		val2.AddIngredient(ItemID.BreakerBlade, 1);
		val2.AddIngredient(Mod, "PrimeSword", 1);
		val2.AddIngredient(Mod, "DestroyerSword", 1);
		val2.AddIngredient(Mod, "TwinsSword", 1);
		val2.AddIngredient(Mod, "Executioner", 1);
		val2.AddIngredient(Mod, "Doomsday", 1);
		val2.AddIngredient(Mod, "Sharkron", 1);
		val2.AddTile(TileID.LunarCraftingStation);
		val2.Register();
	}
}
