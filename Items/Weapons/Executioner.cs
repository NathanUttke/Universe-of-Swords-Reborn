using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Executioner : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 78;
        Item.height = 78;
        Item.scale = 1f;
        Item.rare = ItemRarityID.Lime;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 20;
        Item.damage = 65;
        Item.knockBack = 6f;
        Item.shoot = ModContent.ProjectileType<ExecutionerHoldoutProj>();
        Item.shootSpeed = 1f;
        Item.value = Item.sellPrice(0, 3, 0, 0);
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.noMelee = true;
        Item.DamageType = DamageClass.Melee; 
    }

    public override bool MeleePrefix() => true;
    public override bool CanUseItem(Player player) => player.ownedProjectileCounts[Item.shoot] < 1;
}
