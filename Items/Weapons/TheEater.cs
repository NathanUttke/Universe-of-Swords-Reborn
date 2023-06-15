using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheEater : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'Sword of Corruption'");
    }

    public override void SetDefaults()
    {
        Item.width = 54;
        Item.height = 58;
        Item.rare = ItemRarityID.LightPurple;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 40;
        Item.useAnimation = 20;
        Item.damage = 17;
        Item.knockBack = 4f;
        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(0, 0, 75, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        if (Main.rand.NextBool(2))
        {
            Projectile.NewProjectile(target.GetSource_OnHit(target), target.position, new Vector2(7f * Utils.SelectRandom(Main.rand, -1, 1, 1, -1, 1, -1), 7f), ProjectileID.TinyEater, (int)(Item.damage * 0.5f + Main.rand.Next(1, 4)), 4f, player.whoAmI);
        }
    }


    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        velocity = velocity.RotatedByRandom(MathHelper.ToRadians(25f));
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CorruptPlants, 0f, 0f, 127, default, 1.25f);
            Main.dust[dust].noGravity = true;
        }
    }
}
