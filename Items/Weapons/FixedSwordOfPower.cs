using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Items.Misc;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FixedSwordOfPower : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword Of Power");
		Tooltip.SetDefault("20% chance of inflicting midas on enemies");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 60;
		Item.useAnimation = 30;
		Item.damage = 35;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item1;
		Item.value = 18000;
		Item.shoot = ProjectileID.Bone;
		Item.shootSpeed = 20f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<SwordOfPower>(), 1)
            .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 1)
            .AddIngredient(ItemID.Bone, 100)
			.AddTile(TileID.Anvils)
			.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (Main.rand.NextBool(5)) 
		{
			if (!target.HasBuff(BuffID.Midas))
			{
                target.AddBuff(BuffID.Midas, 400, false);
            }
        }
	}
}
