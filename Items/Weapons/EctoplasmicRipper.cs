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
        Item.ResearchUnlockCount = 1;
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
		if (!target.immortal && !NPCID.Sets.CountsAsCritter[target.type])
		{
            int manaAmount = Item.mana;

			if (hit.Crit)
			{
				manaAmount *= 2;
			}

            player.statMana += manaAmount;
            player.ManaEffect(manaAmount);


			if (target.life < 0 && !target.active && !target.immortal && !NPCID.Sets.CountsAsCritter[target.type])
			{
				for (int i = 0; i < 3; i++)
				{
                    Vector2 newVelocity = (Vector2.One * 10f).RotatedByRandom(MathHelper.Pi);
                    newVelocity.Normalize();
                    Projectile energyProj = Projectile.NewProjectileDirect(target.GetSource_OnHit(target), target.position, newVelocity * 3f, ProjectileID.SpectreWrath, Item.damage, 0f, player.whoAmI);
                    energyProj.scale = 0.5f;
					energyProj.timeLeft = 500;
                }
			}
        }
	}
}
