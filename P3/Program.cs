using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answers57
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.Append(new Node { Value = 5 });
            list.Append(new Node { Value = 3 });
            list.Append(new Node { Value = 8 });
            foreach (int value in list.ToList())
            {
                Console.WriteLine(value); // Output: 3, 5, 8
            }

            Console.WriteLine("Minimum value: {0}", list.GetMinNode().Value); // Output: Minimum value: 3
            Console.WriteLine("Maximum value: {0}", list.GetMaxNode().Value); // Output: Maximum value: 8

            list.Sort();

            
        }
    }
}
