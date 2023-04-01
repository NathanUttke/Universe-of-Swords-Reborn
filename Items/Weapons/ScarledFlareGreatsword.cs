using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ScarledFlareGreatsword : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Scarlet Flare Greatsword");
		Tooltip.SetDefault("Fires scarlet flare waves and ignites enemies with flames");
	}

	public override void SetDefaults()
	{
		Item.width = 120;
		Item.height = 120;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 120;
		Item.knockBack = 8f;
		Item.shootSpeed = 30f;
		Item.shoot = Mod.Find<ModProjectile>("FlareCore").Type;
		Item.UseSound = SoundID.Item45;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 3;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(30f * i));
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1.25f), knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.RedTorch, 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
		}
	}
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(24, 700, false);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(Mod, "UpgradeMatter", 5)
		.AddIngredient(Mod, "RedFlareLongsword", 1)
		.AddIngredient(Mod, "ScarletFlareCore", 1)
		.AddIngredient(Mod, "TheNightmareAmalgamation", 1)
		.AddTile(TileID.LunarCraftingStation)
		.Register();
	}
}
