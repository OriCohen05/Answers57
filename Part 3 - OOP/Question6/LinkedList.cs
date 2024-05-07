using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answers57
{
    /// <summary>
    /*
     LinkedList Class

    This class implements a linked list with functionality to add and remove elements, access minimum and maximum values, check for circular references, and sort the list.

    Private Members:

    head: The first node in the list.
    tail: The last node in the list.
    minValue: The minimum value stored in the list, nullable to handle empty lists.
    maxValue: The maximum value stored in the list, nullable to handle empty lists.

    Notes:

    The Node class is assumed to exist and contain a Value property and a Next property referencing the next node in the list.
    Methods like UpdateMinMaxNodes, Append, Prepend, Pop, Unqueue, and Sort update the minValue and maxValue properties as needed.
     */
    /// </summary>

    public class LinkedList
    {
        private Node head { get; set; }
        private Node tail = new Node();
        private int? minValue; // nullable to handle empty list
        private int? maxValue;

        /// <summary>
        /// Calculates the minimum and maximum values within the list.
        /// </summary>
        public void UpdateMinMaxNodes()
        {
            if (head == null)
            {
                minValue = null;
                maxValue = null;
                return;
            }

            minValue = head.Value;
            maxValue = head.Value;
            Node current = head.Next;
            while (current != null)
            {
                if (current.Value < minValue)
                {
                    minValue = current.Value;
                }
                if (current.Value > maxValue)
                {
                    maxValue = current.Value;
                }
                current = current.Next;
            }
        }
        /// <summary>
        /// Appends a new node to the end of the list.
        /// </summary>
        /// <param name="node">The node to be appended</param>
        public void Append(Node node)
        {
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            if (minValue == null || node.Value < minValue)
            {
                minValue = node.Value;
            }
            if (maxValue == null || node.Value > maxValue)
            {
                maxValue = node.Value;
            }
        }
        /// <summary>
        /// Prepends a new node with the specified value to the beginning of the list.
        /// </summary>
        /// <param name="val">The value to be prepended</param>
        public void Prepend(int val)
        {
            Node node = new Node();
            node.Value = val;
            node.Next = head;
            head = node;
            UpdateMinMaxNodes(); 
        }
        /// <summary>
        /// Removes and returns the last node from the list. Returns null if the list in empty
        /// </summary>
        /// <returns>Node object of the popped node</returns>
        public Node Pop()
        {
            if (head == null)
            {
                return null;
            }

            Node secondLast = head;
            while (secondLast.Next != tail)
            {
                secondLast = secondLast.Next;
            }

            Node pop = tail;
            tail = secondLast;
            tail.Next = null;

            UpdateMinMaxNodes(); 
            return pop;
        }
        /// <summary>
        /// Removes and returns the value of the first node from the list. Throws an exception if the list is empty.
        /// </summary>
        /// <returns>The value of the first node from the list</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int Unqueue()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            Node headNode = head;
            head = head.Next;

            UpdateMinMaxNodes(); 
            return headNode.Value;
        }
        /// <summary>
        /// Returns an IEnumerable containing the values of the nodes in the list.
        /// </summary>
        /// <returns>Iterator of the list values</returns>
        public IEnumerable<int> ToList()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        /// <summary>
        /// Checks if the list contains a circular reference.
        /// </summary>
        /// <returns>True if contains, else false</returns>
        private bool IsCircular()
        {
            if (head == null || head == tail)
            {
                return false;
            }

            Node slow = head;
            Node fast = head.Next;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Sorts the elements of the list in ascending order.
        /// Inser
        /// </summary>
        public void Sort()
        {
            if (head == null || head.Next == null)
            {
                return;
            }

            Node sorted = null;
            Node current = head;

            while (current != null)
            {
                Node next = current.Next;

                Node insertAfter = null;
                Node sortedNode = sorted;
                while (sortedNode != null && sortedNode.Value <= current.Value)
                {
                    insertAfter = sortedNode;
                    sortedNode = sortedNode.Next;
                }

                if (insertAfter == null)
                {
                    current.Next = sorted;
                    sorted = current;
                }
                else
                {
                    current.Next = insertAfter.Next;
                    insertAfter.Next = current;
                }

                current = next;
            }

            head = sorted;
            UpdateMinMaxNodes();
        }
        /// <summary>
        /// Returns the node containing the maximum value in the list, or null if the list is empty.
        /// </summary>
        public Node GetMaxNode()
        {
            if (head == null)
            {
                return null;
            }

            if (maxValue == null)
            {
                UpdateMinMaxNodes();
            }

            return maxValue.HasValue ? FindNodeByValue(maxValue.Value) : null;
        }
        /// <summary>
        /// Returns the node containing the minimum value in the list, or null if the list is empty.
        /// </summary>
        public Node GetMinNode()
        {
            if (head == null)
            {
                return null;
            }

            if (minValue == null)
            {
                UpdateMinMaxNodes();
            }

            return minValue.HasValue ? FindNodeByValue(minValue.Value) : null;
        }

        private Node FindNodeByValue(int value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Value == value)
                {
                    return current;
                }
                current = current.Next;
            }
            return null; 
        }
    }

}
