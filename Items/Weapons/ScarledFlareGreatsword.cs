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
		Item.damage = 124;
		Item.knockBack = 8f;
		Item.shootSpeed = 30f;
		Item.shoot = Mod.Find<ModProjectile>("FlareCore").Type;
		Item.UseSound = SoundID.Item45;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 4;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(30f));
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.LifeDrain, 0f, 0f, 100, default, 2f);
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
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "UpgradeMatter", 5);
		val.AddIngredient(Mod, "RedFlareLongsword", 1);
		val.AddIngredient(Mod, "ScarletFlareCore", 1);
		val.AddIngredient(Mod, "TheNightmareAmalgamation", 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
