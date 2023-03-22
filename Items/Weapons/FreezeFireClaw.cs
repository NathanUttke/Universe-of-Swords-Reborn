using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FreezeFireClaw : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("FreezeFire Claw");
		Tooltip.SetDefault("'Burns and freezes your enemies to death'");
	}

	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 56;
		Item.scale = 1f;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 50;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{											
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.DungeonSpirit, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity.X += (float)player.direction * 0f;
			Main.dust[dust].velocity.Y += 0f;
			dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity.X += (float)player.direction * 0f;
			Main.dust[dust].velocity.Y += 0f;
		}
	}

	public override void AddRecipes()
	{	
									
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "OrangeRuneSword", 1);
		val.AddIngredient(Mod, "BlueRuneBlade", 1);
		val.AddIngredient(ItemID.LivingFireBlock, 25);
		val.AddIngredient(ItemID.IceBlock, 150);
		val.AddIngredient(Mod, "SwordMatter", 170);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(24, 360, false);
		target.AddBuff(44, 360, false);
	}
}
