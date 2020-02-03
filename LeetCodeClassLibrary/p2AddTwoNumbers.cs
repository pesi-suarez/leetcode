using System.Text;

namespace p2AddTwoNumbers
{
    //NOTA: No incluir la clase ListNode en el código que se envía.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode() { }
        public ListNode(int x) { val = x; }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            ListNode iterator = this;
            while (iterator != null)
            {
                builder.Append(iterator.val.ToString());
                iterator = iterator.next;
            }
            return builder.ToString();
        }
    }

    /* NOTA: 
     * Tardé unos 30 minutos en resolver el problema con la solución más simple (lineal).
     * Me equivoqué una vez porque no tuve en cuenta el carry final
     * Me dice que es más rápido que el 89,67% de los envíos y ocupa menos espacio que el 9,09% de los envíos.
     */
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode((l1.val + l2.val) % 10);
            int carry = (l1.val + l2.val) / 10;

            ListNode l1Pointer = l1.next;
            ListNode l2Pointer = l2.next;
            ListNode resultPointer = result;

            while(l1Pointer != null && l2Pointer != null)
            {
                ListNode nextDigit = new ListNode((l1Pointer.val + l2Pointer.val + carry) % 10);
                carry = (l1Pointer.val + l2Pointer.val + carry) / 10;
                resultPointer.next = nextDigit;

                l1Pointer = l1Pointer.next;
                l2Pointer = l2Pointer.next;
                resultPointer = nextDigit;
            }

            while (l1Pointer != null)
            {
                ListNode nextDigit = new ListNode((l1Pointer.val + carry) % 10);
                carry = (l1Pointer.val + carry) / 10;
                resultPointer.next = nextDigit;

                l1Pointer = l1Pointer.next;
                resultPointer = nextDigit;
            }

            while (l2Pointer != null)
            {
                ListNode nextDigit = new ListNode((l2Pointer.val + carry) % 10);
                carry = (l2Pointer.val + carry) / 10;
                resultPointer.next = nextDigit;

                l2Pointer = l2Pointer.next;
                resultPointer = nextDigit;
            }

            if (carry != 0)
            {
                ListNode nextDigit = new ListNode(carry);
                resultPointer.next = nextDigit;
            }

            return result;
        }

    }
}
