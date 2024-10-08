using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CosmoStorm : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
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
        Item.damage = 150;
        Item.DamageType = DamageClass.Melee;
        Item.value = 650000;
        Item.autoReuse = true;
        Item.scale = 1.25f;
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (ModLoader.TryGetMod("CalamityMod", out _))
        {
            damage *= 6f;
        }
        return;
    }

    public override void ModifyItemScale(Player player, ref float scale)
    {
        if (ModLoader.TryGetMod("CalamityMod", out _))
        {
            scale *= 1.75f;
        }
        return;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        UniversePlayer modPlayer = player.GetModPlayer<UniversePlayer>();

        for (int i = 0; i < 2; i++)
        {
            modPlayer.GetPointOnSwungItemPath(Item.width, Item.height, 1f * Main.rand.NextFloat(), player.GetAdjustedItemScale(Item), out var location, out var outwardDirection);
            Vector2 velocity = outwardDirection.RotatedBy(MathHelper.PiOver2 * player.direction * player.gravDir);
            Dust dust = Dust.NewDustPerfect(location, DustID.WitherLightning, velocity, Scale: 1.25f);
            dust.noGravity = true;
        }
    }

    public override void AddRecipes()
    {
        Recipe newRecipe = CreateRecipe();
        newRecipe.AddIngredient(ItemID.FragmentNebula, 20);
        newRecipe.AddIngredient(ItemID.FragmentSolar, 20);
        newRecipe.AddIngredient(ModContent.ItemType<LunarOrb>(), 1);        
        newRecipe.AddIngredient(ItemID.LunarBar, 15);
        newRecipe.AddIngredient(ItemID.NebulaArcanum, 1);
        newRecipe.AddIngredient(ModContent.ItemType<SwordMatter>(), 45);
        if (ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod) && CalamityMod.TryFind("CosmicAnvil", out ModTile CosmicAnvil))
        {
            newRecipe.AddTile(CosmicAnvil.Type);
        }
        else
        {
            newRecipe.AddTile(TileID.LunarCraftingStation);
        }
        newRecipe.Register();
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (!target.active || target.immortal || NPCID.Sets.CountsAsCritter[target.type] || target.SpawnedFromStatue)
        {
            return;
        }

        if (player.GetModPlayer<UniversePlayer>().swordTimer == 0)
        {
            player.GetModPlayer<UniversePlayer>().swordTimer = 20;
        }
        else
        {
            return;
        }

        for (int i = 0; i < 12; i++)
        {
            Vector2 offsetPosition = target.position + new Vector2(Main.rand.Next(-2000, 1000), -Main.rand.Next(500, 800));
            Vector2 spawnVelocity = Vector2.Normalize(target.Center - offsetPosition) * 12f;

            Projectile.NewProjectileDirect(target.GetSource_OnHit(target), offsetPosition, spawnVelocity, ModContent.ProjectileType<CosmoStormProj>(), Item.damage, 5f, player.whoAmI);         
        }
    }
}
