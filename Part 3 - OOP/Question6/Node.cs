using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answers57
{
    /*Node Class

    This class represents a single node within a singly linked list.

    Public Members:

    Value: The data stored within the node.
    Next: A reference to the next node in the list, or null if this is the last node.
    HasNext(): Returns a boolean indicating whether there is a next node in the list.

    Notes:

    This class is typically used internally by the LinkedList class.
    */
    public class Node
    {
        public int Value {  get; set; }
        public Node Next { get; set; }

        public bool HasNext()
        {
            return this.Next != null;
        }
    }
}
