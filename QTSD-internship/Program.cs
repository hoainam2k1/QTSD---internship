using System;
using System.Collections.Generic;
using System.Text;

namespace QTSD_internship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  1 OOP
            Person person = new Person();
            person.Name = "Nguyen Hoai Nam";
            person.Age = 21;
            person.Address = "Tra Vinh";
            person.Display();

            Student student = new Student();
            student.Name = "Nguyen Hoai Viet";
            student.Age = 19;
            student.Address = "Tra Vinh";
            student.ID = "110119029";
            student.Class = "DA19TTA";
            student.Display();

            //  2 Linked List
            //The linked list values:
            //the fox jumps over the dog
            string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> list = new LinkedList<string>(words);
            Display(list, "The linked list value:");

            Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
            list.Contains("jumps"));

            //Test 1: Add 'today' to beginning of the list:
            //today the fox jumps over the dog
            list.AddFirst("Today");
            Display(list, "Test 1: Add 'today' to beginning of the list:");

            //Test 2: Move first node to be last node:
            //the fox jumps over the dog today
            LinkedListNode<string> Node = list.First;
            list.RemoveFirst();
            list.AddLast(Node);
            Display(list, "Test 2: Move the first node to be last node:");

            //Test 3: Change the last node to 'yesterday':
            //the fox jumps over the dog yesterday
            list.RemoveLast();
            list.AddLast("Yesterday");
            Display(list, "Test 3: Change the last node to 'yesterday':");

            //Test 4: Move last node to be first node:
            //yesterday the fox jumps over the dog
            Node = list.Last;
            list.RemoveLast();
            list.AddFirst(Node);
            Display(list, "Test 4: Move last node to be first node:");

            //Test 5: Indicate last occurence of 'the':
            //the fox jumps over (the) dog
            list.RemoveFirst();
            LinkedListNode<string> currentNode = list.FindLast("the");
            IndicateNode(currentNode, "Test 5: Indicate last occurence of 'the':");

            //Test 6: Add 'lazy' and 'old' after 'the':
            //the fox jumps over (the) lazy old dog
            list.AddAfter(currentNode, "old");
            list.AddAfter(currentNode, "lazy");
            IndicateNode(currentNode, "Test 6: Add 'lazy' and 'old' after 'the':");

            //Test 7: Indicate the 'fox' node:
            //the (fox) jumps over the lazy old dog
            currentNode = list.Find("fox");
            IndicateNode(currentNode, "Test 7: Indicate the 'fox' node:");

            //Test 8: Add 'quick' and 'brown' before 'fox':
            //the quick brown (fox) jumps over the lazy old dog
            list.AddBefore(currentNode, "quick");
            list.AddBefore(currentNode, "brown");
            IndicateNode(currentNode, "Test 8: Add 'quick' and 'brown' before 'fox':");

            //Test 9: Indicate the 'dog' node:
            //the quick brown fox jumps over the lazy old (dog)
            Node = currentNode;
            LinkedListNode<string> Node2 = currentNode.Previous;
            currentNode = list.Find("dog");
            IndicateNode(currentNode, "Test 9: Indicate the 'dog' node:");

            //Test 10: Throw exception by adding node (fox) already in the list:
            //Exception message: The LinkedList node belongs a LinkedList.


            Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
            try
            {
                list.AddBefore(currentNode, Node);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Exception message: {0}", ex.Message);
            }
            Console.WriteLine();

            //Test 11: Move a referenced node (fox) before the current node (dog):
            //the quick brown jumps over the lazy old fox (dog)
            list.Remove(Node);
            list.AddBefore(currentNode, Node);
            IndicateNode(currentNode, "Test 11: Move a referenced node (fox) before the current node (dog):");

            //Test 12: Remove current node (dog) and attempt to indicate it:
            //Node 'dog' is not in the list.
            list.Remove(currentNode);
            IndicateNode(currentNode, "Test 12: Remove current node (dog) and attempt to indicate it:");

            //Test 13: Add node removed in test 11 after a referenced node (brown):
            //the quick brown (dog) jumps over the lazy old fox
            list.AddAfter(Node2, currentNode);
            IndicateNode(currentNode, "Test 13: Add node removed in test 11 after a referenced node (brown):");

            //Test 14: Remove node that has the value 'old':
            //the quick brown dog jumps over the lazy fox
            list.Remove("old");
            Display(list, "Test 14: Remove node that has the value 'old':");

            //Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':
            //the quick brown dog jumps over the lazy rhinoceros
            list.RemoveLast();
            ICollection<string> icoll = list;
            icoll.Add("rhinoceros");
            Display(list, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

            //Test 16: Copy the list to an array:
            //the
            //quick
            //brown
            //dog
            //jumps
            //over
            //the
            //lazy
            //rhinoceros
            Console.WriteLine("Test 16: Copy the list to an array:");
            string[] sArray = new string[list.Count];
            list.CopyTo(sArray, 0);

            foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }
            //Test 17: Clear linked list. Contains 'jumps' = False
            //
            list.Clear();

            Console.WriteLine();
            Console.WriteLine("Test 17: Clear linked list. Contains 'jumps' = {0}", list.Contains("jumps"));
            Console.ReadLine();
        }
        private static void Display(LinkedList<string> words, string test)
        {
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void IndicateNode(LinkedListNode<string> node, string test)
        {
            Console.WriteLine(test);
            if (node.List == null)
            {
                Console.WriteLine("Node '{0}' is not in the list.\n",
                    node.Value);
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkedListNode<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}
