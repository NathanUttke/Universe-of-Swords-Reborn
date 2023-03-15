using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FixedSwordOfPower : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword Of Power");
		Tooltip.SetDefault("Has a chance to inflict Midas debuff on enemies");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 37;
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
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordOfPower", 1);
		val.AddIngredient(ItemID.Bone, 20);
		val.AddIngredient(Mod, "UpgradeMatter", 2);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (Main.rand.NextBool(5)) 
		{
			if (!target.HasBuff(BuffID.Midas))
			{
                target.AddBuff(BuffID.Midas, 360, false);
            }
        }
	}
}
