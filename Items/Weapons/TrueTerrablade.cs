using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TrueTerrablade : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Terra Ensis");
    }
    public override void SetDefaults()
    {
        Item.damage = 125;
        Item.DamageType = DamageClass.Melee; 
        Item.width = 62;
        Item.height = 68;

        Item.useTime = 20;
        Item.useAnimation = 16;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.knockBack = 10f;
        Item.value = Item.sellPrice(0, 5, 0, 0);

        Item.shoot = ModContent.ProjectileType<TrueTerrabladeProjectile>();
        Item.shootSpeed = 15f;

        Item.rare = ItemRarityID.Purple;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        SacrificeTotal = 1;
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
        .AddIngredient(ItemID.SpectreBar, 20)
        .AddIngredient(ItemID.BrokenHeroSword, 1)
        .AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }
}
