using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _353503_Бахмат_Lab2.Interfaces;

namespace _353503_Бахмат_Lab2.Collections
{
    public class MyCustomeCollection<T> : ICustomeCollection<T>, IEnumerable<T>
    {
        public class Node
        {
            public Node? Next { get; set; }
            public T Value { get; set; }
            public Node(T value) { Value = value; Next = null; }
            public Node(T value, Node? next) { Value = value; Next = next; }
        }

        private Node? Root;
        private Node? End;
        private Node? CurrentNode;  // Указатель на текущий элемент
        private int count = 0;

        public MyCustomeCollection()
        {
            Root = null;
            End = null;
            CurrentNode = null;
        }

        public int Count => count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                Node? current = Root;
                for (int i = 0; i < index; i++)
                {
                    current = current?.Next;
                }

                if (current == null) throw new NullReferenceException();

                return current.Value;
            }

            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                Node? current = Root;
                for (int i = 0; i < index; i++)
                {
                    current = current?.Next;
                }

                if (current == null) throw new NullReferenceException();

                current.Value = value;
            }
        }

        public void Add(T item)
        {
            Node newNode = new Node(item);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                Node? current = Root;
                while (current?.Next != null)
                {
                    current = current.Next;
                }
                current!.Next = newNode;
            }
            count++;
        }

        public void Remove(T item)
        {
            if (Root == null)
                throw new NullReferenceException();

            Node? current = Root;
            Node? previous = null;

            while (current != null && !EqualityComparer<T>.Default.Equals(current.Value, item))
            {
                previous = current;
                current = current.Next;
            }

            if (current == null)
                throw new ItemNotFoundException("Элемент не найден в коллекции.");

            if (previous == null)
            {
                Root = Root.Next;
            }
            else
            {
                previous.Next = current.Next;
            }

            count--;
        }

        public T RemoveCurrent()
        {
            if (CurrentNode == null)
                throw new System.IndexOutOfRangeException();

            T currentValue = CurrentNode.Value;

            Remove(currentValue);

            return currentValue;
        }

        public void Reset()
        {
            CurrentNode = Root;
        }
        public void Next()
        {
            if (CurrentNode == null)
                throw new System.IndexOutOfRangeException();

            CurrentNode = CurrentNode.Next;
        }

        public T GetCurrent()
        {
            if (CurrentNode == null)
                throw new System.IndexOutOfRangeException();

            return CurrentNode.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node? tempCurr = Root;
            while (tempCurr is not null)
            {
                yield return tempCurr.Value;
                tempCurr = tempCurr.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message) { }
    }
}
    
