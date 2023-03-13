using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
		Item.useTime = 10;
		Item.useAnimation = 10;
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
			scale += 0.5f;
        }
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
	{		
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.PortalBoltTrail, 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
		}
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "Orichalcon", 1);
		val.AddIngredient(ItemID.SoulofFright, 15);
		val.AddIngredient(ItemID.SoulofMight, 15);
		val.AddIngredient(ItemID.SoulofSight, 15);
		val.AddIngredient(ItemID.ChlorophyteBar, 15);
		val.AddIngredient(Mod, "UpgradeMatter", 2);
		val.AddIngredient(ItemID.Katana, 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
