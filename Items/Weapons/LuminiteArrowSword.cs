using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using UniverseOfSwordsMod.Items.Materials;
using Terraria.GameContent.Drawing;
using UniverseOfSwordsMod.Utilities;
using UniverseOfSwordsMod.Particles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class LuminiteArrowSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 26;
		Item.useAnimation = 13;
		Item.damage = 105;
		Item.knockBack = 9f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.MoonlordArrow;
		Item.shootSpeed = 20f;
		Item.value = 220500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (Main.netMode != NetmodeID.Server)
        {
            CyanParticle.Spawn_CyanParticle(new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center,
                IndexOfPlayerWhoInvokedThis = (byte)Main.myPlayer
            });
        }
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            Dust dust = Dust.NewDustDirect(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Clentaminator_Cyan);
            dust.noGravity = true;
        }
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
        proj.timeLeft = 30;
        proj.DamageType = DamageClass.MeleeNoSpeed;
        return false;
    }
}
