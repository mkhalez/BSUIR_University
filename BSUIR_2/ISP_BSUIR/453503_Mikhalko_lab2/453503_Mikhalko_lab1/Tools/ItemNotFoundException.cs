using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _453503_Mikhalko_lab1.Tools
{
    internal class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message) { }
    }
}
