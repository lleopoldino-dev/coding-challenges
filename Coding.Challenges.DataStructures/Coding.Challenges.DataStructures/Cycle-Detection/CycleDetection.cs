namespace Coding.Challenges.DataStructures.Cycle_Detection;

public class CycleDetection
{
    static void Main(string[] args)
    {
        int tests = Convert.ToInt32(Console.ReadLine());

        for (int testsItr = 0; testsItr < tests; testsItr++)
        {
            int index = Convert.ToInt32(Console.ReadLine());

            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                llist.InsertNode(llistItem);
            }

            SinglyLinkedListNode extra = new SinglyLinkedListNode(-1);
            SinglyLinkedListNode temp = llist.head;

            for (int i = 0; i < llistCount; i++)
            {
                if (i == index)
                {
                    extra = temp;
                }

                if (i != llistCount - 1)
                {
                    temp = temp.next;
                }
            }

            temp.next = extra;

            bool result = hasCycle(llist.head);

            Console.WriteLine((result ? 1 : 0));
        }
    }

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }

    static bool hasCycle(SinglyLinkedListNode head)
    {

        if (head == null)
        {
            return false;
        }

        var currentNode = head;
        var visited = new List<SinglyLinkedListNode>();

        var response = false;
        while (currentNode != null)
        {
            if (visited.IndexOf(currentNode.next) >= 0)
            {
                response = true;
                break;
            }

            visited.Add(currentNode);
            currentNode = currentNode.next;
        }

        return response;
    }
}
