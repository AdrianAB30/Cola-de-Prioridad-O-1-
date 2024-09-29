using System;

namespace Cola_de_Prioridad_O_1_
{
    internal class Program
    {
        class PriorityQueue<T>
        {
            class Node
            {
                public T Value { get; set; }
                public int Priority { get; set; }
                public Node Next { get; set; }
                public Node Previous { get; set; }
                public Node(T value, int priority)
                {
                    Value = value;
                    Priority = priority;
                    Next = null;
                    Previous = null;
                }
            }
            private Node Head { get; set; }
            private Node Tail { get; set; }

            public void PriorityEnqueu(T value, int priority)
            {
                Node newNode = new Node(value, priority);
                if (Head == null)
                {
                    Head = newNode;
                    Tail = newNode;
                }
                else if (priority < Head.Priority)
                {
                    newNode.Next = Head;
                    Head.Previous = newNode;
                    Head = newNode;
                }
                else
                {
                    Node current = Head;
                    while (current.Next != null && current.Next.Priority <= priority)
                    {
                        current = current.Next;
                    }
                    newNode.Next = current.Next;
                    newNode.Previous = current;
                    if (current.Next != null)
                    {
                        current.Next.Previous = newNode;
                    }
                    else
                    {
                        Tail = newNode;
                    }
                    current.Next = newNode;
                }
                if (Head != null && priority < Head.Priority)
                {
                    Head = newNode;
                }
            }
            public void PriorityDequeue()
            {
                if (Head == null)
                {
                    throw new NullReferenceException("No se puede hacer eso");
                }
                if (Head == Tail)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Head = Head.Next;
                    Head.Previous = null;
                }

            }
            public void PrintAllData()
            {
                Node tmp = Head;
                while (tmp != null)
                {
                    Console.Write(tmp.Value + "-" + tmp.Priority + " ");
                    tmp = tmp.Next;
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            PriorityQueue<string> priorityQueue = new PriorityQueue<string>();

            priorityQueue.PriorityEnqueu("A", 0);
            priorityQueue.PriorityEnqueu("B", 8);
            priorityQueue.PriorityEnqueu("C", 2);
            priorityQueue.PriorityEnqueu("D", 1);
            priorityQueue.PriorityEnqueu("E", 4);
            priorityQueue.PriorityEnqueu("F", 7);
            priorityQueue.PriorityEnqueu("G", 6);
            priorityQueue.PriorityEnqueu("H", 5);
            priorityQueue.PriorityEnqueu("I", 3);
            priorityQueue.PriorityEnqueu("J", 9);

            priorityQueue.PriorityDequeue();
            priorityQueue.PriorityDequeue();

            priorityQueue.PrintAllData();

            Console.ReadLine();
        }
    }
}
