using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Misc;

public class MagicMirrorBlade : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item6;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.noMelee = true;
		Item.autoReuse = false;
    }

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		if (Main.rand.NextBool(2))
		{
			Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.1f);
		}
		if (player.itemTime == 0)
		{
			player.itemTime = (int)(Item.useTime / PlayerLoader.UseTimeMultiplier(player, Item));
		}
		else
		{
			if (player.itemTime != (int)(Item.useTime / PlayerLoader.UseTimeMultiplier(player, Item)) / 2)
			{
				return;
			}
			for (int d = 0; d < 30; d++)
			{
                ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.StardustPunch, new ParticleOrchestraSettings
                {
                    PositionInWorld = player.MountedCenter,
                    MovementVector = player.itemRotation.ToRotationVector2() * 5f * 0.1f + Main.rand.NextVector2Circular(2f, 2f)

                }, player.whoAmI);
            }
			player.RemoveAllGrapplingHooks();
			player.Spawn(PlayerSpawnContext.RecallFromItem);
			for (int j = 0; j < 30; j++)
			{
                ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.StardustPunch, new ParticleOrchestraSettings
                {
                    PositionInWorld = player.MountedCenter,
                    MovementVector = player.itemRotation.ToRotationVector2() * 5f * 0.1f + Main.rand.NextVector2Circular(2f, 2f)

                }, player.whoAmI);
            }
		}
	}
	public override void AddRecipes()
	{	
		CreateRecipe()
		.AddIngredient(ItemID.MagicMirror, 1)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
		.Register();
		CreateRecipe()
		.AddIngredient(ItemID.IceMirror, 1)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
		.Register();
	}
}
