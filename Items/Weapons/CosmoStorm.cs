using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CosmoStorm : ModItem
{
    public override void SetStaticDefaults()
    {
        // Tooltip.SetDefault("'Sword that shatters galaxies'");
    }

    public override void SetDefaults()
    {
        Item.width = 86;
        Item.height = 86;
        Item.rare = ItemRarityID.Red;
        Item.knockBack = 3f;

        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item15;

        Item.damage = 140;
        Item.DamageType = DamageClass.Melee;

        Item.value = 650000;
        Item.autoReuse = true;
        Item.ResearchUnlockCount = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.FragmentNebula, 20)
        .AddIngredient(ItemID.FragmentSolar, 20)
        .AddIngredient(ModContent.ItemType<LunarOrb>(), 1)
        .AddIngredient(ModContent.ItemType<PowerOfTheGalactic>(), 1)
        .AddIngredient(ItemID.LunarBar, 15)
        .AddIngredient(ItemID.NebulaArcanum, 1)
        .AddIngredient(ItemID.TrueExcalibur, 1)
        .AddIngredient(ItemID.LargeAmethyst, 2)
        .AddIngredient(ModContent.ItemType<SwordMatter>(), 45)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        Vector2 hitPosition = Main.rand.NextVector2Circular(200f, 200f);
        hitPosition.SafeNormalize(hitPosition);

        if (target.active && !target.immortal && !NPCID.Sets.CountsAsCritter[target.type] && !target.SpawnedFromStatue)
        {
            Projectile proj = Projectile.NewProjectileDirect(target.GetSource_OnHit(target), target.Center - hitPosition * 20f, hitPosition / 4f, ProjectileID.NebulaArcanum, damageDone, Item.knockBack, player.whoAmI, 0f, 0f);
            proj.DamageType = DamageClass.Melee;
            proj.tileCollide = false;
        }               
    }
}
