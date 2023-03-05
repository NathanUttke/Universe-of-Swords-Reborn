using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Narsil : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Bane of Sauron'");
	}

	public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 60;
		Item.scale = 1.3f;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 13;
		Item.useAnimation = 13;
		Item.damage = 99;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item1;
		Item.value = 130000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		
														Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "Sting", 1);
		val.AddIngredient(Mod, "Glamdring", 1);
		val.AddIngredient(Mod, "Orcrist", 1);
		val.AddIngredient(ItemID.BrokenHeroSword, 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
		target.AddBuff(69, 360, false);
		target.AddBuff(24, 360, false);
	}
}
