using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Machine : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Pew, pew! Boom, boom!");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 62;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 62;
		Item.knockBack = 3.5f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.shoot = ProjectileID.DeathLaser;
		Item.shootSpeed = 8f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, Item.shoot, damage, knockback, player.whoAmI);
        proj.DamageType = DamageClass.Melee;
        proj.hostile = false;
        proj.friendly = true;
		return false;
    }


    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ItemID.BrokenHeroSword, 1)
			.AddIngredient(Mod, "Orichalcon", 1)
			.AddIngredient(Mod, "UpgradeMatter", 2)
			.AddIngredient(ItemID.LaserRifle, 1)
			.AddIngredient(Mod, "PrimeSword", 1)
			.AddIngredient(Mod, "DestroyerSword", 1)
			.AddIngredient(Mod, "TwinsSword", 1)
			.AddTile(TileID.MythrilAnvil);
			.Register();
	}
}
