using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DoubleBladedLightsaber : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("The Ultimate Saber");
		Tooltip.SetDefault("'Watch out to not cut your body in half'");
		Main.RegisterItemAnimation(Type, new DrawAnimationVertical(55, 7, false));
		ItemID.Sets.AnimatesAsSoul[Type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 70;
		Item.DamageType = DamageClass.MeleeNoSpeed; 

		SacrificeTotal = 1;

		Item.width = 138;
		Item.height = 138;

		Item.useTime = 10;
		Item.useAnimation = 10;

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

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		return player.ownedProjectileCounts[Item.shoot] < 7;
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
		.AddIngredient(ItemID.ChlorophyteBar, 12)
		.AddIngredient(Mod, "UpgradeMatter", 3)
		.AddIngredient(ItemID.CrystalShard, 25)
		.AddIngredient(ModContent.ItemType<HumanBuzzSaw>(), 1)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
