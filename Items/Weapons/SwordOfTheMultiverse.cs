using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Projectiles;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SwordOfTheMultiverse : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword of the Multiverse");
		Tooltip.SetDefault("'You only get what you give'");
	}

	public override void SetDefaults()
	{
		Item.width = 94;
		Item.height = 112;
		Item.rare = ItemRarityID.Expert;
		
		Item.useTime = 9;
		Item.useAnimation = 18;        

        Item.damage = 190;
        Item.DamageType = DamageClass.Melee;
        Item.crit = 25;
        Item.knockBack = 2.5f;

		Item.value = Item.sellPrice(0, 15, 0, 0);

        Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item169;

        Item.autoReuse = true;

        Item.shoot = ModContent.ProjectileType<SwordOfTheMultiverseProjectileSmall>();
        Item.shootSpeed = 30f;

        Item.noUseGraphic = false;
        Item.noMelee = true;

        SacrificeTotal = 1;
        //ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
	}

    public override bool CanUseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            Item.shoot = ModContent.ProjectileType<SwordOfTheMultiverseProjectile>(); 
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Shoot;
        }
        else
        {
            Item.shoot = ModContent.ProjectileType<SwordOfTheMultiverseProjectileSmall>();
            Item.noUseGraphic = false;
            Item.useStyle = ItemUseStyleID.Swing;
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
                Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, Item.shoot, (int)(damage * 1.33f), knockback, player.whoAmI, 0f, heightLimit);
            }
        }
        else
        {
            Projectile.NewProjectile(source, position, velocity, Item.shoot, (int)(damage * 1.33f), knockback, player.whoAmI, 0f, 0f);
        }

        return false;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            Dust dust = Main.dust[Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.DemonTorch, 0f, 0f, 100, default, 2f)];
            dust.noGravity = true;
        }
    }

    public override void AddRecipes()
	{
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<GreatswordOfTheCosmos>(), 1)
            .AddIngredient(ModContent.ItemType<SwordOfTheUniverseV2>(), 1)
            .AddIngredient(ModContent.ItemType<SwordOfTheEmperor>(), 1)
            .AddIngredient(ModContent.ItemType<ScarledFlareGreatsword>(), 1)
            .AddIngredient(ModContent.ItemType<UltraMachine>(), 1)
            .AddIngredient(ModContent.ItemType<GnomBlade>(), 1)
            .AddIngredient(ModContent.ItemType<DamascusBar>(), 50)
            .AddIngredient(ModContent.ItemType<Orichalcon>(), 50)
            .AddIngredient(ItemID.LunarBar, 25)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 15)
            .AddIngredient(ModContent.ItemType<UselessWeapon>(), 1)
			.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (!target.HasBuff(ModContent.BuffType<EmperorBlaze>()))
		{
            target.AddBuff(ModContent.BuffType<EmperorBlaze>(), 800, true);
        }
        if (!target.HasBuff(BuffID.Weak) && Main.rand.NextBool(2))
        {
            target.AddBuff(BuffID.Weak, 400, true);
        }
    }
}
