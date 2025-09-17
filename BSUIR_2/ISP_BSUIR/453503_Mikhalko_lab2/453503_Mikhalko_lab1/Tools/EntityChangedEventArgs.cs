using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _453503_Mikhalko_lab1.Tools
{
    internal class EntityChangedEventArgs : EventArgs
    {
        public string Action { get; }
        public string EntityType { get; }
        public string Info { get; }

        public EntityChangedEventArgs(string action, string entityType, string info)
        {
            Action = action;
            EntityType = entityType;
            Info = info;
        }

        public override string ToString()
        {
            return $"{Action} {EntityType}: {Info}";
        }
    }
}
