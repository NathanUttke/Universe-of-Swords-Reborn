using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Accessories;

public class BoxOfGrenades : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Box Of Grenades");
	}

	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 48;
		Item.value = Item.sellPrice(0, 6, 0, 0);
		Item.rare = ItemRarityID.Purple;
		Item.expert = true;
		Item.accessory = true; 
		SacrificeTotal = 1;
	}

	private int grenadeBoxCounter;
	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		if (Main.myPlayer != player.whoAmI)
		{
			return;
		}
		grenadeBoxCounter++;
		if (grenadeBoxCounter <= 45)
		{
			return;
		}
		grenadeBoxCounter = 0;
		Projectile grenadeBox = Projectile.NewProjectileDirect(player.GetSource_Accessory(Item), player.Center, new Vector2(12f * player.direction, Main.rand.Next(-11, 10)), ProjectileID.Grenade, Main.rand.Next(25, 60), 4.1f, player.whoAmI);
		grenadeBox.DamageType = DamageClass.Generic;
	}

    public override void AddRecipes()
    {
		CreateRecipe(1)
		.AddIngredient(ItemID.WoodenCrate, 1)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
		.AddIngredient(ItemID.Grenade, 800)
		.AddTile(TileID.MythrilAnvil)
		.Register();
    }
}
