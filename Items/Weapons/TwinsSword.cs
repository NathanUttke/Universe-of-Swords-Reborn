using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TwinsSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 20;
		Item.damage = 66;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1 with { Pitch = 0.35f };
		Item.value = 160000;
		Item.shoot = ModContent.ProjectileType<TwinsProjectile>();
		Item.shootSpeed = 6f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
		target.AddBuff(BuffID.CursedInferno, 300);
		target.AddBuff(BuffID.Bleeding, 300);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectileDirect(source, position + velocity * 4f, velocity, type, damage / 2, knockback, player.whoAmI);
        return false;
    }
}
