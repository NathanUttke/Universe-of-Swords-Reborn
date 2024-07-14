using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ClingerSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

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
		Item.shoot = ModContent.ProjectileType<ClingerSlashProj>();
		Item.shootSpeed = 5f;
		Item.noMelee = true;
        Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.autoReuse = true;

        if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod) && calamityMod.TryFind("TrueMeleeDamageClass", out DamageClass TrueMelee))
        {
            Item.DamageType = TrueMelee;
        }
        else
        {
            Item.DamageType = DamageClass.Melee;
        }
	}


    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.

        Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
        NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.

        return false;
    }
}
