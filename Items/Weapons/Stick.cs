using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons
{
    public class Stick : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'You shouldn't have this'");
		}
		
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32; 
			item.scale = 10.0F;
            item.rare = 10;            
            item.useStyle = 1;             
            item.useTime = 20;
            item.useAnimation = 20;           
            item.damage = 999999; 
            item.knockBack = 100.0F;
            item.UseSound = SoundID.Item1;
            item.value = 15000;					
            item.autoReuse = true; 
            item.melee = true;
	    }
	   
       	public override void UseStyle(Player player)
        {
            player.itemLocation.Y -= 1f * player.gravDir;
		}
    }
}
