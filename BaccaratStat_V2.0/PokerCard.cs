using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaccaratStat_V2._0
{
    public class PokerCard
    {
        private string cardName;
        private int cardPoint;
        private int cardNumber;

        public PokerCard(string name, int point, int number)
        {
            this.cardName = name;
            this.cardPoint = point;
            this.cardNumber = number;
        }

        public string CardName
        {
            get { return this.cardName; }
            set { this.cardName = value; }
        }

        public int CardPoint
        {
            get { return this.cardPoint; }
            set { this.cardPoint = value; }
        }

        public int CardNumber
        {
            get { return this.cardNumber; }
            set { this.cardNumber = value; }
        }

        public int increaseNumber(int increaseAmount)
        {
            this.cardNumber = this.cardNumber + increaseAmount;
            return this.cardNumber;
        }

        public int decreaseNumber(int decreaseAmount)
        {
            if (this.cardNumber - decreaseAmount > 0)
            {
                this.cardNumber = this.cardNumber - decreaseAmount;
            }
            else
            {
                this.cardNumber = 0;
            }
            return this.cardNumber;
        }
    }
}
