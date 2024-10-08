using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Common.GlobalItems
{
    public class UniverseRecipes : ModSystem
    {
        public static RecipeGroup UOSRecipeGroup;

        public override void Unload()
        {
            UOSRecipeGroup = null;
        }

        public override void AddRecipeGroups()
        {
            //EXAMPLES

            ////hardmode anvils
            //RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Hardmode Anvil", new int[]
            //{
            //    ItemID.OrichalcumAnvil,
            //    ItemID.MythrilAnvil
            //});
            //RecipeGroup.RegisterGroup("FlexTapeIII:HardmodeAnvils", group);


            ////pre-hardmode anvils
            //group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Anvil", new int[]
            //{
            //    ItemID.IronAnvil,
            //    ItemID.LeadAnvil
            //});
            //RecipeGroup.RegisterGroup("FlexTapeIII:Anvils", group);
        }


        public static void CalamityRecipes()
        {
            Mod CalamityMod = UniverseOfSwordsMod.Instance.CalamityMod;

            for (int i = 0; i < Main.recipe.Length; i++)
            {
                if (CalamityMod != null && CalamityMod.TryFind("Terratomere", out ModItem Terratomere))
                {
                    if (Main.recipe[i].HasResult(Terratomere.Type))
                    {
                        Recipe terraRecipe = Main.recipe[i].Clone();
                        terraRecipe.RemoveIngredient(ItemID.TerraBlade);
                        terraRecipe.AddIngredient(ModContent.ItemType<TerraEnsis>());
                        terraRecipe.Register();
                        break;
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            CalamityRecipes();
            Recipe.Create(ItemID.Terragrim, 1)
            .AddIngredient(ItemID.EnchantedSword, 1)
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
            .Register();
        }
    }
}

