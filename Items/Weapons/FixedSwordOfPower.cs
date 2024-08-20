using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Items.Misc;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FixedSwordOfPower : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.Size = new(64);
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 19;
		Item.useAnimation = 19;
		Item.damage = 36;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.value = 18000;
		Item.shoot = ModContent.ProjectileType<BoomeBone>();
		Item.shootSpeed = 9f;
		Item.scale = 1.25f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}

    public override bool CanShoot(Player player) => player.ownedProjectileCounts[Item.shoot] < 1;

    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<SwordOfPower>(), 1)
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 15)
            .AddIngredient(ItemID.Bone, 150)
			.AddTile(TileID.Anvils)
			.Register();
	}

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (ModLoader.TryGetMod("CalamityMod", out _))
        {
            damage *= 1.10f;
        }
        return;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Projectile.NewProjectileDirect(source, position, velocity, type, (int)(damage * 0.50f), knockback, player.whoAmI);
		return false;
    }
}
