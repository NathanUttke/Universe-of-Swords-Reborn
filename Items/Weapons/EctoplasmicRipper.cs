using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Items.Weapons;

public class EctoplasmicRipper : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Steals mana upon hitt");
	}

	public override void SetDefaults()
	{		
		Item.crit = 2;		
		Item.width = 52;
		Item.height = 52;

		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item103;

        Item.damage = 75;
        Item.DamageType = DamageClass.Magic;

        Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 1, 40, 0);
		Item.rare = ItemRarityID.Cyan;
		Item.scale = 1.5f;		
		Item.autoReuse = true;
		Item.useTurn = false;

		Item.mana = 10;
        Item.ResearchUnlockCount = 1;
    }

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{				
		if (Main.rand.NextBool(2))
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Cyan, 1f);
		}
	}

    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ItemID.SpectreBar, 12)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (!target.immortal && NPCID.Sets.CountsAsCritter[target.type])
		{
            int manaAmount = Item.mana / 2;

			if (hit.Crit)
			{
				manaAmount = (int)(manaAmount * 1.5);
			}

            player.statMana += manaAmount;
            player.ManaEffect(manaAmount);
        }
	}
}
