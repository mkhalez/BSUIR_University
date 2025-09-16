using _353503_Бахмат_Lab2.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _353503_Бахмат_Lab2.Entites
{
    public class Journal
    {
        private struct EventLogger
        {
            public string Characteristick;
            public string EntitiName;
        };

        private MyCustomeCollection<EventLogger> eventLoggers = new MyCustomeCollection<EventLogger>();

        public void TariffsAdd(MyCustomeCollection<Tariff> tariffs)
        {

            EventLogger eventLogger;
            eventLogger.EntitiName = "Тарифов";
            eventLogger.Characteristick = "стало больше!";

            LogEvent(eventLogger);

        }

        public void TariffsRemove(MyCustomeCollection<Tariff> tariffs)
        {

            EventLogger eventLogger;
            eventLogger.EntitiName = "Тарифов";
            eventLogger.Characteristick = "стало меньше!";

            LogEvent(eventLogger);

        }

        public void UsersAdd(MyCustomeCollection<User> users)
        {

            EventLogger eventLogger;
            eventLogger.EntitiName = "Пользователей";
            eventLogger.Characteristick = "стало больше!";

            LogEvent(eventLogger);

        }

        public void UsersRemove(MyCustomeCollection<User> users)
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
