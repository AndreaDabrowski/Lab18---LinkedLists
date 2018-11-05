using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab18
{
    class Node
    {
        public string Data//can be any data return type
        {
            set; get;//gets and sets properties as it did before (interchangeable order for get and set btw)
        }
        public Node Next { set; get; }
        public Node Previous { set; get; }//add this one for a doubly linked list!!!!!
        public int Index { set; get; }

    }
    class LinkedList
    {
        
        public Node Head { set; get; }
        public Node Tail { set; get; }
        public int Count { set; get; }

        public void Add(string userInput)
        {
            Node newNode = new Node { Next = null, Data = userInput };//calls default constructor, but then sets these values
            if (Count == 0)//adding for only the first node
            {
                Head = newNode;//you want head and tail to point to first node 
                Tail = newNode;
                Count++;
            }
            else
            {
                Tail.Previous = Tail;//changes the previous reference for DOUBLY LINKED LISTS!!!!!!!!!!!!!!!!!!!
                Tail.Next = newNode;//chance the tail next reference
                Tail = newNode; //change the tail
                Count++;

            }
        }
        public bool RemoveAt(int index)
        {
            LinkedList list = new LinkedList();

            Node nextNode = new Node { };
            index = nextNode.Index;
            if (index < 0 || index > Count)
            {
                Console.WriteLine("index out of range!");
                return false;
            }
            else
            {
                Head.Previous.Index = index;
                Head.Next = null;
                Count--;
                return true;

            }
        }
        public Node GetNode(int index)
        {
            int start = 0;
            Node temp = Head; //mark the start of my search
            while (start != index)
            {
                start += 1;
                temp = temp.Next;
            }
            return temp; //once found, return the node, else return null
        }
        public void PrintList()
        {
            
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(GetNode(i).Data);
            }
        }
        public void PrintReverse()
        {
            for (int i = Count-1; i >= 0; i--)
            {
                Console.WriteLine(GetNode(i).Data);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList myList = new LinkedList();
            myList.Add("Steve");
            myList.Add("Mauricio");
            myList.Add("Evan");
            myList.Add("dan");
            myList.Add("Andrea");


            Console.WriteLine("The items in the Linked List are : ");
            myList.PrintList();
            Console.WriteLine("The Items in the reversed Linked List are: ");
            myList.PrintReverse();
            Console.WriteLine();

            Console.WriteLine("Please enter an index of an element to remove from our Linked List: ");
            bool isRemoved = myList.RemoveAt(int.Parse(Console.ReadLine()));

            Console.WriteLine();
            Console.WriteLine("Our new reversed Linked List is: ");
            myList.PrintReverse();
            

            Console.ReadLine();
        }
    }
    
}
