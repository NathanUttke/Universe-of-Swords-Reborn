using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class RedFlareLongsword : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Scarlet Flare Longsword");
		Tooltip.SetDefault("Fires scarlet flare waves and ignites enemies with Scarlet flames\n'Ignite your foes in scarlet flames'");
	}

	public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 60;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 74;
		Item.knockBack = 5f;
		Item.shoot = ProjectileID.DD2SquireSonicBoom;
		Item.shootSpeed = 30f;
		Item.UseSound = SoundID.Item45;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		
		
		
		
								if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.LifeDrain, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		
																				Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.HellstoneBar, 25);
		val.AddIngredient(ItemID.RedTorch, 25);
		val.AddIngredient(ItemID.Ruby, 50);
		val.AddIngredient(ItemID.SoulofFright, 20);
		val.AddIngredient(ItemID.BrokenHeroSword, 1);
		val.AddIngredient(Mod, "DeathSword", 1);
		val.AddIngredient(Mod, "DamascusBar", 20);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(24, 500, false);
	}
}
