using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class OceanRoar : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 75;
		Item.useAnimation = 25;
		Item.damage = 9;
		Item.shoot = ProjectileID.Typhoon;
		Item.shootSpeed = 1f;
		Item.UseSound = SoundID.Item84;
		Item.value = 5000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}
}
