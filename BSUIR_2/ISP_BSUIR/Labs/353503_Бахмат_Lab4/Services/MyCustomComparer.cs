using _353503_Бахмат_Lab4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab4.Services
{
    public class MyCustomComparer : IComparer<Baggage>
    {
        public int Compare(Baggage? x, Baggage? y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));

            return string.Compare(x.Name, y.Name, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
