using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
        Item.value = Item.sellPrice(0, 12, 0, 0);
        Item.shoot = ModContent.ProjectileType<TrueTerrabladeProjectile>();
        Item.shootSpeed = 18f;
        Item.rare = ItemRarityID.Purple;
        Item.UseSound = SoundID.Item60;
        Item.autoReuse = true;
        Item.useTurn = true;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {            
        int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.TerraBlade, 0f, 0f, 100, default(Color), 2f);
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
