using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DragonsDeath : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Dragon's Death");
		// Tooltip.SetDefault("'It's great for impersonating dragon hunters'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
        Item.UseSound = SoundID.Item169;

        if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod) && calamityMod.TryFind("TrueMeleeDamageClass", out DamageClass TrueMelee))
        {
            Item.DamageType = TrueMelee;
        }
        else
        {
            Item.DamageType = DamageClass.MeleeNoSpeed;
        }

        Item.damage = 150;
		Item.knockBack = 10f;
        Item.shoot = ModContent.ProjectileType<DragonsDeathProjectile>();
        Item.shootSpeed = 1f;
        Item.noMelee = true;
		Item.noUseGraphic = true;
		Item.value = 490500;
		Item.autoReuse = true;		
		Item.ResearchUnlockCount = 1;
	}

}
