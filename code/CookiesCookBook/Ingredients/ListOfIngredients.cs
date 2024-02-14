namespace CookiesCookBook.Ingredients
{
    public class ListOfIngredients
    {
        public List<Ingredient> GetListOfIngredients()
        {
           List <Ingredient> ingredients = new List<Ingredient>
           {
               new WhiteFlour(),
               new CoconutFlour(),
               new Butter(),
               new Chocolate(),
               new Suger(),
               new Cardamom(),
               new Cinnamon(),
               new CocoaPowder(),
           };

            return ingredients;
        }

        public List<int> GetListOfIngredientIDs(List<Ingredient> ingredients)
        {
            List<int> listOfIngredientIDs = new List<int>();

            foreach (Ingredient ingredient in ingredients)
            {
                listOfIngredientIDs.Add(ingredient.ID);
            }

            return listOfIngredientIDs;
        }
    }
}