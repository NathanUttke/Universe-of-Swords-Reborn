using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class AncientKatana : ModItem
{
    public override void SetStaticDefaults()
    {
		Tooltip.SetDefault("Better if used with a ninja set.");
    }
    public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 72;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 65;
		Item.knockBack = 4f;
		Item.crit = 15;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (player.head == ItemID.NinjaHood && player.body == ItemID.NinjaShirt && player.legs == ItemID.NinjaPants)
		{
			damage *= 1.04f;
		}
    }

    public override void ModifyWeaponCrit(Player player, ref float crit)
    {
        if (player.head == ItemID.NinjaHood && player.body == ItemID.NinjaShirt && player.legs == ItemID.NinjaPants)
        {
            crit += 1f;
        }
    }

    public override void ModifyItemScale(Player player, ref float scale)
    {
        if (player.head == ItemID.NinjaHood && player.body == ItemID.NinjaShirt && player.legs == ItemID.NinjaPants)
        {
			scale += 0.25f;
        }
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
	{		
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PortalBoltTrail, 0f, 0f, 100, default, 1.3f);
			Main.dust[dust].noGravity = true;
		}
	}
    public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<Orichalcon>(), 5)
		.AddIngredient(ItemID.SoulofFright, 15)
		.AddIngredient(ItemID.SoulofMight, 15)
		.AddIngredient(ItemID.SoulofSight, 15)
		.AddIngredient(ItemID.ChlorophyteBar, 15)
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 2)
		.AddIngredient(ItemID.Katana, 1)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
