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
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.Size = new(128);
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
        Item.UseSound = SoundID.Item169;
        if (ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod) && CalamityMod.TryFind("TrueMeleeDamageClass", out DamageClass TrueMeleeDamageClass))
        {
            Item.DamageType = TrueMeleeDamageClass;
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
	}		
}
