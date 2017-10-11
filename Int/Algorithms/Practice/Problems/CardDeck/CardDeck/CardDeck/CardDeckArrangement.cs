using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeck
{
    public class CardDeckArrangement
    {
        public void Arrange()
        {
            int numCards = 10;
            StackCards(numCards);
            Console.Read();
        }

        private void StackCards(int numCards)
        {
            Dictionary<int, int?> arr = new Dictionary<int,int?>();

            for (int idx = 0; idx < numCards - 1; idx++)
                arr[idx] = null;

            int count = 1, pos = 1;
            arr[numCards - 1] = (int)(numCards);            

            while (pos < numCards - 1)
            {
                arr[pos] = (int)count++;

                if (pos + count + 1 < numCards - 1)
                    pos = pos + count + 1;
                else
                    break;
            }

            if (numCards - 1 - pos == 1)
                pos = numCards - 1;
            else
                pos++;

            while (count < numCards-1)
            {
                int posCount=0;

                for(int idx = pos; idx <= numCards ; idx++)
                {
                    if (idx == numCards)
                    {
                        idx = 0;
                    }
                    else if (arr[idx] == null || idx == numCards -1)
                    {
                        if (posCount < count)
                            posCount++;
                        else
                        {
                            if (idx == numCards-1)
                            {
                                idx = 0;
                            }
                            else
                            {
                                arr[idx] = (int)count++;
                                break;
                            }
                        }
                    }
                }
            }

            for (int idx = 0; idx < arr.Count; idx++)
            {
                Console.WriteLine(arr[idx].ToString());
            }
        }
    }
}
