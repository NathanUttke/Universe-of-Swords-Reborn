using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
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
		Item.useTime = 17;
		Item.useAnimation = 17;

		Item.damage = 45;
		Item.shoot = ModContent.ProjectileType<PurpleRuneProjectile>();
		Item.shootSpeed = 10f;

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
			Vector2 dustRotation = player.itemLocation + (player.itemRotation.ToRotationVector2() * MathHelper.PiOver2 * 0.75f);
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), dustRotation.X, dustRotation.Y, 0, Color.Purple with { A = 0 }, 2f);
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
