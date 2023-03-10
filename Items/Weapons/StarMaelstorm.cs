using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class StarMaelstorm : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Star Maelstrom");
		Tooltip.SetDefault("'Todays forecast: shooting stars and hurricanes'");
	}

	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 66;
		Item.rare = ItemRarityID.Purple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 200;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item105;
		Item.shoot = ProjectileID.StarWrath;
		Item.shootSpeed = 20f;
		Item.value = Item.sellPrice(0, 50, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 70;
			Item.useAnimation = 70;
			Item.damage = 100;
			Item.shoot = ProjectileID.DD2ApprenticeStorm;
		}
		else
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.damage = 200;
			Item.shoot = ProjectileID.StarWrath;
		}
		return base.CanUseItem(player);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
		float ceilingLimit = target.Y;
		if (ceilingLimit > player.Center.Y - 200f)
		{
			ceilingLimit = player.Center.Y - 200f;
		}
		for (int i = 0; i < 15; i++)
		{
			position = player.Center + new Vector2((0f - (float)Main.rand.Next(0, 901)) * (float)player.direction, -600f);
			position.Y -= 100 * i;
			Vector2 heading = target - position;
			if (heading.Y < 0f)
			{
				heading.Y *= -1f;
			}
			if (heading.Y < 20f)
			{
				heading.Y = 20f;
			}
			heading.Normalize();
			Vector2 val = heading;
			Vector2 val2 = new Vector2(velocity.X, velocity.Y);
			heading = val * val2.Length();
			velocity.X = heading.X;
			velocity.Y = heading.Y + (float)Main.rand.Next(-800, 800) * 0.02f;
			Projectile.NewProjectile(source, position.X, position.Y, velocity.X / 2f, velocity.Y / 2f, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
		}
		return false;
	}
}
