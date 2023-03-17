using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class YellowRuneBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Ichor Rune Blade");
		Tooltip.SetDefault("'Pulses with light energy of ichor'");
	}

	public override void SetDefaults()
	{
		Item.width = 50;
		Item.height = 50;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 40;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item8;
		Item.shoot = ProjectileID.GoldenShowerFriendly;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
											
				if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.IchorTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity.X -= (float)player.direction * 0f;
			Main.dust[dust].velocity.Y -= 0f;
		}
	}

	public override void AddRecipes()
	{
		
												Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.Ichor, 30);
		val.AddIngredient(Mod, "DamascusBar", 10);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(69, 400, false);
	}
}
