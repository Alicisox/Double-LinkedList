using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_LinkedList
{
    internal class Node
    {
        private int? value;
        private Node next;
        private Node prev;

        public Node()
        {
            this.next = this.prev = null;
            this.value = null;
        }

        public Node(int? value) {
            this.next = this.prev = null;
            this.value  = value;
        }

        public int? Value {
            get { return this.value; }
            set { this.value = value; }
        }

        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public Node Prev
        {
            get { return this.prev; }
            set { this.prev = value; }
        }

    }
}
