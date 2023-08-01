using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PurpleRuneBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Shadow Rune Blade");
		// Tooltip.SetDefault("'Pulses with dark energy of shadowflame'");
	}

	public override void SetDefaults()
	{
		Item.width = 52;
		Item.height = 52;
		Item.rare = ItemRarityID.Purple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 35;
		Item.useAnimation = 25;
		Item.damage = 45;

		Item.shoot = ModContent.ProjectileType<PurpleRuneProjectile>();
		Item.shootSpeed = 8f;

		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}

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
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
		.AddTile(TileID.Anvils)
		.Register();
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (!target.HasBuff(BuffID.ShadowFlame) && Main.rand.NextBool(2))
		{
            target.AddBuff(BuffID.ShadowFlame, 300, false);
        }
	}
}
