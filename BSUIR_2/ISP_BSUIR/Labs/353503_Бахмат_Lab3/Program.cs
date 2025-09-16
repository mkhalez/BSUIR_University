using _353503_Бахмат_Lab3.Entites;

namespace _353503_Бахмат_Lab3
{
    class Program
    {

        static void Main(string[] args)
        {
            Provider provider = new Provider();
            Journal journal = new Journal();

            provider.ChangeUsersCollection += journal.UsersAdd;
            provider.ChangeTariffsServisecCollection += journal.TariffsAdd;

            provider.ChangeTariffsServisecCollection += d => Console.WriteLine($"-------> collection count is {d.Count}");

            provider.AddTariff(new Tariff("Базовый", 0.5));
            provider.AddTariff(new Tariff("Премиум", 1.0));

            provider.RegisterUser(new User("Анна"));
            provider.RegisterUser(new User("Владимир"));

            provider.AddTrafficData("Анна", "Базовый", 100);
            provider.AddTrafficData("Анна", "Премиум", 50);
            provider.AddTrafficData("Владимир", "Базовый", 200);

            var tariffNames = provider.GetTariffNamesSortedByCost();
            Console.WriteLine("Тарифы отсортированы по стоимости:");
            foreach (var name in tariffNames)
            {
                Console.WriteLine(name);
            }

            double totalTrafficCost = provider.GetTotalTrafficCost();
            Console.WriteLine($"Общая стоимость всего трафика: {totalTrafficCost}");

            string maxCostUser = provider.GetUserWithMaxTotalCost();
            Console.WriteLine($"Пользователь с наибольшей оплатой: {maxCostUser}");

            int usersAboveCost = provider.GetUsersCountWithCostGreaterThan(100);
            Console.WriteLine($"Количество пользователей, заплативших больше 100: {usersAboveCost}");

            var userCountByTariff = provider.GetUserCountByTariff();
            Console.WriteLine("Количество пользователей по каждому тарифу:");
            foreach (var entry in userCountByTariff)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}