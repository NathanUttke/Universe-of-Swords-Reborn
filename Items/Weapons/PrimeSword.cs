using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PrimeSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Pew, pew!");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 64;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 20;
		Item.damage = 60;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item33;
		Item.value = 160000;
		Item.shoot = ProjectileID.BombSkeletronPrime;
		Item.shootSpeed = 20f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Projectile bombProj = Projectile.NewProjectileDirect(source, position, velocity, Item.shoot, Item.damage / 2, knockback, player.whoAmI);
		bombProj.hostile = false;
		bombProj.friendly = true;
		return false;
    }
}
