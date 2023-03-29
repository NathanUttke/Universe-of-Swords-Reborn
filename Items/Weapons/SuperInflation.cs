using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SuperInflation : ModItem
{
    public override string Texture => "UniverseofSwordsMod/Items/Weapons/Inflation";
    public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Throw money at ALL your problems'\n15% more damage if the player has a gold coin.");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 10f;
		Item.useTime = 48;
		Item.useAnimation = 12;
		Item.damage = 110;
		Item.UseSound = SoundID.Item1;
		Item.value = 0;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<Inflation>(), 1)
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 4)
		.AddIngredient(ModContent.ItemType<Orichalcon>(), 8)
		.AddIngredient(ItemID.LunarBar, 5)
		.AddTile(TileID.LunarCraftingStation)
		.Register();
	}

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
		player.itemLocation = player.Center;
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (player.HasItem(ItemID.GoldCoin))
        {
            damage *= 1.15f;
        }
    }

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
        if (!target.HasBuff(BuffID.Midas))
        {
            target.AddBuff(BuffID.Midas, 500);
        }
    }
}
