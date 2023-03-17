using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Fireball : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 54;
        Item.height = 54;
        Item.scale = 1.2f;
        Item.rare = ItemRarityID.LightRed;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.damage = 31;
        Item.knockBack = 5f;
        Item.shoot = ProjectileID.BallofFire;
        Item.shootSpeed = 10f;
        Item.UseSound = SoundID.Item20;
        Item.value = Item.sellPrice(0, 3, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.Y -= 1f * player.gravDir;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity.X += (float)player.direction * 0f;
            Main.dust[dust].velocity.Y += 0f;
            dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity.X += (float)player.direction * 0f;
            Main.dust[dust].velocity.Y += 0f;
        }
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(24, 360, false);
    }
}
