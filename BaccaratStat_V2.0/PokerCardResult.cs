using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaccaratStat_V2._0
{
    public class PokerCardResult
    {
        private int bankerResult;

        public int BankerResult
        {
            get { return bankerResult; }
            set { bankerResult = value; }
        }
        private int playerResult;

        public int PlayerResult
        {
            get { return playerResult; }
            set { playerResult = value; }
        }
        private int tieResult;

        public int TieResult
        {
            get { return tieResult; }
            set { tieResult = value; }
        }
        private int singlePairResult;

        public int SinglePairResult
        {
            get { return singlePairResult; }
            set { singlePairResult = value; }
        }

        private int twoPairResult;

        public int TwoPairResult
        {
            get { return twoPairResult; }
            set { twoPairResult = value; }
        }

        public string ToString()
        {
            string result = "";
            result = "Banker::" + BankerResult + ",Player::" + PlayerResult + ",Tie::" + TieResult;
            return result;
        }
    }
}
