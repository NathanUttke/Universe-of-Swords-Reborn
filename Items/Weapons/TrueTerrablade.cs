using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TrueTerrablade : ModItem
{
    public override void SetDefaults()
    {
        Item.damage = 125;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
        Item.width = 92;
        Item.height = 108;
        Item.useTime = 15;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 10f;
        Item.value = Item.sellPrice(0, 5, 0, 0);
        Item.shoot = ModContent.ProjectileType<TrueTerrabladeProjectile>();
        Item.shootSpeed = 18f;
        Item.rare = ItemRarityID.Purple;
        Item.UseSound = SoundID.Item60;
        Item.autoReuse = true;
        Item.useTurn = true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile terraProj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI, 0);
        terraProj.scale = Main.rand.NextFloat(1.25f, 1.75f);
        return false;
    }

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        velocity = velocity.RotatedByRandom(MathHelper.ToRadians(20f));
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {            
        int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.TerraBlade, 0f, 0f, 100, default, 2f);
        Main.dust[dust].noGravity = true;    
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.TerraBlade, 1)
        .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 2)
        .AddIngredient(Mod, "TheNightmareAmalgamation", 1)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }
}
