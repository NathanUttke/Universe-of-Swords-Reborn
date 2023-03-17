using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class OrangeRuneSword : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Fire Rune Blade");
		Tooltip.SetDefault("'Pulses with burning heat of fire'");
	}

	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 50;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 40;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item20;
		Item.shoot = ProjectileID.BallofFire;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{
		
												Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.LivingFireBlock, 100);
		val.AddIngredient(Mod, "DamascusBar", 10);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
																if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity.X -= (float)player.direction * 0f;
			Main.dust[dust].velocity.Y -= 0f;
		}
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(24, 400, false);
	}
}
