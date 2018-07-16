namespace LeetCodeClassLibrary
{
    public class DesignLikedList707
    {
        private class MyNode
        {
            public int Val { get; set; }
            public MyNode Next { get; set; }

            public int Get(int index)
            {
                if (index == 0) return Val;
                else if (Next != null) return Next.Get(index - 1);
                else return -1;
            }

            public void AddAtTail(int val)
            {
                if (Next == null) Next = new MyNode() { Val = val, Next = null };
                else Next.AddAtTail(val);
            }

            public void AddAtIndex(int index, int val)
            {
                if (index == 1)
                {
                    MyNode newNode = new MyNode() { Val = val, Next = Next };
                    Next = newNode;
                }
                else if (Next != null) Next.AddAtIndex(index - 1, val);
                else return;
            }

            public void DeleteAtIndex(int index)
            {
                if (index == 1)
                {
                    if (Next != null)
                    {
                        MyNode Aux = Next;
                        Next = Next.Next;
                        Aux.Next = null;
                    }
                }
                else if (Next != null) Next.DeleteAtIndex(index - 1);
                else return;
            }
        }

        private MyNode Head { get; set; }

        /** Initialize your data structure here. */
        public DesignLikedList707()
        {
            Head = null;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (Head != null) return Head.Get(index);
            else return -1;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            MyNode newHead = new MyNode() { Val = val, Next = Head };
            Head = newHead;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            if (Head == null) AddAtHead(val);
            else Head.AddAtTail(val);
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index == 0) AddAtHead(val);
            else if (Head != null) Head.AddAtIndex(index, val);
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (Head != null)
            {
                if (index == 0) Head = Head.Next;
                else Head.DeleteAtIndex(index);
            }
        }
    }

    /**
     * Your MyLinkedList object will be instantiated and called as such:
     * MyLinkedList obj = new MyLinkedList();
     * int param_1 = obj.Get(index);
     * obj.AddAtHead(val);
     * obj.AddAtTail(val);
     * obj.AddAtIndex(index,val);
     * obj.DeleteAtIndex(index);
     */

}
