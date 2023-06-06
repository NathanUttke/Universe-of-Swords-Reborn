using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CrimsonCrystallus : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 44;
		Item.height = 54;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 50;
		Item.useAnimation = 25;
		Item.damage = 19;
		Item.knockBack = 5f;
		Item.shoot = Mod.Find<ModProjectile>("Tier2CProjectile").Type;
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{					
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Adamantite, 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
		}
	}
    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        velocity = velocity.RotatedByRandom(MathHelper.ToRadians(25f));
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (ModLoader.TryGetMod("CalamityMod", out _))
		{
			damage *= 1.15f;
		}
		return;
    }
    public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<Crystallus>(), 1)
		.AddIngredient(ItemID.CrimtaneBar, 12)
		.AddIngredient(ItemID.TissueSample, 8)
		.AddTile(TileID.Anvils)
		.Register();
        CreateRecipe()
		.AddIngredient(ModContent.ItemType<CorruptCrystallus>(), 1)
		.AddTile(TileID.DemonAltar)
		.Register();
    }
}
