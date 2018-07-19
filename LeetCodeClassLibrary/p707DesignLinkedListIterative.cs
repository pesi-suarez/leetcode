using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeClassLibrary
{
    public class p707DesignLinkedListIterative
    {
        private class MyNode
        {
            public int Val;
            public MyNode Next;
        }

        private MyNode Head;

        /** Initialize your data structure here. */
        public p707DesignLinkedListIterative()
        {
            Head = null;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (Head == null) return -1;
            else
            {
                MyNode iterator = Head;
                while (iterator.Next != null)
                {
                    if (index == 0) return iterator.Val;
                    index--;
                    iterator = iterator.Next;
                }
                if (index == 0) return iterator.Val;
                else return -1;
            }
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
            else
            {
                MyNode iterator = Head;
                while (iterator.Next != null)
                    iterator = iterator.Next;
                iterator.Next = new MyNode() { Next = null, Val = val};
            }
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index == 0) AddAtHead(val);
            else if (Head != null)
            {
                MyNode iterator = Head;
                while (iterator.Next != null)
                {
                    if (index==1)
                    {
                        MyNode newNode = new MyNode() { Next = iterator.Next, Val = val };
                        iterator.Next = newNode;
                        return;
                    }
                    index--;
                    iterator = iterator.Next;
                }
                if (index == 1)
                {
                    MyNode newNode = new MyNode() { Next = iterator.Next, Val = val };
                    iterator.Next = newNode;
                    return;
                }
            }
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (Head != null)
            {
                if (index == 0) Head = Head.Next;
                else
                {
                    MyNode iterator = Head;
                    while (iterator.Next != null)
                    {
                        if (index == 1)
                        {
                            iterator.Next = iterator.Next.Next;
                            return;
                        }
                        index--;
                        iterator = iterator.Next;
                    }
                }
            }
        }

    }
}
