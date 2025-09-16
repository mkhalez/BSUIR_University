using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using _453503_Mikhalko_lab1.Interfaces;
using System.Collections;

namespace _453503_Mikhalko_lab1.Collections
{
    internal class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable<T>
    {
        internal class Node 
            
        {
            public T data;
            public Node next;
        }

        private Node head;
        private Node tail;
        private Node cursor;
        private int count = 0;

        private class Enumerator : IEnumerator<T>
        {
            private readonly MyCustomCollection<T> collection;

            public Enumerator(MyCustomCollection<T> collection)
            {
                this.collection = collection;
                collection.Reset();
                beforeFirst = true;
            }

            private bool beforeFirst;

            public bool MoveNext()
            {
                if (beforeFirst)
                {
                    beforeFirst = false;
                    return collection.head != null;
                }

                try
                {
                    collection.MoveNext();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public void Reset()
            {
                collection.Reset();
                beforeFirst = true;
            }

            public T Current => collection.Current();

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void Add(T item)
        {
            Node newNode = new Node();
            newNode.data = item;

            if (head == null)
            {
                head = newNode;
                tail = head;
                cursor = head;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }

            count++;            
        }
        public void Reset() { 
            cursor = head;
        }

        public void MoveNext() {
            if (cursor == null || cursor.next == null) {
                throw new InvalidOperationException("невозможно перейти к следующему элементу");
            }
            cursor = cursor.next;
        }

        public T Current()
        {
            if(cursor == null)
                throw new ArgumentException("Курсор не установлен на элемент");
           
            return cursor.data;
        }

        public int Count { 
            get { return count; }
        }

        public void Remove(T item) {
            if (head == null) return;

            if (Equals(head.data, item))
            {
                if (cursor == head) cursor = head.next;
                head = head.next;
                if (head == null) tail = null;
                count--;
                return;
            }

            Node iterator = head;
            while (iterator.next != null)
            {
                if(Equals(iterator.next.data, item))
                {
                    if (tail == iterator.next) tail = iterator;
                    if (cursor == iterator.next) cursor = iterator.next;
                    iterator.next = iterator.next.next;
                    count--;
                    return;
                }
                iterator = iterator.next;
            }
        }

        public T RemoveCurrent()
        {
            if (cursor == null) throw new InvalidOperationException("Невозможно удалить элемент");

            T data = cursor.data;

            if(cursor == head)
            {
                head = head.next;
                cursor = head;
                if (head == null) tail = null;
                count--;
                return data;
            }

            Node iterator = head;
            while (iterator != null && iterator.next != cursor)
            {
                iterator = iterator.next;
            }

            if(iterator != null) {
                iterator.next = cursor.next;
                if (cursor == tail) tail = iterator;
                cursor = cursor.next;
                count--;
            }
            return data;
        }

        public T this[int index] {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Индекс находится вне границ коллекции.");
                }

                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.next;
                }
                return current.data;
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Индекс находится вне границ коллекции.");
                }

                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.next;
                }
                current.data = value;
            } 
        }   
    }
}
