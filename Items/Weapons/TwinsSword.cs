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
		Tooltip.SetDefault("Whoosh, whoosh!");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 20;
		Item.damage = 62;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 160000;
		Item.shoot = ProjectileID.CursedFlameFriendly;
		Item.shootSpeed = 5f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
		ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
	}

	public override bool AltFunctionUse(Player player) => true;

    public override bool CanUseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            Item.shoot = ProjectileID.DeathLaser;
        }
        else
        {
            Item.shoot = ProjectileID.EyeFire;
        }
        return true;
    }


    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		if (player.altFunctionUse == 2)
		{
            Projectile retinProj = Projectile.NewProjectileDirect(source, position, velocity * Utils.SelectRandom(Main.rand, 1, -1, 1, -1, 1), ProjectileID.DeathLaser, 45, knockback, player.whoAmI);
            retinProj.hostile = false;
            retinProj.friendly = true;
			retinProj.DamageType = DamageClass.MeleeNoSpeed;
        }
		else
		{
            Projectile spazmProj = Projectile.NewProjectileDirect(source, position, velocity, ProjectileID.EyeFire, 40, knockback, player.whoAmI);
            spazmProj.hostile = false;
            spazmProj.friendly = true;
            spazmProj.DamageType = DamageClass.MeleeNoSpeed;
        }

		return false;
    }
}
