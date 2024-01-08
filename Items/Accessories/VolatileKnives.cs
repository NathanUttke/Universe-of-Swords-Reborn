using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Accessories;
[LegacyName (new string[] { "BoxOfGrenades" })]
public class VolatileKnives : ModItem
{
    private int grenadeBoxCounter;

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 32;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.rare = ItemRarityID.Purple;
		Item.accessory = true; 
		Item.ResearchUnlockCount = 1;
	}
	
	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		if (Main.myPlayer != player.whoAmI)
		{
			return;
		}
		grenadeBoxCounter++;
		if (grenadeBoxCounter <= 38)
		{
			return;
		}
		grenadeBoxCounter = 0;
		Projectile knifeBox = Projectile.NewProjectileDirect(player.GetSource_Accessory(Item), player.Center, new Vector2(6f * player.direction, Main.rand.Next(-20, -10)), Utils.SelectRandom(Main.rand, ProjectileID.MagicDagger, ProjectileID.PoisonedKnife, ProjectileID.ThrowingKnife), Main.rand.Next(25, 70), 4f, player.whoAmI);
		knifeBox.DamageType = DamageClass.Generic;
		knifeBox.usesLocalNPCImmunity = true;
		knifeBox.localNPCHitCooldown = 20;
	}

    public override void AddRecipes()
    {
		CreateRecipe()
		.AddIngredient(ItemID.WoodenCrate, 1)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 15)
		.AddIngredient(ItemID.MagicDagger, 1)
		.AddIngredient(ItemID.PoisonedKnife, 100)
		.AddIngredient(ItemID.ThrowingKnife, 100)
		.AddTile(TileID.MythrilAnvil)
		.Register();
    }
}
