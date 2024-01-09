using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.RGB;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheNightmareAmalgamation : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("'The source of your nightmares'");
	}

	public override void SetDefaults()
	{
		Item.width = 90;
		Item.height = 90;
		Item.rare = ItemRarityID.Purple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 23;
		Item.useAnimation = 23;
		Item.damage = 120;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item71;
		Item.shoot = ModContent.ProjectileType<Nightmare>();
		Item.shootSpeed = 19f;
		Item.value = Item.sellPrice(0, 7, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
        /*int i = 0;
        while (i < 2)
        {
            Vector2 spinPoint = Vector2.Normalize(velocity) * 14f;
            spinPoint = spinPoint.RotatedBy(MathHelper.ToRadians(22 * i));
            if (spinPoint.HasNaNs())
            {
                spinPoint -= Vector2.UnitY;
            }
            Projectile.NewProjectile(source, position, spinPoint, type, (int)(damage * 1.25f), knockback, player.whoAmI);
            i++;
        }*/
        Projectile.NewProjectile(source, position, velocity, type, (int)(damage * 1.25f), knockback, player.whoAmI);
        return false;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }
    public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<SkullDust>(), 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
			Dust dust2 = Main.dust[dust];
			dust2.noGravity = true;
		}
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (!target.HasBuff(BuffID.ShadowFlame))
		{
            target.AddBuff(BuffID.ShadowFlame, 800, false);
        }
	}

	public override void AddRecipes()
	{	
		CreateRecipe()
		.AddIngredient(Mod, "CthulhuJudge", 1)
		.AddIngredient(Mod, "TheEater", 1)
		.AddIngredient(ModContent.ItemType<TheSwarm>(), 1)
		.AddIngredient(ModContent.ItemType<FixedSwordOfPower>(),1)
		.AddIngredient(Mod, "PrimeSword", 1)
		.AddIngredient(Mod, "DestroyerSword", 1)
		.AddIngredient(Mod, "TwinsSword", 1)
		.AddIngredient(Mod, "Executioner", 1)
		.AddIngredient(Mod, "Doomsday", 1)
		.AddIngredient(ModContent.ItemType<DragonsDeath>(), 1)
		.AddIngredient(ModContent.ItemType<PurpleRuneBlade>(), 1)
		.AddTile(TileID.LunarCraftingStation)
		.Register();
		CreateRecipe()
		.AddIngredient(Mod, "CthulhuJudge", 1)	
		.AddIngredient(Mod, "TheBrain", 1)
		.AddIngredient(ItemID.BeeKeeper, 1)
		.AddIngredient(ModContent.ItemType<FixedSwordOfPower>(), 1)
		.AddIngredient(Mod, "PrimeSword", 1)
		.AddIngredient(Mod, "DestroyerSword", 1)
		.AddIngredient(Mod, "TwinsSword", 1)
		.AddIngredient(Mod, "Executioner", 1)
		.AddIngredient(Mod, "Doomsday", 1)
		.AddIngredient(ModContent.ItemType<DragonsDeath>(), 1)
		.AddIngredient(ModContent.ItemType<PurpleRuneBlade>(), 1)
		.AddTile(TileID.LunarCraftingStation)
		.Register();
	}
}
