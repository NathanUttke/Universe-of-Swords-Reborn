using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class RedFlareLongsword : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Scarlet Flare Longsword");
		// Tooltip.SetDefault("Fires scarlet flare waves and ignites enemies with Scarlet flames\n'Ignite your foes in scarlet flames'");
	}

	public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 60;
		Item.scale = 1.25f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 20;
		Item.damage = 75;
		Item.knockBack = 5f;
		Item.shoot = ModContent.ProjectileType<RedFlareLongswordProjectile>();
		Item.shootSpeed = 20f;
		Item.UseSound = SoundID.Item45;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}

	public override bool CanShoot(Player player) => !player.ItemAnimationJustStarted;

    public override void MeleeEffects(Player player, Rectangle hitbox)
	{	
		if (Main.rand.NextBool(2))
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(255, 150, 120, 0), 1.5f);
		}
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		position += position.SafeNormalize(Vector2.Zero).RotatedBy(-MathHelper.PiOver2) * 24f; 
		Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
		return false;
    }

    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ItemID.HellstoneBar, 25)
			.AddIngredient(ItemID.Ruby, 10)	
			.AddIngredient(ItemID.SoulofFright, 20)
			.AddIngredient(ItemID.BeamSword, 1)
			.AddIngredient(ModContent.ItemType<Orichalcon>(), 15)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
        if (!target.HasBuff(BuffID.OnFire))
        {
            target.AddBuff(BuffID.OnFire, 600, false);
        }
    }
}
