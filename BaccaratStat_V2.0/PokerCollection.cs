using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaccaratStat_V2._0
{
    public class PokerCollection
    {
        //Banker 4/6的第5张牌，数量1，点数0.
        PokerCard card_Z;
        PokerCard card_A;
        PokerCard card_2;
        PokerCard card_3;
        PokerCard card_4;
        PokerCard card_5;
        PokerCard card_6;
        PokerCard card_7;
        PokerCard card_8;
        PokerCard card_9;
        PokerCard card_10;
        PokerCard card_J;
        PokerCard card_Q;
        PokerCard card_K;

        public PokerCollection(int cardNumber = 32)
        {
            card_A = new PokerCard("A", 1, cardNumber);
            card_2 = new PokerCard("2", 2, cardNumber);
            card_3 = new PokerCard("3", 3, cardNumber);
            card_4 = new PokerCard("4", 4, cardNumber);
            card_5 = new PokerCard("5", 5, cardNumber);
            card_6 = new PokerCard("6", 6, cardNumber);
            card_7 = new PokerCard("7", 7, cardNumber);
            card_8 = new PokerCard("8", 8, cardNumber);
            card_9 = new PokerCard("9", 9, cardNumber);
            card_10 = new PokerCard("10", 0, cardNumber);
            card_J = new PokerCard("J", 0, cardNumber);
            card_Q = new PokerCard("Q", 0, cardNumber);
            card_K = new PokerCard("K", 0, cardNumber);
            card_Z = new PokerCard("Z", 0, 1);
        }
       
        public PokerCard getCard(int index)
        {
            if (index < 1 || index > 14)
            {
                return null;
            }
            switch(index)
            {
                case 1: return Card_A;
                case 2: return Card_2;
                case 3: return Card_3;
                case 4: return Card_4;
                case 5: return Card_5;
                case 6: return Card_6;
                case 7: return Card_7;
                case 8: return Card_8;
                case 9: return Card_9;
                case 10: return Card_10;
                case 11: return Card_J;
                case 12: return Card_Q;
                case 13: return Card_K;
                case 14: return Card_Z;
                default: return null;
            }
        }

        public int getTotalPoint(int cardOneIndex, int cardTwoIndex, int cardThreeIndex)
        {
            int beforeModPoint = getCard(cardOneIndex).CardPoint + getCard(cardTwoIndex).CardPoint + getCard(cardThreeIndex).CardPoint;
            return beforeModPoint % 10;
        }

        public int getTotalPoint(int cardOneIndex, int cardTwoIndex)
        {
            int beforeModPoint = getCard(cardOneIndex).CardPoint + getCard(cardTwoIndex).CardPoint;
            return beforeModPoint % 10;
        }
        
        public int getTotalPoint(int cardOneIndex)
        {
            int beforeModPoint = getCard(cardOneIndex).CardPoint;
            return beforeModPoint % 10;
        }
        
        public PokerCard Card_Z
        {
            get { return this.card_Z; }
        }

        public PokerCard Card_A
        {
            get { return this.card_A; }
        }

        public PokerCard Card_2
        {
            get { return this.card_2; }
        }

        public PokerCard Card_3
        {
            get { return this.card_3; }
        }

        public PokerCard Card_4
        {
            get { return this.card_4; }
        }

        public PokerCard Card_5
        {
            get { return this.card_5; }
        }
        public PokerCard Card_6
        {
            get { return this.card_6; }
        }
        public PokerCard Card_7
        {
            get { return this.card_7; }
        }
        public PokerCard Card_8
        {
            get { return this.card_8; }
        }
        public PokerCard Card_9
        {
            get { return this.card_9; }
        }
        public PokerCard Card_10
        {
            get { return this.card_10; }
        }
        public PokerCard Card_J
        {
            get { return this.card_J; }
        }
        public PokerCard Card_Q
        {
            get { return this.card_Q; }
        }
        public PokerCard Card_K
        {
            get { return this.card_K; }
        }

        public void printCardNumber()
        {
            Console.WriteLine("Card_A::" + Card_A.CardNumber);
            Console.WriteLine("Card_2::" + Card_2.CardNumber);
            Console.WriteLine("Card_3::" + Card_3.CardNumber);
            Console.WriteLine("Card_4::" + Card_4.CardNumber);
            Console.WriteLine("Card_5::" + Card_5.CardNumber);
            Console.WriteLine("Card_6::" + Card_6.CardNumber);
            Console.WriteLine("Card_7::" + Card_7.CardNumber);
            Console.WriteLine("Card_8::" + Card_8.CardNumber);
            Console.WriteLine("Card_9::" + Card_9.CardNumber);
            Console.WriteLine("Card_10::" + Card_10.CardNumber);
            Console.WriteLine("Card_J::" + Card_J.CardNumber);
            Console.WriteLine("Card_Q::" + Card_Q.CardNumber);
            Console.WriteLine("Card_K::" + Card_K.CardNumber);
        }
    }
}
