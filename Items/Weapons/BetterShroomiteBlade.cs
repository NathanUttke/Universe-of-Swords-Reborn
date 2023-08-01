using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BetterShroomiteBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Bigger and better!");
	}

	public override void SetDefaults()
	{
		Item.width = 68;
		Item.height = 68;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 75;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item1;
		Item.value = 380000;		
		Item.DamageType = DamageClass.Melee;
		Item.scale = 1f;
		Item.shoot = ModContent.ProjectileType<BetterShroomiteProj>();
		Item.noMelee = true;
		Item.shootsEveryUse = true;
        Item.autoReuse = true;
        Item.ResearchUnlockCount = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
        Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
        NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.

        return true;
    }


    public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<ShroomiteBlade>(), 1)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
		.AddIngredient(ItemID.ShroomiteBar, 15)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
