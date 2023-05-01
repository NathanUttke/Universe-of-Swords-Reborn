using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ScarledFlareGreatsword : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Scarlet Flare Greatsword");
	}

	public override void SetDefaults()
	{
		Item.width = 120;
		Item.height = 120;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 125;
		Item.knockBack = 8f;
		Item.shootSpeed = 60f;
		Item.shoot = ProjectileType<FlareCore>();
		Item.UseSound = SoundID.Item45;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
        float numberProjectiles = 3;
        float rotation = MathHelper.ToRadians(10f);
        position += Vector2.Normalize(velocity * 4f);

        for (int i = 0; i < numberProjectiles; i++)		
		{
            Vector2 perturbedSpeed = Utils.RotatedBy(velocity, (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.25f;
            Projectile redSword = Projectile.NewProjectileDirect(source, position, perturbedSpeed, ProjectileType<RedFlareLongswordProjectile>(), (int)(damage * 1.25f), knockback, player.whoAmI, 0f, 0f);
			redSword.tileCollide = false;
			redSword.scale = 1.15f;
		}

        Projectile.NewProjectileDirect(source, position, velocity * 1.5f, type, (int)(damage * 1.30f), knockback, player.whoAmI, 0f, 0f);
        return false;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.RedTorch, 0f, 0f, 100, default, 1.75f);
			Main.dust[dust].noGravity = true;
		}
	}
    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (!target.HasBuff(BuffID.OnFire))
		{
            target.AddBuff(BuffID.OnFire, 600, false);
        }
	}
	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(Mod, "UpgradeMatter", 4)
		.AddIngredient(Mod, "RedFlareLongsword", 1)
		.AddIngredient(Mod, "ScarletFlareCore", 1)
		.AddIngredient(Mod, "TheNightmareAmalgamation", 1)
		.AddTile(TileID.LunarCraftingStation)
		.Register();
	}
}
