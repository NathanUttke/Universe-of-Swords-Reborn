using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PowerOfTheGalactic : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 22;
        Item.useAnimation = 22;
        Item.damage = 125;
        Item.knockBack = 7f;
        Item.scale = 1.25f;
        Item.shoot = ModContent.ProjectileType<GalacticProjectile>();
        Item.shootSpeed = 15f;
        Item.UseSound = SoundID.Item1;
        Item.value = 650500;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.FragmentSolar, 15)
        .AddIngredient(ItemID.FragmentVortex, 15)
        .AddIngredient(ItemID.FragmentNebula, 15)
        .AddIngredient(ItemID.FragmentStardust, 15)
        .AddIngredient(ItemID.LunarBar, 8)
        .AddIngredient(ModContent.ItemType<LunarOrb>(), 1)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int i = 0; i < 2; i++)
        {
            Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(40)) * Main.rand.NextFloat(0.9f, 1.3f), type, damage * 2, knockback, player.whoAmI);
        }
        return false;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Cyan with { A = 0 }, 1.5f);
            Main.dust[dust].noGravity = true;
        }
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (!target.HasBuff(BuffID.Frostburn))
        {
            target.AddBuff(BuffID.Frostburn, 400, false);

        }
    }
}
