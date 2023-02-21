using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_LinkedList
{
    internal class LinkedList : Node
    {
        private Node head; // Point to the front of the list
        private Node tail; // Point to the end of the list
        private int length;

        public int Length {
            get { return this.length; }
        }

        public LinkedList() {
            this.head = this.tail = null;
            this.length = 0;
        }

        /// <summary>
        /// Return a value in the list by given index.
        /// </summary>
        /// <param>
        /// <c>index</c> is the index of value.
        /// </param>
        /// <returns>
        /// The int value.
        /// </returns>
        public int? GetValue(int index) {
            if (index > length - 1 ||  length == 0) return -1;
            if (this.length == 1) return this.head.Value;
            Node current = this.head;
            int num = 0;
            while (current != null)
            {
                if (num == index) 
                {
                    return current.Value;
                }
                num++;
                current = current.Next;
            }
            return -1;
        }

        /// <summary>
        /// Set value in the list by given index and value.
        /// </summary>
        /// <param>
        /// <c>value</c> is the value to be set.
        /// <c>index</c> is the index of the value.
        /// </param>
        public void SetValue(int value,int index) {
            if (index > this.length - 1 || this.length == 0) return;
            if (this.length == 1) this.head.Value = value;
            Node current = this.head;
            int num = 0;
            while (current != null)
            {
                if (num == index)
                {
                    current.Value = value;
                }
                num++;
                current = current.Next;
            }
            
        }

        /// <summary>
        /// Print all values of the list.
        /// </summary>
        public void Traverse()
        {
            if (this.length == 0) return;
            Node current = this.head;
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        /// <summary>
        /// Search the node that contains given value.
        /// </summary>
        /// <param>
        /// <c>value</c> is number to find the node.
        /// </param>
        /// <returns>
        /// The node of given number.
        /// </returns>
        public Node Search(int? value) // Return Node if value is found
        {
            if (this.length == 0)
            {
                return null;
            }
            Node current = this.head;
            while (current != null)
            {
                if (current.Value == value)
                {
                    return current;
                }
                current = current.Next; // next node
            }
            return null;
        }

        /// <summary>
        /// Insert an element at the end of the list.
        /// </summary>
        /// <param>
        /// <c>value</c> is value to be inserted.
        /// </param>
        public void Append(int? value) // or Push
        {
            if (this.length == 0) //No element
            {
                this.head = this.tail = new Node(value);
            }
            else
            {
                // Use tail for conveninet 
                this.tail.Next = new Node(value);
                this.tail.Next.Prev = this.tail;
                this.tail = this.tail.Next;
            }
            this.length++;
        }

        /// <summary>
        /// Insert an element at the front of the list.
        /// </summary>
        /// <param>
        /// <c>value</c> is value to be inserted.
        /// </param>
        public void Prepend(int? value) 
        {
            if (this.length == 0) // No element
            {
                this.head = this.tail = new Node(value);
            }
            else{
                this.head.Prev = new Node(value);
                this.head.Prev.Next = this.head; 
                this.head = this.head.Prev;
            }
            this.length++;
        }

        /// <summary>
        /// Insert an element by given index.
        /// </summary>
        /// <param>
        /// <c>value</c> is value to be inserted.
        /// <c>index</c> is position to be inserted.
        /// </param>
        public void Insert(int? value, int index)
        {
            if (index > this.length - 1) return;
            Node current = this.head;
            int num = 0;
            while (current != null)
            {
                if (num == index)
                {
                    if (current.Prev == null && current.Next == null) // No element
                    {
                        this.head.Next = this.tail = new Node(value);
                        this.tail.Prev = this.head;
                    }
                    else if (current.Next == null) // End
                    {
                        current.Next = this.tail = new Node(value); // Intialize and set next ptv to new Node
                        current.Next.Prev = current; // Set prev ptv to new Node
                    }
                    else // Middle
                    {
                        current.Next.Prev = new Node(value);
                        current.Next.Prev.Next = current.Next;
                        current.Next.Prev.Prev = current;
                        current.Next = current.Next.Prev;
                    }
                    this.length++;
                    return;
                }
                num++;
                current = current.Next;
            }
            Console.WriteLine("Out of range!");
        }

        /// <summary>
        /// Remove an element at the end of the list.
        /// </summary>
        /// <returns>
        /// The bool, if it successfully removes return true else false.
        /// </returns>
        public bool Pop() // Delate last
        {
            if (this.length == 0) // No element
            {
                return false;
            }
            else // End 
            {
                this.tail.Prev.Next = null;
                Console.WriteLine("Popped {0}!", this.tail.Value);
                this.tail = this.tail.Prev;
                this.length--;
                return true;
            }
        }

        /// <summary>
        /// Remove an element at the front of the list.
        /// </summary>
        /// <returns>
        /// The bool, if it successfully removes return true else false.
        /// </returns>
        public bool Remove() {
            if (this.length == 0) // No element
            {
                return false;
            }
            else
            {
                this.head.Next.Prev = null;
                Console.WriteLine("Removed {0}!", this.head.Value);
                this.head = this.head.Next;
                this.length--;
                return true;
            }
        }

        /// <summary>
        /// Remove an element by given value.
        /// </summary>
        /// <param>
        /// <c>value</c> is value to be removed.
        /// </param>
        /// <returns>
        /// The bool, if it successfully removes return true else false.
        /// </returns>
        public bool Remove(int? value)
        {
            if (this.length == 0) // No element
            {
                return false;
            }
            else
            {
                Node current = Search(value);
                if (current != null)
                {
                    if (current.Prev == null && current.Next == null) // Begin
                    {
                        this.head = this.tail = null;
                    }
                    else if (current.Prev == null) // Begin
                    {
                        this.head = current.Next;
                        current.Next.Prev = this.head;
                    }
                    else if (current.Next == null) // End
                    {
                        current.Prev.Next = null;
                        this.tail = current.Prev;
                    }
                    else // Middle
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    Console.WriteLine("Removed {0}!", value);
                    this.length--;
                    return true;
                }
                return false;
            }
        }

    }
}