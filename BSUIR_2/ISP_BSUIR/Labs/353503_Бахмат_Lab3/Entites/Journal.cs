using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab3.Entites
{
    public class Journal
    {
        private struct EventLogger
        {
            public string Characteristick;
            public string EntitiName;
        };

        private List<EventLogger> eventLoggers = new List<EventLogger>();

        public void TariffsAdd(Dictionary<string, Tariff> tariffs)
        {

            EventLogger eventLogger;
            eventLogger.EntitiName = "Тарифов";
            eventLogger.Characteristick = "стало больше!";

            LogEvent(eventLogger);

        }

        public void TariffsRemove(Dictionary<string, Tariff> tariffs)
        {

            EventLogger eventLogger;
            eventLogger.EntitiName = "Тарифов";
            eventLogger.Characteristick = "стало меньше!";

            LogEvent(eventLogger);

        }

        public void UsersAdd(List<User> users)
        {

            EventLogger eventLogger;
            eventLogger.EntitiName = "Пользователей";
            eventLogger.Characteristick = "стало больше!";

            LogEvent(eventLogger);

        }

        public void UsersRemove(List<User> users)
        {

            EventLogger eventLogger;
            eventLogger.EntitiName = "Пользователей";
            eventLogger.Characteristick = "стало меньше!";

            LogEvent(eventLogger);

        }

        private void LogEvent(EventLogger eventLogger)
        {

            eventLoggers.Add(eventLogger);

        }

        public void InputEvents()
        {

            foreach (var eventLogger in eventLoggers)
            {

                Console.WriteLine(eventLogger.EntitiName + " " + eventLogger.Characteristick);

            }

        }

    }
}
