using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab1.Interfaces;

public interface ICustomeCollection<T>
{
    T this[int index] { get; set; }
    void Reset();
    void Next();
    T GetCurrent();
    int Count { get; }
    void Add(T item);
    void Remove(T item);
    T RemoveCurrent();
}
