using TesteMeu.Models;

namespace TesteMeu.Data
{
    public class AllPizzas
    {
        private static Pizza[] AllPizzasArray = [
                new Pizza { Id = 1, Sabor = "Calabresa", Preco = 16 },
                new Pizza { Id = 2, Sabor = "Margarita", Preco = 14 },
                new Pizza { Id = 3, Sabor = "Quatro Queijos", Preco = 18 },
                new Pizza { Id = 4, Sabor = "Portuguesa", Preco = 20 }
        ]; 

        public static Pizza[] GetAllPizzas()
        {   
            return AllPizzasArray;
        }

        public static bool AddPizza(Pizza newPizza)
        {
            AllPizzasArray.Append(newPizza);

            return true;
        }
    }
}
