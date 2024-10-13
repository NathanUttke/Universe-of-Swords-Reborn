using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DoubleBladedLightsaber : ModItem
{
	public override void SetStaticDefaults()
	{		
		Main.RegisterItemAnimation(Type, new DrawAnimationVertical(55, 7, false));
		ItemID.Sets.AnimatesAsSoul[Type] = true;
		Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
		Item.damage = 72;
		Item.DamageType = DamageClass.MeleeNoSpeed; 
		Item.width = 90;
		Item.height = 90;
		Item.useTime = 10;
		Item.useAnimation = 30;
		Item.channel = true;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.noMelee = true;
		Item.UseSound = SoundID.Item15;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 8f;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.rare = ItemRarityID.Lime;
        Item.shoot = ModContent.ProjectileType<UltimateSaberProjectile>();
        Item.noUseGraphic = true;
	}

	public override bool CanShoot(Player player) => player.ownedProjectileCounts[Item.shoot] == 0;

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int i = 1; i <= 6; i++)
        {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, i - 1, i * 12f);
        }
        return false;
    }
    public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.YellowPhasesaber, 1)
		.AddIngredient(ItemID.WhitePhasesaber, 1)
		.AddIngredient(ItemID.PurplePhasesaber, 1)
		.AddIngredient(ItemID.GreenPhasesaber, 1)
		.AddIngredient(ItemID.BluePhasesaber, 1)
		.AddIngredient(ItemID.RedPhasesaber, 1)
		.AddIngredient(ItemID.ChlorophyteBar, 15)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 30)
		.AddIngredient(ModContent.ItemType<HumanBuzzSaw>(), 1)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
