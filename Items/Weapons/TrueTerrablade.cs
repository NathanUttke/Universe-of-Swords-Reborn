using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TrueTerrablade : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Shoots big projectile that explodes into smaller beams after hitting an enemy");
    }

    public override void SetDefaults()
    {
        Item.damage = 125;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
        Item.width = 92;
        Item.height = 108;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 10f;
        Item.value = Item.sellPrice(0, 25, 0, 0);
        Item.shoot = Mod.Find<ModProjectile>("TrueTerrablade").Type;
        Item.shootSpeed = 30f;
        Item.rare = ItemRarityID.Purple;
        Item.UseSound = SoundID.Item60;
        Item.autoReuse = true;
        Item.useTurn = true;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(1))
        {
            int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.TerraBlade, 0f, 0f, 100, default(Color), 2f);
            Main.dust[dust].noGravity = true;
        }
    }

    public override void AddRecipes()
    {
        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.TerraBlade, 1);
        val.AddIngredient(Mod, "TheNightmareAmalgamation", 1);
        val.AddTile(TileID.LunarCraftingStation);
        val.Register();
    }
}
