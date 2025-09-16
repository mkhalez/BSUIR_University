using _353503_Бахмат_Lab1.Entites;

namespace _353503_Бахмат_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Provider provider = new Provider();

            provider.AddTariff(new Tariff("Базовый", 0.5));
            provider.AddTariff(new Tariff("Премиум", 1.0));

            provider.RegisterUser(new User("Анна"));
            provider.RegisterUser(new User("Владимир"));

            provider.AddTrafficData("Анна", "Базовый", 100);
            provider.AddTrafficData("Анна", "Премиум", 50);
            provider.AddTrafficData("Владимир", "Базовый", 200);

            Console.WriteLine($"Общая стоимость для Анны: {provider.GetTotalCostForUser("Анна")}");
            Console.WriteLine($"Общая стоимость для Владимира: {provider.GetTotalCostForUser("Владимир")}");

            var highestCostUser = provider.GetUserWithHighestCost();
            Console.WriteLine($"Пользователь с наибольшей стоимостью: {highestCostUser.Name}");

            Console.WriteLine($"Общие выплаты по тарифу Базовый: {provider.GetTotalPaymentsForTariff("Базовый")}");
        }
    }
}
