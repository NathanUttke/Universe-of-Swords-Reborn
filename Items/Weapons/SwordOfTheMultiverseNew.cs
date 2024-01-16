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

[LegacyName(new string[] { "SwordOfTheMultiverse" })]
public class SwordOfTheMultiverseNew : ModItem
{
    private readonly int MaxModes = 2;
    private int currentMode = 1;
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Sword of the Multiverse");
        /* Tooltip.SetDefault("'You only get what you give'\nPress left or right click for a alternate attack" +
            "\nHold up or down for a alternate attack"
            ); */
    }

    public override void SetDefaults()
    {
        Item.width = 94;
        Item.height = 104;
        Item.rare = ItemRarityID.Red;

        Item.useTime = 7;
        Item.useAnimation = 25;
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

        Item.ResearchUnlockCount = 1;
        Item.reuseDelay = 0;
        Item.ArmorPenetration = 40;
    }

    public override void NetSend(BinaryWriter writer)
    {
        writer.Write7BitEncodedInt(currentMode);
    }

    public override void NetReceive(BinaryReader reader)
    {
        currentMode = reader.ReadInt32();
    }
    public override void HoldItem(Player player)
    {        
        if (player.whoAmI == Main.myPlayer && PlayerInput.Triggers.Current.MouseRight && !Main.mapFullscreen && !player.controlUseItem && player.ItemTimeIsZero)
        {

            if (currentMode > MaxModes)
            {
                currentMode = 0;
            }

            currentMode++;
            Item.NetStateChanged();
            Main.NewText($"[c/6508CF:Sword Of The Multiverse: Mode {currentMode} has been selected.]");
            player.SetItemTime(15);
        }

        if (currentMode == 1)
        {
            Item.useTime = Item.useAnimation;
            Item.shootSpeed = 25f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = false;
            Item.noUseGraphic = false;
        }
        else if (currentMode == 2)
        {
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = false;
            Item.noUseGraphic = false;            
        }
        else if (currentMode == 3)
        {
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Swing;
        }
    }    
    
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    { 
        if (currentMode == 1)
        {            
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<SwordOfTheMultiverseWave>(), (int)(damage * 2f), knockback, player.whoAmI, 0f, 0f);
        }
        if (currentMode == 2)
        {
            Vector2 targetPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float heightLimit = targetPos.Y;
            if (heightLimit > player.Center.Y - 200f)
            {
                heightLimit = player.Center.Y - 200f;
            }
            for (int j = 0; j < 6; j++)
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
                heading.Normalize();
                heading *= velocity.Length();
                velocity.X = heading.X;
                velocity.Y = heading.Y + Main.rand.Next(-40, 41) * 0.025f;
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<SwordOfTheMultiverseProjectileSmall>(), (int)(damage * 1.5f), knockback, player.whoAmI, 0f, heightLimit);
            }
        }
        else if (currentMode == 3)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<SwordOfTheMultiverseProjectileYoyo>(), (int)(damage * 2f), knockback, player.whoAmI, 0f, 0f);
        }

        return false;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2) && currentMode != 3)
        {
            Dust dust = Dust.NewDustDirect(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<StarDust>(), 0f, 0f, 100, Color.Violet with { A = 0 }, 2f);
            dust.noGravity = true;
        }
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (ModLoader.TryGetMod("CalamityMod", out _))
        {
            damage *= 1.5f;
        }
        return;
    }

    public override void AddRecipes()
	{

        Recipe newRecipe = CreateRecipe();
        newRecipe.AddIngredient(ModContent.ItemType<GreatswordOfTheCosmos>(), 1);
        newRecipe.AddIngredient(ModContent.ItemType<SwordOfTheUniverseNew>(), 1);
        newRecipe.AddIngredient(ModContent.ItemType<SwordOfTheEmperor>(), 1);
        newRecipe.AddIngredient(ModContent.ItemType<ScarletFlareGreatsword>(), 1);
        newRecipe.AddIngredient(ModContent.ItemType<GnomBlade>(), 1);
        newRecipe.AddIngredient(ModContent.ItemType<DamascusBar>(), 50);
        newRecipe.AddIngredient(ModContent.ItemType<Orichalcon>(), 50);
        newRecipe.AddIngredient(ItemID.LunarBar, 25);
        newRecipe.AddIngredient(ModContent.ItemType<LunarOrb>(), 2);
        newRecipe.AddIngredient(ModContent.ItemType<SwordMatter>(), 500);
        newRecipe.AddIngredient(ModContent.ItemType<UselessWeapon>(), 1);
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
		if (!target.HasBuff(ModContent.BuffType<Buffs.EmperorBlaze>()))
		{
            target.AddBuff(ModContent.BuffType<Buffs.EmperorBlaze>(), 700, true);
        }
        if (!target.HasBuff(BuffID.Weak))
        {
            target.AddBuff(BuffID.Weak, 400, true);
        }
    }
}
