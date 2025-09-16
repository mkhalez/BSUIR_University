using _453503_Mikhalko_lab1.Collections;
using _453503_Mikhalko_lab1.Entities;

namespace _453503_Mikhalko_lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            // volume cost
            Tariff tariff1 = new Tariff(12, "Moscow", 100);
            Tariff tariff2 = new Tariff(200, "New York", 850);
            Tariff tariff3 = new Tariff(10, "Gomel", 20);

            User user1 = new User("Vova");
            User user2 = new User("Mila");
            User user3 = new User("Sasha");

            TransportSystem system = new TransportSystem();

            system.AddTariff(tariff1);
            system.AddTariff(tariff2);
            system.AddTariff(tariff3);

            system.RegisterUser(user1);
            system.RegisterUser(user2);
            system.RegisterUser(user3);

            //(string userName, string direction, double volume, double cost)
            system.Order("Mila", "Moscow", 12, 100);
            system.Order("Mila", "Gomel", 10, 20);
            system.Order("Sasha", "New York", 200, 850);
            system.Order("Vova", "Gomel", 10, 20);


            Console.WriteLine("Mila ordered for the amount: " + system.CostOfOrderOfUser("Mila"));
            Console.WriteLine("total cost of orders for New York destination: " + system.GetTotalCostInOneDirection("New York"));
            Console.WriteLine("total cost of orders: " + system.GetTotalCostAllOrders());
           

        }
    }
}
