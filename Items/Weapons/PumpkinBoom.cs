using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PumpkinBoom : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
        Item.UseSound = SoundID.Item1;
        Item.damage = 50;
		Item.knockBack = 6.5f;				
		Item.scale = 1.5f;
		Item.value = 360500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
	}

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            Dust dust = Dust.NewDustDirect(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.OrangeTorch, Scale: 2f);
            dust.noGravity = true;
        }
    }

    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<PumpkinSword>(), 1)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (ModLoader.TryGetMod("CalamityMod", out _))
        {
            damage *= 1.05f;
        }
        return;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.Excalibur, new ParticleOrchestraSettings
        {
            PositionInWorld = target.Center + Main.rand.NextVector2Circular(24f, 24f)
        }, player.whoAmI);

        Projectile.NewProjectileDirect(target.GetSource_OnHit(target), target.Center, Vector2.Zero, ProjectileID.SolarWhipSwordExplosion, (int)(damageDone / 2f), Item.knockBack / 2f, player.whoAmI, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);
    }
}
