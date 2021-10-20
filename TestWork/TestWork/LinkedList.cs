using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWork
{
    public class LinkedList
    {
        public Node head1, head2;
        public class Node
        {
            public int data;
            public Node next;

            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        public Node addTwoLists(Node first, Node second)
        {
            first = Reverse(first);
            second = Reverse(second);
            Node head = null;
            Node curr = null;
            int carry = 0;
            while (first != null && second != null)
            {
                int num = first.data + second.data;
                num = num + carry;
                Node temp = new Node(num % 10);
                if (head == null)
                {
                    head = temp;
                    curr = head;
                }
                else
                {
                    curr.next = temp;
                    curr = curr.next;
                }
                carry = num / 10;
                first = first.next;
                second = second.next;
            }

            while (second != null)
            {
                int num = second.data;
                num = num + carry;
                Node temp = new Node(num % 10);
                curr.next = temp;
                curr = curr.next;
                carry = num / 10;
                second = second.next;
            }

            while (first != null)
            {
                int num = first.data;
                num = num + carry;
                Node temp = new Node(num % 10);
                curr.next = temp;
                curr = curr.next;
                carry = num / 10;
                first = first.next;
            }

            if (carry != 0)
                curr.next = new Node(carry);
            return Reverse(head);
        }

        private Node Reverse(Node head)
        {
            Node curr = head;
            Node prev = null;
            Node next = null;
            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }
    }
}
