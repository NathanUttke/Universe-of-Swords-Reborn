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
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 50;
		Item.knockBack = 4.5f;		
		//Item.shoot = ModContent.ProjectileType<ClingerSwordProjectile>();
		//Item.shootSpeed = 5f;
		//Item.noMelee = true;
		//Item.noUseGraphic = true;
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

    private float offsetPosition = 70f;
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (target.immortal || NPCID.Sets.CountsAsCritter[target.type] || target.SpawnedFromStatue)
        {
            return;
        }
        int i = 0;
        int direction = 1;

        while (i < 2)
        {
            Projectile.NewProjectile(target.GetSource_OnHit(target), target.Center.X + (offsetPosition * direction), target.Center.Y, 5f * -direction, 0f, ModContent.ProjectileType<ClingerWallProj>(), Item.damage / 2, 0f, player.whoAmI, 0f, 0f);
            direction *= -1;
            i++;
        }
    }
}
