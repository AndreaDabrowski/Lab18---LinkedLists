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
        //public Node Previous { set; get; }//add this one for a doubly linked list!!!!!
        public int Index { set; get; }

    }
    class LinkedList
    {
        
        public Node Head { set; get; }
        public Node Tail { set; get; }
        public int Count { set; get; }

        public void AddToEnd(string userInput)
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
                //Tail.Previous = Tail;//changes the previous reference for DOUBLY LINKED LISTS!!!!!!!!!!!!!!!!!!!
                Tail.Next = newNode;//chance the tail next reference
                Tail = newNode; //change the tail
                Count++;

            }
        }
        public bool RemoveAt(int index)
        {
            if (index < 0 || index > Count-1)
            {
                Console.WriteLine("index out of range!");
                return false;
            }
            else if (index == 0)//if its the first node, set the head to the next node
            {
                Head = GetNode(index+1);
                Count--;
                return true;
            }
            else if (index == Count - 1)
            {
                GetNode(index-1).Next = null;//if its the last node in the list, set the previous node's pointer to null
                Count--;
                return true;
            }
            else
            {
                GetNode(index-1).Next = GetNode(index+1);//if anywhere else, set the previous node's pointer to the next node after the removed
                Count--;
                return true;

            }
        }
        public bool AddAt(int index, Node newNode)
        {
            
            if (index < 0 || index > Count)
            {
                Console.WriteLine("index out of range!");
                return false;
            }
            else if (index == 0)
            {
                newNode.Next = GetNode(index);//if its the first node in the list, set the new node to point at the node set at that current index
                Head = newNode;//set head to the new node
                Count++;
                return true;
            }
            else if (index == Count)
            {
                newNode.Next = null;//if the new node is placed at the end of the list, have the new node point to null
                GetNode(index).Next = newNode;//set the previous node to point at the new node
                Count++;
                return true;
            }
            else
            {
                newNode.Next = GetNode(index);//if the new node is in the middle of the list, set the new node to point at the node who's at that current index
                GetNode(index-1).Next = newNode;//then set the previous node in the list to point at the new node
                Count++;
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
            myList.AddToEnd("Steve");
            myList.AddToEnd("Mauricio");
            myList.AddToEnd("Evan");
            myList.AddToEnd("dan");
            myList.AddToEnd("Andrea");


            Console.WriteLine("The items in the Linked List are : ");
            myList.PrintList();
            Console.WriteLine("The Items in the reversed Linked List are: ");
            myList.PrintReverse();
            Console.WriteLine();

            Console.WriteLine("Please enter an index of an element to add a new person to our Linked List: ");
            Node newPerson = new Node();
            newPerson.Data = "New Person!";
            bool isAdded = myList.AddAt(int.Parse(Console.ReadLine()), newPerson);

            Console.WriteLine();
            Console.WriteLine("Our new Linked List is: ");
            myList.PrintList();

            Console.WriteLine();
            Console.WriteLine("Please enter an index to remove a person from our Linked List: ");
            bool isRemoved = myList.RemoveAt(int.Parse(Console.ReadLine()));

            Console.WriteLine();
            Console.WriteLine("Our new Linked List is: ");
            myList.PrintList();
            Console.ReadLine();
        }
    }
    
}
