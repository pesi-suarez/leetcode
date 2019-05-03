using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p855ExamRoomV0
{
    public class Solution
    {
        private int[] Seats;
        private int OccupiedSeats;

        public Solution (int N)
        {
            Seats = new int[N];
            for (int i = 0; i < Seats.Length; i++) //Podría ser que se inicializara a cero al reservar espacio. Podría ser que no.
                Seats[i] = 0;
            OccupiedSeats = 0;
        }

        public int Seat()
        {
            if (OccupiedSeats == 0)
            {
                OccupiedSeats++;
                Seats[0] = 1;
                return 0;
            }

            int biggestGapLength = -1;
            int biggestGapStart = -1;
            int biggestGapEnd = -1;

            int currentGapLength = -1;
            int currentGapStart = -1;
            int currentGapEnd;

            for (int i = 0; i < Seats.Length; i++)
            {
                if (Seats[i] == 1)
                {
                    currentGapEnd = i;
                    currentGapLength = currentGapEnd - currentGapStart;
                    if (currentGapLength > 1 && currentGapLength / 2 > biggestGapLength / 2)
                    {
                        biggestGapStart = currentGapStart;
                        biggestGapEnd = currentGapEnd;
                        biggestGapLength = currentGapLength;
                    }
                    currentGapStart = i;
                    currentGapLength = 0;
                }
                else
                    currentGapLength++;
            }

            return 0;
        }

        public void Leave(int p)
        {

        }
    }

}


