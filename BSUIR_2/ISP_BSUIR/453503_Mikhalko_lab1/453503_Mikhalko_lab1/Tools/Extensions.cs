using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _453503_Mikhalko_lab1.Tools
{
    internal static class Extensions
    {
        public static T Sum<T>(this IEnumerable<T> data)
        where T : IAdditionOperators<T, T, T>, new()
        {
            T result = new();
            foreach (var item in data)
            {
                result += item;
            }
            return result;
        }
    }
}
