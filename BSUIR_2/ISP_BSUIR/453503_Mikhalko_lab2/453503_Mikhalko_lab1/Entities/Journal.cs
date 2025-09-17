using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _453503_Mikhalko_lab1.Tools;
using _453503_Mikhalko_lab2.Collections;

namespace _453503_Mikhalko_lab1.Entities
{
    internal class Journal
    {
        MyCustomCollection<string> events = new MyCustomCollection<string>();

        public void LogEvent(object sender, EntityChangedEventArgs e)
        {
            events.Add(e.ToString());
        }

        public string ShowLog()
        {
            string list = "==Jornal==" + '\n';
            foreach (var item in events)
            {
                list += item.ToString() + '\n';
            }
            return list;
        }
    }
}
