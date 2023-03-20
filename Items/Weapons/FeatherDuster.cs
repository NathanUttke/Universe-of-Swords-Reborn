using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FeatherDuster : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;

		Item.rare = ItemRarityID.Blue;
		Item.useStyle = ItemUseStyleID.Swing;

		Item.useTime = 30;
		Item.useAnimation = 25;
		Item.damage = 15;

		Item.knockBack = 1.5f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = Mod.Find<ModProjectile>("HarpyFeather").Type;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 0, 15, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
		velocity = velocity.RotatedByRandom(MathHelper.ToRadians(15f));
    }
}
