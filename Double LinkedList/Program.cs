using System;
using System.ComponentModel;

namespace Double_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList doubleLinkedList = new LinkedList();
            doubleLinkedList.Append(1);
            doubleLinkedList.Append(3);
            doubleLinkedList.Append(4);
            doubleLinkedList.Append(2);
            doubleLinkedList.Traverse();
            doubleLinkedList.Remove(3);
            doubleLinkedList.Pop();
            doubleLinkedList.Remove();
            /*doubleLinkedList.Traverse();
            doubleLinkedList.Insert(3, 0);
            doubleLinkedList.Traverse();
            doubleLinkedList.Insert(2, 0);
            doubleLinkedList.Insert(5, 14);*/
            doubleLinkedList.Traverse();
            Console.WriteLine("Length: {0}", doubleLinkedList.Length);

        }

    }
}
