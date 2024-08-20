using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class RedFlareLongsword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 60;
		Item.scale = 1.25f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 75;
		Item.knockBack = 5f;
		Item.shoot = ModContent.ProjectileType<RedFlareEnergy>();
		Item.scale = 1.25f;
		Item.UseSound = SoundID.Item45;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.autoReuse = true;
		Item.noMelee = true;
		Item.shootsEveryUse = true;
		Item.DamageType = DamageClass.Melee; 
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
        Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
        NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.	
        return false;
    }

    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ItemID.HellstoneBar, 25)
			.AddIngredient(ItemID.Ruby, 10)	
			.AddIngredient(ItemID.SoulofFright, 20)
			.AddIngredient(ItemID.BeamSword, 1)
			.AddIngredient(ModContent.ItemType<Orichalcon>(), 15)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
