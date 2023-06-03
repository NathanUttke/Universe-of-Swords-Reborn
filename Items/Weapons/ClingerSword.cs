using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ClingerSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 62;
		Item.rare = ItemRarityID.LightPurple;
		//Item.useStyle = ItemUseStyleID.Swing;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 60;
		Item.useAnimation = 60;
		Item.damage = 50;
		Item.knockBack = 4.5f;
		Item.UseSound = SoundID.Item100;
		//Item.shoot = ProjectileID.EyeFire;
		//Item.shootSpeed = 3f;
		Item.shoot = ModContent.ProjectileType<ClingerSwordProjectile>();
		Item.noUseGraphic = true;
		Item.channel = true;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override bool CanUseItem(Player player)
    {
		return player.ownedProjectileCounts[ModContent.ProjectileType<ClingerSwordProjectile>()] <= 0;
    }

    /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage /  2, knockback, player.whoAmI);
        proj.DamageType = DamageClass.MeleeNoSpeed;
		proj.friendly = true;
		proj.hostile = false;
        return false;
    }*/
}
