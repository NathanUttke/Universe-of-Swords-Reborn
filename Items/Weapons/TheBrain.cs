using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheBrain : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Sword of Crimson'");
	}

	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.scale = 1f;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 24;
		Item.knockBack = 3f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.shoot = ProjectileID.VampireKnife;
		Item.shootSpeed = 20f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		
		
		
		
								if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}
}
