using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheBrain : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.Size = new(58);
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;		
		Item.useTime = 40;
		Item.useAnimation = 20;
		Item.UseSound = SoundID.Item1;		
		Item.damage = 15;
		Item.knockBack = 3f;
		Item.scale = 1.25f;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{		
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood, Scale:2f);
			Main.dust[dust].noGravity = true;
		}
	}
}
