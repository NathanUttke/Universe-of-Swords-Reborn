using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Inflation : ModItem
{
    public override void SetStaticDefaults()
    {
        // Tooltip.SetDefault("Congratulations, you made an overpriced sword!");
    }

    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.Orange;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 4f;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.damage = 23;
        Item.DamageType = DamageClass.Melee;
        Item.scale = 1f;
        Item.crit = 8;
        Item.UseSound = SoundID.Item169;
        Item.value = 0;
        Item.autoReuse = true;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
           .AddIngredient(ItemID.PlatinumCoin, 20)
           .AddIngredient(ItemID.GoldenCrate, 5)
           .AddIngredient(ItemID.GoldBar, 200)
           .AddIngredient(ItemID.GoldBroadsword, 1)
           .AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
           .AddTile(TileID.Anvils)
           .Register();
        CreateRecipe()
            .AddIngredient(ItemID.PlatinumCoin, 20)
            .AddIngredient(ItemID.GoldenCrateHard, 5)
            .AddIngredient(ItemID.PlatinumBar, 200)
            .AddIngredient(ItemID.PlatinumBroadsword, 1)
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
            .AddTile(TileID.Anvils)
            .Register();
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.Keybrand, new ParticleOrchestraSettings
        {
            PositionInWorld = target.Center,
            MovementVector = player.itemRotation.ToRotationVector2() * 5f * 0.1f + Main.rand.NextVector2Circular(2f, 2f)

        }, player.whoAmI);

        if (!target.HasBuff(BuffID.Midas))
        {
            target.AddBuff(BuffID.Midas, 500);
        }
    }
}
