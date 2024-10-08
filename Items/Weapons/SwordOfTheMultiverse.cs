using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Projectiles;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Items.Materials;
using Terraria.GameInput;
using System.IO;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Items.Weapons;

[LegacyName(["SwordOfTheMultiverseNew"])]
public class SwordOfTheMultiverse : ModItem
{
    private readonly int MaxModes = 2;
    private int currentMode = 1;
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 84;
        Item.height = 98;
        Item.rare = ItemRarityID.Red;
        Item.useTime = 7;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item169;
        Item.damage = 220;
        Item.DamageType = DamageClass.Melee;
        Item.knockBack = 2.25f;
        Item.crit = 30;
        Item.scale = 1.25f;
        Item.value = Item.sellPrice(0, 12, 0, 0);
        Item.autoReuse = true;
        Item.noMelee = false;
        Item.noUseGraphic = false;        
        Item.shoot = ProjectileID.LunarFlare;
        Item.shootSpeed = 30f;
        Item.ArmorPenetration = 40;
        Item.holdStyle = ItemHoldStyleID.HoldGolfClub;
    }

    public override void NetSend(BinaryWriter writer)
    {
        writer.Write7BitEncodedInt(currentMode);
    }

    public override void NetReceive(BinaryReader reader)
    {
        currentMode = reader.ReadInt32();
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void HoldItem(Player player)
    {        
        if (player.whoAmI == Main.myPlayer && player.controlUseTile && !Main.mapFullscreen && !player.controlUseItem && player.ItemTimeIsZero)
        {
            if (currentMode > MaxModes)
            {
                currentMode = 0;
            }

            currentMode++;
            Item.NetStateChanged();
            //Main.NewText($"[c/6508CF:Mode {currentMode} has been selected.]");
            CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), Colors.RarityPurple, $"Mode {currentMode} has been selected.");
            player.SetItemTime(15);
        }

        switch (currentMode)
        {
            case 1:
                Item.useTime = Item.useAnimation;
                Item.shootSpeed = 25f;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.noMelee = false;
                Item.noUseGraphic = false;
                break;
            case 2:
                Item.useTime = 7;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.noMelee = false;
                Item.noUseGraphic = false;
                break;
            case 3:
                Item.noUseGraphic = true;
                Item.noMelee = true;
                Item.useStyle = ItemUseStyleID.Swing;
                break;
        }
    }    
    
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    { 
        if (currentMode == 1)
        {
            Projectile.NewProjectile(source, player.MountedCenter, velocity, ModContent.ProjectileType<SwordOfTheMultiverseWave>(), damage * 2, knockback, player.whoAmI);
        }
        if (currentMode == 2)
        {
            Vector2 targetPos = Main.MouseWorld;
            for (int j = 0; j < 3; j++)
            {
                position = player.Center + new Vector2(-Main.rand.Next(0, 401) * (float)player.direction, -600f);
                position.Y -= 100 * j;
                Vector2 heading = targetPos - position;
                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }
                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }
                heading = Vector2.Normalize(heading) * velocity.Length();
                velocity = heading + Vector2.UnitY * Main.rand.NextFloat(-41, 40) * 0.025f;
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<MultiverseProjectileSmall>(), damage, knockback, player.whoAmI);
            }
        }
        else if (currentMode == 3)
        {
            Projectile.NewProjectile(source, Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<MultiverseProjectileYoyo>(), damage * 2, knockback, player.whoAmI);
        }

        return false;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Buffs.EmperorBlaze>(), 700, true);
        target.AddBuff(BuffID.Weak, 400, true);
        target.AddBuff(BuffID.Venom, 400, true);

        if (!NPCID.Sets.CountsAsCritter[target.type] && !target.immortal)
        {
            Projectile.NewProjectile(player.GetSource_OnHit(target), target.Center, Vector2.Zero, ModContent.ProjectileType<MultiverseExplosion>(), Item.damage, Item.knockBack, player.whoAmI);
        }
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2) && currentMode != 3)
        {
            Dust.NewDustDirect(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<StarDust>(), Alpha:100, newColor:Color.Violet, Scale:2f);
        }
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (UniverseOfSwordsMod.Instance.CalamityMod is not null)
        {
            damage *= 1.5f;
        }
        return;
    }

    public override void AddRecipes()
	{
        Mod CalamityMod = UniverseOfSwordsMod.Instance.CalamityMod;
        Recipe newRecipe = CreateRecipe();
        newRecipe.AddIngredient(ModContent.ItemType<GreatswordOfTheCosmos>(), 1);
        newRecipe.AddIngredient(ModContent.ItemType<SwordOfTheUniverse>(), 1);
        newRecipe.AddIngredient(ModContent.ItemType<SwordOfTheEmperor>(), 1);
        newRecipe.AddIngredient(ModContent.ItemType<ScarletFlareGreatsword>(), 1);
        newRecipe.AddIngredient(ModContent.ItemType<GnomBlade>(), 1);
        newRecipe.AddIngredient(ItemID.LunarBar, 25);
        newRecipe.AddIngredient(ModContent.ItemType<LunarOrb>(), 2);
        newRecipe.AddIngredient(ModContent.ItemType<SwordMatter>(), 500);
        newRecipe.AddIngredient(ModContent.ItemType<UselessWeapon>(), 1);
        if (CalamityMod is null)
        {
            newRecipe.AddTile(TileID.LunarCraftingStation);
        }
        else if (CalamityMod.TryFind("CosmicAnvil", out ModTile CosmicAnvil))
        {
            newRecipe.AddTile(CosmicAnvil.Type);            
        }        
        newRecipe.Register();
	}
}
