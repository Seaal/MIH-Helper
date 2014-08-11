using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    public class BalanceResult
    {
        private List<Tuple<int, int>> swaps;

        public BalanceResult()
        {
            swaps = new List<Tuple<int, int>>(5);
        }

        public void AddSwap(int swap1, int swap2)
        {
            if(swap1 < 0 || swap1 > 4)
            {
                throw new ArgumentException("Swap1 has to be between 0 and 4 (On the blue team)");
            }

            if(swap2 < 5 || swap2 > 9)
            {
                throw new ArgumentException("Swap2 has to be between 5 and 9 (On the purple team)");
            }

            swaps.Add(new Tuple<int, int>(swap1, swap2));
        }

        public List<Tuple<int, int>> GetSwaps()
        {
            return swaps;
        }
    }
}
