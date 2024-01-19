using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using static Humanizer.In;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CosmoStorm : ModItem
{
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
        Item.ResearchUnlockCount = 1;
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
            scale *= 2.25f;
        }
        return;
    }

    public override void AddRecipes()
    {
        Recipe newRecipe = CreateRecipe();
        newRecipe.AddIngredient(ItemID.FragmentNebula, 20);
        newRecipe.AddIngredient(ItemID.FragmentSolar, 20);
        newRecipe.AddIngredient(ModContent.ItemType<LunarOrb>(), 1);
        newRecipe.AddIngredient(ModContent.ItemType<PowerOfTheGalactic>(), 1);
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
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
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

        for (int i = 0; i < 3; i++)
        {
            Vector2 offsetPosition = new(target.position.X + Main.rand.Next(-400, 400), target.position.Y - Main.rand.Next(500, 800));
            Vector2 spawnVelocity = new(target.Center.X - offsetPosition.X, target.Center.Y - offsetPosition.Y);

            float spawnDistance = spawnVelocity.Length();
            spawnDistance = 10f / spawnDistance;
            spawnVelocity.X *= spawnDistance;
            spawnVelocity.Y *= spawnDistance;

            Projectile summonProjectile = Projectile.NewProjectileDirect(player.GetSource_ItemUse(Item), offsetPosition, spawnVelocity, ProjectileID.NebulaArcanum, damageDone / 3, 5f, player.whoAmI, 0f, 0f);
            summonProjectile.extraUpdates = 2;
            summonProjectile.penetrate = 1;
            summonProjectile.timeLeft = 200;
            summonProjectile.DamageType = DamageClass.Melee;
            summonProjectile.tileCollide = false;            
        }
    }
}
