using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Utilities;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class NatureSword : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("'Sword made out of only pure ingredients given from Mother Nature'");
	}

	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 70;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Blue;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 50;
		Item.useAnimation = 25;
		Item.damage = 17;
		Item.knockBack = 0f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (!target.active || target.immortal || NPCID.Sets.CountsAsCritter[target.type] || target.SpawnedFromStatue)
        {
            return;
        }

        if (player.GetModPlayer<UniversePlayer>().swordTimer == 0)
        {
            player.GetModPlayer<UniversePlayer>().swordTimer = 20;
        }
        else
        {
            return;
        }

        for (int i = 0; i < 3; i++)
		{
			UniverseUtils.SummonSuperStarSlash(target.position, target.GetSource_OnHit(target), (int)(damageDone * 0.5f), player.whoAmI, ProjectileID.SeedlerThorn);
		}
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
	{	
		if (Main.rand.NextBool(3))
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<NatureBlade>(), 0f, 0f, 100, default, 1f);
		}
	}

	public override void AddRecipes()
	{					
		CreateRecipe()
		.AddIngredient(ItemID.Vilethorn, 1)
		.AddIngredient(ItemID.Seed, 10)
		.AddIngredient(ItemID.Daybloom, 5)
		.AddIngredient(ItemID.DirtBlock, 100)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 10)
		.AddTile(TileID.Anvils)
		.Register();
		CreateRecipe()
		.AddIngredient(ItemID.TheRottedFork, 1)
		.AddIngredient(ItemID.Seed, 10)
		.AddIngredient(ItemID.Daybloom, 5)
		.AddIngredient(ItemID.DirtBlock, 100)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 10)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
