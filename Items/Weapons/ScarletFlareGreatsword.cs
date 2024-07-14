using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace UniverseOfSwordsMod.Items.Weapons;

[LegacyName(["ScarledFlareGreatsword"])]
public class ScarletFlareGreatsword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 120;
		Item.height = 120;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 20;
		Item.damage = 110;
		Item.knockBack = 6f;
		Item.scale = 1f;
		Item.crit = 6;
		Item.noUseGraphic = true;
		Item.noMelee = true;
		Item.shootSpeed = 20f;
		Item.shoot = ProjectileType<ScarletGreatswordProjectile>();
		Item.UseSound = SoundID.Item169;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}
	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemType<SwordMatter>(), 50)
		.AddIngredient(ItemType<RedFlareLongsword>(), 1)
        .AddIngredient(ItemType<ScarletFlareCore>(), 1)
        .AddIngredient(ItemType<TheNightmareAmalgamation>(), 1)
        .AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
