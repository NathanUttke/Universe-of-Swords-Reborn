using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ClingerSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 62;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 60;
		Item.useAnimation = 60;
		Item.damage = 50;
		Item.knockBack = 4.5f;		
		Item.shoot = ModContent.ProjectileType<ClingerSwordProjectile>();
		Item.shootSpeed = 5f;
		Item.noMelee = true;
		Item.noUseGraphic = true;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.autoReuse = true;

        if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod) && calamityMod.TryFind("TrueMeleeDamageClass", out DamageClass TrueMelee))
        {
            Item.DamageType = TrueMelee;
        }
        else
        {
            Item.DamageType = DamageClass.MeleeNoSpeed;
        }

        Item.ResearchUnlockCount = 1;
	}

    public override bool CanUseItem(Player player)
    {
		return player.ownedProjectileCounts[ModContent.ProjectileType<ClingerSwordProjectile>()] <= 0;
    }
}
