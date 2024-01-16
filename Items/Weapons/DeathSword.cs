using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DeathSword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 72;
        Item.scale = 1f;
        Item.rare = ItemRarityID.LightRed;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 70;
        Item.useAnimation = 30;
        Item.damage = 20;
        Item.knockBack = 4f;
        Item.UseSound = SoundID.Item8;
        Item.shoot = ModContent.ProjectileType<PurpleScytheClone>();
        Item.shootSpeed = 7f;
        Item.value = 160200;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.MediumOrchid, 2f);
        }
    }
}
