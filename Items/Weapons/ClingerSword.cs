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
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 40;
		Item.useAnimation = 20;
		Item.damage = 50;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item100;
		Item.shoot = ProjectileID.EyeFire;
		Item.shootSpeed = 2.5f;
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage /  2, knockback, player.whoAmI);
        proj.DamageType = DamageClass.MeleeNoSpeed;
		proj.friendly = true;
		proj.hostile = false;
        return false;
    }
}
