using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Projectiles;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Items.Materials;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SwordOfTheMultiverseNew : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword of the Multiverse");
		Tooltip.SetDefault("'You only get what you give'");
	}

    public override void SetDefaults()
    {
        Item.width = 94;
        Item.height = 104;
        Item.rare = ItemRarityID.Expert;

        Item.useTime = 7;
        Item.useAnimation = 25;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item169;

        Item.damage = 190;
        Item.DamageType = DamageClass.Melee;
        Item.knockBack = 2.5f;
        Item.crit = 30;

        Item.scale = 1.20f;
        Item.value = Item.sellPrice(0, 13, 0, 0);

        Item.autoReuse = true;
        Item.noUseGraphic = false;

        Item.shoot = ModContent.ProjectileType<SwordOfTheMultiverseProjectileSmall>();
        Item.shootSpeed = 30f;

        SacrificeTotal = 1;
        ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
    }    

    public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
    {        
        float globalTimeWrapped = Main.GlobalTimeWrappedHourly;
        float itemTime = Item.timeSinceItemSpawned / 240f + globalTimeWrapped * 0.04f;
        Texture2D texture = TextureAssets.Item[Item.type].Value;

        var frame = texture.Frame();

        Vector2 origin = frame.Size() / 2f;
        Vector2 vector2 = new(Item.width / 2 - origin.X, Item.height - frame.Height);
        Vector2 vectorPosition = Item.position - Main.screenPosition + origin + vector2;

        globalTimeWrapped %= 4f;
        globalTimeWrapped /= 2f;
		
        if (globalTimeWrapped >= 1f)
        {
            globalTimeWrapped = 2f - globalTimeWrapped;
        }
		
        globalTimeWrapped = globalTimeWrapped / 2f + 0.5f;
		
        for (float i = 0f; i < 1f; i += 0.25f)
        {
            spriteBatch.Draw(texture, vectorPosition + new Vector2(0.5f, 8f).RotatedBy((i + itemTime) * MathHelper.TwoPi) * globalTimeWrapped, frame, new Color(90, 70, 255, 50), Item.velocity.X * 0.2f, origin, Item.scale, SpriteEffects.None, 0f);
        }
        for (float i = 0f; i < 1f; i += 0.34f)
        {
            spriteBatch.Draw(texture, vectorPosition + new Vector2(0.5f, 4f).RotatedBy((i + itemTime) * MathHelper.TwoPi) * globalTimeWrapped, frame, new Color(140, 120, 255, 77), Item.velocity.X * 0.2f, origin, Item.scale, SpriteEffects.None, 0f);
        }
        return true;
    }

    public override bool CanUseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            if (player.controlUp && !player.controlDown)
            {
                Item.scale = 4.5f;
                Item.shoot = ProjectileID.None;
                Item.noUseGraphic = false;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.useAnimation = 17;
				Item.crit = 40;
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<SwordOfTheMultiverseProjectile>();
                Item.noUseGraphic = true;
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.useAnimation = 27;
				Item.crit = 30;
            }
        }
        else
        {
            Item.shoot = ModContent.ProjectileType<SwordOfTheMultiverseProjectileSmall>();
            Item.noUseGraphic = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.scale = 1.25f;
            Item.useAnimation = 27;
			Item.crit = 30;
        }
        return true;
    }

    public override bool AltFunctionUse(Player player) => true;

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {  
        if (player.altFunctionUse != 2)
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
                Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, (int)(damage * 1.5f), knockback, player.whoAmI, 0f, heightLimit);
            }
        }
        else
        {
            Projectile.NewProjectile(source, position, velocity, type, (int)(damage * 1.5f), knockback, player.whoAmI, 0f, 0f);
        }

        return false;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2) && player.altFunctionUse != 2)
        {
            Dust dust = Main.dust[Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PinkTorch, 0f, 0f, 100, Color.Red, 2f)];
            dust.noGravity = true;
        }
    }

    public override void AddRecipes()
	{
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<GreatswordOfTheCosmos>(), 1)
            .AddIngredient(ModContent.ItemType<SwordOfTheUniverseNew>(), 1)
            .AddIngredient(ModContent.ItemType<SwordOfTheEmperor>(), 1)
            .AddIngredient(ModContent.ItemType<UltraMachine>(), 1)
            .AddIngredient(ModContent.ItemType<GnomBlade>(), 1)
            .AddIngredient(ModContent.ItemType<DamascusBar>(), 50)
            .AddIngredient(ModContent.ItemType<Orichalcon>(), 50)
            .AddIngredient(ItemID.LunarBar, 25)
            .AddIngredient(ModContent.ItemType<LunarOrb>(), 2)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 15)
            .AddIngredient(ModContent.ItemType<UselessWeapon>(), 1)
            .AddTile(TileID.LunarCraftingStation)
			.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (!target.HasBuff(ModContent.BuffType<EmperorBlaze>()))
		{
            target.AddBuff(ModContent.BuffType<EmperorBlaze>(), 700, true);
        }
        if (!target.HasBuff(BuffID.Weak))
        {
            target.AddBuff(BuffID.Weak, 400, true);
        }
    }
}
