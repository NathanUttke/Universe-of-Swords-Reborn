using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ShroomiteBlade : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.Lime;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.damage = 70;
        Item.knockBack = 7.2f;
        Item.UseSound = SoundID.Item1;
        Item.value = 280000;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee;
        Item.scale = 1.125f;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        UniversePlayer modPlayer = player.GetModPlayer<UniversePlayer>();

        for (int i = 0; i < 4; i++)
        {
            modPlayer.GetPointOnSwungItemPath(Item.width, Item.height, 1f * Main.rand.NextFloat(), player.GetAdjustedItemScale(Item), out var location, out var outwardDirection);
            Vector2 velocity = outwardDirection.RotatedBy(MathHelper.PiOver2 * player.direction * player.gravDir);
            Dust dust = Dust.NewDustPerfect(location, DustID.MushroomSpray, velocity);
            dust.noGravity = true;
        }
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.ShroomiteBar, 15)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}
