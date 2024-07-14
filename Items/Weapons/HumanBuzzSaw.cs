using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class HumanBuzzSaw : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
        Item.damage = 24;
		Item.DamageType = DamageClass.MeleeNoSpeed; 
		Item.width = 102;
		Item.height = 102;
		Item.crit = 8;
		Item.scale = 1f;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 4;
		Item.useAnimation = 4;		
		Item.UseSound = SoundID.Item1;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.rare = ItemRarityID.LightRed;
		Item.shoot = ModContent.ProjectileType<Projectiles.HumanBuzzSaw>();
        Item.channel = true;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.noMelee = true;
    }
	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.Sawmill, 1)
		.AddIngredient(ItemID.TitaniumBar, 8)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
		.AddIngredient(ModContent.ItemType<DamascusBar>(), 20)
		.AddTile(TileID.MythrilAnvil)
		.Register();
		CreateRecipe()
		.AddIngredient(ItemID.Sawmill, 1)
		.AddIngredient(ItemID.AdamantiteBar, 8)
        .AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
        .AddIngredient(ModContent.ItemType<DamascusBar>(), 20)
        .AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
