using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _353503_Бахмат_Lab1.Interfaces;

namespace _353503_Бахмат_Lab1.Collections
{

    public class MyCustomeCollection<T> : ICustomeCollection<T>
    {
        public class Node
        {
            public Node? Next { get; set; }
            public T Value { get; set; }
            public Node(T value) { Value = value; Next = null; }
            public Node(T value, Node? next) { Value = value; Next = next; }
        }
        private Node? Root;
        private Node? Current;
        private Node? End;

        public MyCustomeCollection()
        {
            Root = null;
            Current = null;
            End = null;
        }

        private int count = 0;
        public void Reset()
        {

            Current = Root;

        }
        public void Next()
        {

            if (Current is null) return;
            if (Current.Next is null) return;

            Current = Current.Next;

        }
        public T GetCurrent()
        {

            if (Current is null) throw new System.NullReferenceException();

            return Current.Value;

        }
        public int Count => count;

        public T this[int index]
        {

            get
            {

                if (Root is null) throw new System.NullReferenceException();

                int CurPos = 0;
                Node? TempNode = Root;
                while (CurPos != index && TempNode is not null)
                {

                    TempNode = TempNode.Next;
                    ++CurPos;

                }

                if (TempNode is null) throw new System.NullReferenceException();

                return TempNode.Value;

            }

            set
            {

                if (Root is null) throw new System.NullReferenceException();

                int CurPos = 0;
                Node TempNode = Root;
                while (CurPos != index && TempNode is not null)
                {

                    if (TempNode.Next is null) throw new System.IndexOutOfRangeException();
                    TempNode = TempNode.Next;
                    ++CurPos;

                }

                if (TempNode is null) throw new System.NullReferenceException();

                TempNode.Value = value;
            }

        }
        public void Add(T item)
        {

            if (Root == null)
            {

                End = null;
                Root = new Node(item, End);
                Current = Root;

            }
            else
            {

                Node? tempNode = Root;
                while (tempNode.Next is not null)
                {

                    tempNode = tempNode.Next;

                }

                tempNode.Next = new Node(item);

            }

            ++count;

        }
        public void Remove(T item)
        {
            Node? TempCurrent = Root;

            if (TempCurrent is null) throw new System.NullReferenceException();

            if (TempCurrent.Next is null) throw new System.NullReferenceException();

            while (TempCurrent.Next is not null)
            {

                if (EqualityComparer<T>.Default.Equals(TempCurrent.Value, item))
                {

                    TempCurrent.Value = TempCurrent.Next.Value;
                    TempCurrent.Next = TempCurrent.Next.Next;

                }
                else
                {

                    TempCurrent = TempCurrent.Next;

                }

            }

            if (TempCurrent is not null)
            {

                if (EqualityComparer<T>.Default.Equals(TempCurrent.Value, item))
                {

                    TempCurrent = null;

                }

            }

        }
        public T RemoveCurrent()
        {
            if (Current is null || Current.Next is null) throw new System.NullReferenceException();

            T RemovedData = Current.Value;

            Current.Value = Current.Next.Value;
            Current.Next = Current.Next.Next;

            return RemovedData;

        }
    }
}
