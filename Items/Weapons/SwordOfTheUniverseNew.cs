using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SwordOfTheUniverseNew : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sword of the Universe");
		// Tooltip.SetDefault("'This sword doesn't swing. It lifts the Universe towards the blade'");
	}

	public override void SetDefaults()
	{
		Item.width = 140;
		Item.height = 140;
		Item.rare = ItemRarityID.Purple;
		Item.crit = 20;

		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 8;
		Item.useAnimation = 20;

		Item.damage = 190;
		Item.knockBack = 20f;
		Item.UseSound = SoundID.Item169;

		Item.shoot = ModContent.ProjectileType<SwordOfTheUniverseV2Projectile>();
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 8, 0, 0);

        Item.rare = ItemRarityID.Red;
        Item.autoReuse = true;

		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}

	public override void AddRecipes()
	{
		Recipe newRecipe = CreateRecipe();
		newRecipe.AddIngredient(ModContent.ItemType<CosmoStorm>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<SuperInflation>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<EdgeLord>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<TheNightmareAmalgamation>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<SolBlade>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<SwordMatter>(), 100);
        if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod) && calamityMod.TryFind("AuricBar", out ModItem auricBar))
        {
            newRecipe.AddIngredient(auricBar.Type, 5);
        }
		newRecipe.AddTile(TileID.LunarCraftingStation);
        newRecipe.Register();
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
        Projectile.NewProjectileDirect(source, position, velocity, Item.shoot, (int)(damage * 1.25f), knockback, player.whoAmI);
        return false;
	}

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2) && player.altFunctionUse != 2)
        {
            Dust dust = Main.dust[Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PortalBoltTrail, 0f, 0f, 100, Utils.SelectRandom(Main.rand, Color.Aqua, Color.Red, Color.Pink, Color.Yellow, Color.Blue), 1.5f)];
            dust.noGravity = true;
        }
    }

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
		velocity = velocity.RotatedByRandom(MathHelper.ToRadians(20f));
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(72, 360, false);
		target.AddBuff(69, 360, false);
		target.AddBuff(44, 360, false);
		target.AddBuff(24, 360, false);
		target.AddBuff(20, 360, false);
		target.AddBuff(39, 360, false);
	}
}
