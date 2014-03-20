using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaccaratStat_V2._0
{
    public class ProbabilityResult
    {
        public ProbabilityResult()
        {
        }

        public void reset()
        {
            bankerWinAmount = 0L;
            playerWinAmount = 0L;
            bothTieAmount = 0L;
        }

        long bankerWinAmount;

        public long BankerWinAmount
        {
            get { return bankerWinAmount; }
            set { bankerWinAmount = value; }
        }
        long playerWinAmount;

        public long PlayerWinAmount
        {
            get { return playerWinAmount; }
            set { playerWinAmount = value; }
        }
        long bothTieAmount;

        public long BothTieAmount
        {
            get { return bothTieAmount; }
            set { bothTieAmount = value; }
        }

        long totalCombAmount;

        public long TotalCombAmount
        {
            get { return totalCombAmount; }
            set { totalCombAmount = value; }
        }

        long singlePairAmount;

        public long SinglePairAmount
        {
            get { return singlePairAmount; }
            set { singlePairAmount = value; }
        }

        long twoPairAmount;

        public long TwoPairAmount
        {
            get { return twoPairAmount; }
            set { twoPairAmount = value; }
        }

    }
}


