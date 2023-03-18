using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Destructor : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Inflicts Venom debuff on enemies");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 68;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = 290000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.AdamantiteSword, 1);
		val.AddIngredient(Mod, "UpgradeMatter", 2);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(ItemID.TitaniumSword, 1);
		val2.AddIngredient(Mod, "UpgradeMatter", 2);
		val2.AddTile(TileID.MythrilAnvil);
		val2.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(70, 360, false);
	}
}
