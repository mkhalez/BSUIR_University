using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _453503_Mikhalko_lab1.Interfaces
{
    internal interface ICustomCollection<T>
    {
        T this[int index] { get; set; }
        public void Reset();
        public void MoveNext();
        public T Current();
        int Count { get; }
        void Add(T item);
        void Remove(T item);
        T RemoveCurrent();
    }
}
