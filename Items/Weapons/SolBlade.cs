using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SolBlade : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 82;
		Item.height = 86;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 40;
		Item.useAnimation = 20;
		Item.damage = 100;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item70;
		Item.ArmorPenetration = 5;
		Item.shootSpeed = 12f;
		Item.shoot = ModContent.ProjectileType<Armageddon>();
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}

    public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), newColor: Color.Orange, Scale: 0.75f);
		}
	}
}
