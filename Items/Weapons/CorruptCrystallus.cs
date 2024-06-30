using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CorruptCrystallus : ModItem
{
	public override void SetDefaults()
	{
        Item.width = 44;
        Item.height = 52;
        Item.rare = ItemRarityID.Green;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 50;
        Item.useAnimation = 25;
        Item.UseSound = SoundID.Item1;
        Item.damage = 18;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<CorruptCrystallusProj>();
        Item.shootSpeed = 2f;
        Item.value = Item.sellPrice(0, 1, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee;
        Item.ResearchUnlockCount = 1;
    }

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{	
		if (Main.rand.NextBool(2))
		{
			Dust.NewDust(new(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 100, Color.MediumOrchid, 1.25f);
		}
	}
    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Crystallus>(), 1)
			.AddIngredient(ItemID.DemoniteBar, 12)
			.AddIngredient(ItemID.ShadowScale, 8)
			.AddTile(TileID.Anvils)
			.Register();
        CreateRecipe()
			.AddIngredient(ModContent.ItemType<CrimsonCrystallus>(), 1)
			.AddTile(TileID.DemonAltar)
			.Register();
    }
}
