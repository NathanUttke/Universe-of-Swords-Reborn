using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Doomsday : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 66;
		Item.height = 70;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Cyan;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 130;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item45;
		Item.value = 470000;
		Item.shoot = ModContent.ProjectileType<DoomsdayProj>();
		Item.shootSpeed = 12f;
		Item.crit = 8;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		Item.ArmorPenetration = 20;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        position += Vector2.UnitY * -70f;
        for (int i = 0; i < 3; i++)
		{
			Vector2 newVelocity = velocity * Main.rand.NextFloat(0.9f, 1.25f);
			newVelocity = newVelocity.RotatedByRandom(0.3f);
            Projectile.NewProjectileDirect(source, position, newVelocity, type, damage / 3, knockback, player.whoAmI);
        }
        return false;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            Dust dust = Dust.NewDustDirect(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Orange, 1f);
            dust.noGravity = true;
        }
    }
}
