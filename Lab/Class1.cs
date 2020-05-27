using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab
{
    public class tasks
    {
        public class Node
        {
            private int _Value;
            private Node _Next;
            private Node _Prev;
            public int Value
            {
                get { return _Value; }
                set { _Value = value; }
            }
            public Node(int Data)
            {
                this._Value = Data;
            }
            public Node Next
            {
                get { return this._Next; }
                set { this._Next = value; }
            }
            public Node Prev
            {
                get { return this._Prev; }
                set { this._Prev = value; }
            }
        }
        public class Doubly_Linked_List
        {
            private Node First;
            private Node Current;
            private Node Last;
            private int size;

            public Doubly_Linked_List()
            {
                size = 0;
                First = Current = Last = null;
            }

            public Node GetCurrent()
            {
                return Current;
            }

            public Node GetNext()
            {
                return Current.Next;
            }

            public Node GetPrevious()
            {
                return Current.Prev;
            }

            public void Add(int newElement, int index)
            {
                if (index == 0) //если начало
                {
                    Node newNode = new Node(newElement);

                    if (First == null)
                    {
                        First = Last = Current = newNode;
                    }
                    else
                    {
                        newNode.Next = First;
                        First = newNode; //First и newNode указывают на один и тот же объект
                        newNode.Next.Prev = First;
                    }
                    size++;
                }
                else if (index == size) //если конец
                {
                    Node newNode = new Node(newElement);

                    if (First == null)
                    {
                        First = Last = newNode;
                    }
                    else
                    {
                        Last.Next = newNode;
                        newNode.Prev = Last;
                        Last = newNode;
                    }
                    Current = newNode;
                    size++;
                }
                else //иначе ищем элемент с таким индексом
                {
                    int count = 0;
                    Current = First;
                    while (Current != null && count != index)
                    {
                        Current = Current.Next;
                        count++;
                    }
                    Node newNode = new Node(newElement); //создаем объект
                    Current.Prev.Next = newNode;
                    newNode.Prev = Current.Prev;
                    Current.Prev = newNode;
                    newNode.Next = Current;
                    Current = newNode;
                }
            }
        }



        public int Compare(string first_string, string second_string)
        {
            String[] digits1 = first_string.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            String[] digits2 = second_string.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            int Magnitude1 = 0, Magnitude2 = 0;
            for (var i = 0; i < digits1.Length; i++)
            {
                Magnitude1 += Int32.Parse(digits1[i]) * Convert.ToInt32(Math.Pow(10, 2 - i));
            }
            for (var i = 0; i < digits2.Length; i++)
            {
                Magnitude2 += Int32.Parse(digits2[i]) * Convert.ToInt32(Math.Pow(10, 2 - i));
            }
            if (Magnitude1 == Magnitude2) return 0;
            else
            if (Magnitude1 > Magnitude2) return 1;
            else return -1;

        }

        static void Main(string[] args)
        {

        }
    }
}
