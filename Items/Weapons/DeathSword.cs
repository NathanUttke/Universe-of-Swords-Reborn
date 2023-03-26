using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
        Item.useTime = 60;
        Item.useAnimation = 30;
        Item.damage = 23;
        Item.knockBack = 4f;
        Item.UseSound = SoundID.Item8;
        Item.shoot = ProjectileID.DemonScythe;
        Item.shootSpeed = 10f;
        Item.value = 160200;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.VilePowder, 0f, 0f, 100, default(Color), 2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity.X -= (float)player.direction * 0f;
            Main.dust[dust].velocity.Y -= 0f;
        }
    }
}
