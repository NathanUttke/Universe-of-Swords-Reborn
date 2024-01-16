using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class RedFlareLongsword : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Scarlet Flare Longsword");
		// Tooltip.SetDefault("Fires scarlet flare waves and ignites enemies with Scarlet flames\n'Ignite your foes in scarlet flames'");
	}

	public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 60;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 20;
		Item.damage = 75;
		Item.knockBack = 5f;
		Item.shoot = ModContent.ProjectileType<RedFlareLongswordProjectile>();
		Item.shootSpeed = 20f;
		Item.UseSound = SoundID.Item45;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}

	public override bool CanShoot(Player player) => player.ItemAnimationJustStarted;


    public override void MeleeEffects(Player player, Rectangle hitbox)
	{	
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.RedTorch, 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ItemID.HellstoneBar, 25)
			.AddIngredient(ItemID.Ruby, 10)	
			.AddIngredient(ItemID.SoulofFright, 20)
			.AddIngredient(ItemID.BrokenHeroSword, 1)
			.AddIngredient(ItemID.BeamSword, 1)
			.AddIngredient(ModContent.ItemType<Orichalcon>(), 15)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(24, 500, false);
	}
}
