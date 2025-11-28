using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FurnitureSolutionExtensionExample;

public class FurnitureSolutionExtensionExample : Mod
{
    public override void Load()
    {

    }

    public static void SimpleRecipe(Recipe recipe, int ingredientType)
    {
        recipe.AddIngredient(ingredientType, 5);
        recipe.AddIngredient(ItemID.GreenSolution);
    }
}
