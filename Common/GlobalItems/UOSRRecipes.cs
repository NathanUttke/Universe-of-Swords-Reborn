using Terraria.GameContent.ItemDropRules;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Common.GlobalItems
{
    public class UOSRRecipes : ModSystem
    {
        public static RecipeGroup UOSRRecipeGroup;

        public override void Unload()
        {
            UOSRRecipeGroup = null;
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

        public override void AddRecipes()
        {
            Recipe terrgrimRecipe = Recipe.Create(ItemID.Terragrim, 1);
            terrgrimRecipe.AddIngredient(ItemID.EnchantedSword, 1);
            terrgrimRecipe.AddIngredient(ModContent.ItemType<SwordMatter>(), 15);
            terrgrimRecipe.Register();
        }
    }
}

