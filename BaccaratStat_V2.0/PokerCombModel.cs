using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaccaratStat_V2._0
{
    public class PokerCombModel
    {
       private static int EMPTY_CARD_INDEX = 14;

        public PokerCombModel()
        {
            this.modelPokerCollect = new PokerCollection(1);
            this.initialize();
        }
        PokerCollection modelPokerCollect;

        public PokerCollection ModelPokerCollect
        {
            get { return modelPokerCollect; }
            set { modelPokerCollect = value; }
        }

        private Dictionary<long, PokerCardResult> modelDictionary;

        public Dictionary<long, PokerCardResult> ModelDictionary
        {
            get { return modelDictionary; }
            set { modelDictionary = value; }
        }

        private long generateKey(int playerCard1Index, int bankerCard1Index, int playerCard2Index,
                                    int bankerCard2Index, int playerCard3Index, int bankerCard3Index)
        {
            long convertKey = bankerCard3Index;

            convertKey = convertKey * 100L + playerCard3Index;
            convertKey = convertKey * 100L + bankerCard2Index;
            convertKey = convertKey * 100L + playerCard2Index;
            convertKey = convertKey * 100L + bankerCard1Index;
            convertKey = convertKey * 100L + playerCard1Index;

            return convertKey;
        }

        public int getPlayerCardOneIndex(long convertKey)
        {
            return (int)(convertKey % 100L);
        }
        public int getBankerCardOneIndex(long convertKey)
        {
            return (int)((convertKey / 100L) % 100L);
        }
        public int getPlayerCardTwoIndex(long convertKey)
        {
            return (int)((convertKey / 100L / 100L) % 100L);
        }
        public int getBankerCardTwoIndex(long convertKey)
        {
            return (int)((convertKey / 100L / 100L / 100L) % 100L);
        }
        public int getPlayerCardThreeIndex(long convertKey)
        {
            return (int)((convertKey / 100L / 100L / 100L / 100L ) % 100L);
        }
        public int getBankerCardThreeIndex(long convertKey)
        {
            return (int)((convertKey / 100L / 100L / 100L / 100L / 100L) % 100L);
        }

        public string getCardSequence(long convertKey)
        {
            string sequence = "";

            sequence += "Xian--" + ModelPokerCollect.getCard(getPlayerCardOneIndex(convertKey)).CardName;
            sequence += ",Zhuang--" + ModelPokerCollect.getCard(getBankerCardOneIndex(convertKey)).CardName;
            sequence += ",Xian--" + ModelPokerCollect.getCard(getPlayerCardTwoIndex(convertKey)).CardName;
            sequence += ",Zhuang--" + ModelPokerCollect.getCard(getBankerCardTwoIndex(convertKey)).CardName;
            sequence += "Xian--" + ModelPokerCollect.getCard(getPlayerCardThreeIndex(convertKey)).CardName;
            sequence += ",Zhuang--" + ModelPokerCollect.getCard(getBankerCardThreeIndex(convertKey)).CardName;

            return sequence;
        }

        public PokerCardResult getCardResult(int playerCard1Index, int bankerCard1Index, int playerCard2Index,
                                    int bankerCard2Index, int playerCard3Index, int bankerCard3Index)
        {
            PokerCardResult cardResult = new PokerCardResult();


            int playerTotalPoint = ModelPokerCollect.getTotalPoint(playerCard1Index, playerCard2Index, playerCard3Index);
            int bankerTotalPoint = ModelPokerCollect.getTotalPoint(bankerCard1Index, bankerCard2Index, bankerCard3Index);

            //和局
            if (bankerTotalPoint == playerTotalPoint)
            {
                cardResult.BankerResult = 0;
                cardResult.PlayerResult = 0;
                cardResult.TieResult = 1;
            }
            //庄家赢
            if (bankerTotalPoint > playerTotalPoint)
            {
                cardResult.BankerResult = 1;
                cardResult.PlayerResult = 0;
                cardResult.TieResult = 0;
            }
            //闲家赢
            if (bankerTotalPoint < playerTotalPoint)
            {
                cardResult.BankerResult = 0;
                cardResult.PlayerResult = 1;
                cardResult.TieResult = 0;
            }


            if(playerCard1Index == playerCard2Index || bankerCard1Index == bankerCard2Index)
            {
                //双对
                if (playerCard1Index == playerCard2Index && bankerCard1Index == bankerCard2Index)
                {
                    cardResult.TwoPairResult = 1;
                }
                //单对
                else
                {
                    cardResult.SinglePairResult = 1;
                }
            }

            return cardResult;
        }

        private void addModelDictionary(int playerCard1Index, int bankerCard1Index, int playerCard2Index,
                                    int bankerCard2Index, int playerCard3Index, int bankerCard3Index)
        {
            long convertKey = generateKey(playerCard1Index, bankerCard1Index, playerCard2Index,
                            bankerCard2Index, playerCard3Index, bankerCard3Index);

            PokerCardResult cardResult = getCardResult(playerCard1Index, bankerCard1Index, playerCard2Index,
                                        bankerCard2Index, playerCard3Index, bankerCard3Index);

            if ((cardResult.BankerResult + cardResult.PlayerResult + cardResult.TieResult) != 1)
            {

                Console.WriteLine("Unexepcted CardResult.");
            }
            modelDictionary.Add(convertKey, cardResult);
        }

        public void initialize()
        {
            modelDictionary = new Dictionary<long, PokerCardResult>(10 * 1024 * 1024);

            for (int playerCard1Index = 1; playerCard1Index <= 13; playerCard1Index++)
            {
                for (int bankerCard1Index = 1; bankerCard1Index <= 13; bankerCard1Index++)
                {
                    for (int playerCard2Index = 1; playerCard2Index <= 13; playerCard2Index++)
                    {
                        for (int bankerCard2Index = 1; bankerCard2Index <= 13; bankerCard2Index++)
                        {
                            int playerTwoCardPoint = ModelPokerCollect.getTotalPoint(playerCard1Index, playerCard2Index);
                            int bankerTwoCardPoint = ModelPokerCollect.getTotalPoint(bankerCard1Index, bankerCard2Index);

                            //For test.
                            //addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, EMPTY_CARD_INDEX, EMPTY_CARD_INDEX);
                            //continue;
                            //闲家两张牌0/1/2/3/4/5点
                            if (playerTwoCardPoint <= 5)
                            {
                                //闲家两张牌0/1/2/3/4/5点，庄家两张牌0/1/2点=====>闲家补牌，庄家补牌
                                if (bankerTwoCardPoint <= 2)
                                {
                                    for (int playerCard3Index = 1; playerCard3Index <= 13; playerCard3Index++)
                                    {
                                        for (int bankerCard3Index = 1; bankerCard3Index <= 13; bankerCard3Index++)
                                        {
                                            addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, playerCard3Index, bankerCard3Index);
                                        }
                                    }
                                }
                                //闲家两张牌0/1/2/3/4/5点，庄家两张牌3/4/5/6点====>闲家补牌====>庄家视庄家第三张牌决定是否补牌
                                if (bankerTwoCardPoint >= 3 && bankerTwoCardPoint <= 6)
                                {
                                    for (int playerCard3Index = 1; playerCard3Index <= 13; playerCard3Index++)
                                    {
                                        int playerNo3CardPoint = ModelPokerCollect.getTotalPoint(playerCard3Index);
                                        if (bankerTwoCardPoint == 3)
                                        {
                                            //闲家两张牌0/1/2/3/4/5点，庄家两张牌3点====>闲家第三张牌8点===>庄家无需补牌
                                            if (playerNo3CardPoint == 8)
                                            {
                                                addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, playerCard3Index, EMPTY_CARD_INDEX);
                                            }
                                            //闲家两张牌0/1/2/3/4/5点，庄家两张牌3点====>闲家第三张牌0/1/2/3/4/5/6/7/9点===>庄家补牌
                                            else
                                            {
                                                for (int bankerCard3Index = 1; bankerCard3Index <= 13; bankerCard3Index++)
                                                {
                                                    addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, playerCard3Index, bankerCard3Index);
                                                }
                                            }
                                        }
                                        if (bankerTwoCardPoint == 4)
                                        {
                                            //闲家两张牌0/1/2/3/4/5点，庄家两张牌4点====>闲家第三张牌0/1/8/9点===>庄家无需补牌
                                            if (playerNo3CardPoint == 0 || playerNo3CardPoint == 1
                                                || playerNo3CardPoint == 8 || playerNo3CardPoint == 9)
                                            {
                                                addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, playerCard3Index, EMPTY_CARD_INDEX);
                                            }
                                            //闲家两张牌0/1/2/3/4/5点，庄家两张牌4点====>闲家第三张牌2/3/4/5/6/7点===>庄家补牌
                                            else
                                            {
                                                for (int bankerCard3Index = 1; bankerCard3Index <= 13; bankerCard3Index++)
                                                {
                                                    addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, playerCard3Index, bankerCard3Index);
                                                }
                                            }
                                        }
                                        if (bankerTwoCardPoint == 5)
                                        {
                                            //闲家两张牌0/1/2/3/4/5点，庄家两张牌5点====>闲家第三张牌0/1/2/3/8/9点===>庄家无需补牌
                                            if (playerNo3CardPoint == 0 || playerNo3CardPoint == 1
                                                || playerNo3CardPoint == 2 || playerNo3CardPoint == 3
                                                || playerNo3CardPoint == 8 || playerNo3CardPoint == 9)
                                            {
                                                addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, playerCard3Index, EMPTY_CARD_INDEX);
                                            }
                                            //闲家两张牌0/1/2/3/4/5点，庄家两张牌5点====>闲家第三张牌4/5/6/7点===>庄家补牌
                                            else
                                            {
                                                for (int bankerCard3Index = 1; bankerCard3Index <= 13; bankerCard3Index++)
                                                {
                                                    addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, playerCard3Index, bankerCard3Index);
                                                }
                                            }
                                        }
                                        if (bankerTwoCardPoint == 6)
                                        {
                                            //闲家两张牌0/1/2/3/4/5点，庄家两张牌6点====>闲家第三张牌6/7点===>庄家补牌
                                            if (playerNo3CardPoint == 6 || playerNo3CardPoint == 7)
                                            {
                                                for (int bankerCard3Index = 1; bankerCard3Index <= 13; bankerCard3Index++)
                                                {
                                                    addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, playerCard3Index, bankerCard3Index);
                                                }
                                            }
                                            //闲家两张牌0/1/2/3/4/5点，庄家两张牌6点====>闲家第三张牌0/1/2/3/4/5/8/9点===>庄家无需补牌
                                            else
                                            {
                                                addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, playerCard3Index, EMPTY_CARD_INDEX);
                                            }
                                        }
                                    }
                                }
                                //闲家两张牌0/1/2/3/4/5点，庄家两张牌7点=====>闲家补牌，庄家不补牌
                                if (bankerTwoCardPoint == 7)
                                {
                                    for (int playerCard3Index = 1; playerCard3Index <= 13; playerCard3Index++)
                                    {
                                        addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, playerCard3Index, EMPTY_CARD_INDEX);
                                    }
                                }
                                //闲家两张牌0/1/2/3/4/5点，庄家两张牌8/9点=====>庄家天牌，均不补牌，决出胜负
                                if (bankerTwoCardPoint >= 8)
                                {
                                    addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, EMPTY_CARD_INDEX, EMPTY_CARD_INDEX);
                                }
                            }
                            //闲家两张牌6/7点
                            if (playerTwoCardPoint >= 6 && playerTwoCardPoint <= 7)
                            {
                                //闲家两张牌6/7点，庄家两张牌0/1/2/3/4/5点=====>庄家补牌，闲家不补牌
                                if (bankerTwoCardPoint <= 5)
                                {
                                    for (int bankerCard3Index = 1; bankerCard3Index <= 13; bankerCard3Index++)
                                    {
                                        addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, EMPTY_CARD_INDEX, bankerCard3Index);
                                    }
                                }
                                //闲家两张牌6/7点，庄家两张牌6/7点=====>庄家闲家均无需补牌，决出胜负
                                if (bankerTwoCardPoint >= 6 && bankerTwoCardPoint <= 7)
                                {
                                    addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, EMPTY_CARD_INDEX, EMPTY_CARD_INDEX);
                                }
                                //闲家两张牌6/7点，庄家两张牌8/9点=====>庄家天牌，决出胜负
                                if (bankerTwoCardPoint >= 8)
                                {
                                    addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, EMPTY_CARD_INDEX, EMPTY_CARD_INDEX);
                                }
                            }
                            //闲家两张牌8/9点====>闲家天牌，决出胜负
                            if (playerTwoCardPoint >= 8)
                            {
                                addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, EMPTY_CARD_INDEX, EMPTY_CARD_INDEX);
                            }
                        }
                    }
                }　
            }
        }
    }
}

