using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GnomBlade : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Red;

		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 12;
		Item.useAnimation = 12;

		Item.damage = 150;
		Item.knockBack = 9f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		Item.crit = 8;

		Item.shoot = ModContent.ProjectileType<GnomeProj>();
		Item.shootSpeed = 10f;

		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		CreateRecipe()	
			.AddIngredient(ItemID.LunarBar, 10)
			.AddIngredient(ItemID.GardenGnome, 1)
			.AddIngredient(ModContent.ItemType<Doomsday>(), 1)
			.AddIngredient(ModContent.ItemType<LunarOrb>(), 1)
			.AddIngredient(ModContent.ItemType<Orichalcon>(), 5)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 80)
			.AddIngredient(ModContent.ItemType<TerraEnsis>(), 1)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
        if (!target.HasBuff(BuffID.Weak))
        {
            target.AddBuff(BuffID.Weak, 400, true);
        }
        if (!target.HasBuff(BuffID.Ichor))
        {
            target.AddBuff(BuffID.Ichor, 400, true);
        }
        if (!target.HasBuff(BuffID.Venom))
        {
            target.AddBuff(BuffID.Venom, 400, true);
        }
        if (!target.HasBuff(BuffID.Slow))
        {
            target.AddBuff(BuffID.Slow, 400, true);
        }
        if (!target.HasBuff(BuffID.CursedInferno))
        {
            target.AddBuff(BuffID.CursedInferno, 400, true);
        }
    }
}
