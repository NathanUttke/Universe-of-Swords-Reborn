using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class UselessWeapon : ModItem
{
    public override void SetStaticDefaults()
    {
		DisplayName.SetDefault("Wooden Cane");
    }
    public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 56;
		Item.rare = ItemRarityID.Pink;

        Item.DamageType = DamageClass.MeleeNoSpeed;
        Item.damage = 8; 

        Item.useTime = 14;
        Item.useAnimation = 42;
		Item.reuseDelay = 28;
        Item.useStyle = ItemUseStyleID.Rapier;
        Item.UseSound = SoundID.Item1;

		Item.value = Item.sellPrice(0, 0, 40, 0);

		Item.shoot = ModContent.ProjectileType<UselessProjectile>();
		Item.shootSpeed = 5f;

        Item.knockBack = 4f;
        SacrificeTotal = 1;

        Item.noUseGraphic = true;
        Item.noMelee = true;
        Item.autoReuse = true;
    }

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        velocity = velocity.SafeNormalize(Vector2.Zero).RotatedBy(MathHelper.PiOver4 * (Main.rand.NextFloat() - 0.5f)) * (velocity.Length() - Main.rand.NextFloatDirection() * 0.8f);
    }

}
