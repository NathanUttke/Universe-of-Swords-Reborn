using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FingerOfDoom : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 13;
		Item.useAnimation = 13;
		Item.damage = 75;
		Item.scale = 1.5f;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = 470100;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		Item.ResearchUnlockCount = 1;
	}

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.Keybrand, new ParticleOrchestraSettings
        {
            PositionInWorld = target.Center,
            MovementVector = player.itemRotation.ToRotationVector2() * 5f * 0.1f + Main.rand.NextVector2Circular(2f, 2f)

        }, player.whoAmI);
    }
}
