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
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
    {
        Item.Size = new(64);
        Item.rare = ItemRarityID.Orange;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 4f;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.damage = 23;
        Item.DamageType = DamageClass.Melee;
        Item.scale = 1f;
        Item.crit = 0;
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

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        UniversePlayer modPlayer = player.GetModPlayer<UniversePlayer>();

        for (int i = 0; i < 2; i++)
        {
            modPlayer.GetPointOnSwungItemPath(Item.width, Item.height, 1f * Main.rand.NextFloat(), player.GetAdjustedItemScale(Item), out var location, out var outwardDirection);
            Vector2 velocity = outwardDirection.RotatedBy(MathHelper.PiOver2 * player.direction * player.gravDir);
            Dust dust = Dust.NewDustPerfect(location, DustID.GoldCoin, velocity);
            dust.noGravity = true;
        }
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.Keybrand, new ParticleOrchestraSettings
        {
            PositionInWorld = target.Center + Main.rand.NextVector2Circular(24f, 24f)
        }, player.whoAmI);

        if (!target.HasBuff(BuffID.Midas))
        {
            target.AddBuff(BuffID.Midas, 500);
        }
    }
}
