using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TrueGemSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.shoot = ProjectileID.MagicMissile;
		Item.damage = 80;
		Item.expert = true;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 20, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	
	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, Item.shoot, damage, knockback, player.whoAmI);
		proj.DamageType = DamageClass.Melee;
        return false;
    }

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.YellowTorch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.TintableDustLighted, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "GemSlayer", 1);
		val.AddIngredient(ItemID.BrokenHeroSword, 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
	}
}
