using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PurpleRuneBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Shadow Rune Blade");
		Tooltip.SetDefault("'Pulses with dark energy of shadowflame'");
	}

	public override void SetDefaults()
	{
		Item.width = 52;
		Item.height = 52;
		Item.rare = ItemRarityID.Purple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 38;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.ShadowFlameKnife;
		Item.shootSpeed = 20f;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) => Main.rand.NextBool(10);

    public override void MeleeEffects(Player player, Rectangle hitbox)
	{											
		if (Main.rand.NextBool(2))
		{
			Dust dust = Main.dust[Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.ShadowbeamStaff, 0f, 0f, 100, default, 2f)];
			dust.noGravity = true;
		}
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ItemID.ShadowFlameKnife, 1)
		.AddIngredient(Mod, "DamascusBar", 10)
		.AddIngredient(Mod, "UpgradeMatter", 1)
		.AddTile(TileID.Anvils)
		.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (!target.HasBuff(BuffID.ShadowFlame) && Main.rand.NextBool(2))
		{
            target.AddBuff(BuffID.ShadowFlame, 300, false);
        }
	}
}
