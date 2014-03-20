using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using BaccaratStat_V2._0;
using System.Threading;

namespace TestApp
{
    class Program
    {
        static void MarkMain(string[] args)
        {
            int pokerNum = 32;
            ProbabilityCalculator calculator = new ProbabilityCalculator();
            Console.WriteLine(string.Format("{0:s}", DateTime.Now));
            PokerCollection pokerCollect = new PokerCollection(pokerNum);
            ProbabilityResult result = calculator.calculateProbabil(pokerCollect);

            long maxComp = (13L * pokerNum) * (13L * pokerNum - 1) * (13L * pokerNum - 2)
                    * (13L * pokerNum - 3) * (13L * pokerNum - 4) * (13L * pokerNum - 5);
            Console.WriteLine("Expect Number::" + maxComp);
            Console.WriteLine("Player Win Amount::" + result.PlayerWinAmount);
            Console.WriteLine("Banker Win Amount::" +  result.BankerWinAmount);
            Console.WriteLine("Both tie Amount::" +  result.BothTieAmount);
            double totalPairRate = ((result.SinglePairAmount + result.TwoPairAmount) * 1.0 / result.TotalCombAmount);
            Console.WriteLine("Single Pair Amount ::" + (result.SinglePairAmount * 1.0 / result.TotalCombAmount));
            Console.WriteLine("Two Pair Amount ::" + (result.TwoPairAmount * 1.0 / result.TotalCombAmount));
            Console.WriteLine("Total Pair Amount ::" + totalPairRate);
            double bankerWinRate = (result.BankerWinAmount * 1.0 / result.TotalCombAmount) * 100.0;
            double playerWinRate = (result.PlayerWinAmount * 1.0 / result.TotalCombAmount) * 100.0;
            double bothTieRate = (result.BothTieAmount * 1.0 / result.TotalCombAmount) * 100.0;
            Console.WriteLine("Player Win Rate ::" + playerWinRate);
            Console.WriteLine("Banker Win Rate ::" + bankerWinRate);
            Console.WriteLine("Tie hand Rate ::" + bothTieRate);

            Console.ReadLine();
        }

        public static void multiTaskCalculate()
        {
            Int32 sumNum = 0;
            Task parent = new Task(() =>
            {
                var cts = new CancellationTokenSource();
                var tf = new TaskFactory<Int32>(cts.Token, TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

                //创建并启动3个子任务
                var childTasks = new[] {
            tf.StartNew(() => Sum(cts.Token, 10000, "234")),
            tf.StartNew(() => Sum(cts.Token, 20000, "9772")),
            tf.StartNew(() => Sum(cts.Token, 30000, "1772"))  // 这个会抛异常
         };

                // 任何子任务抛出异常就取消其余子任务
                for (Int32 task = 0; task < childTasks.Length; task++)
                    childTasks[task].ContinueWith(t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);

                // 所有子任务完成后，从未出错/未取消的任务获取返回的最大值
                // 然后将最大值传给另一个任务来显示最大结果
                tf.ContinueWhenAll(childTasks,
                   completedTasks => completedTasks.Where(t => !t.IsFaulted && !t.IsCanceled).Max(t => t.Result),
                   CancellationToken.None)
                   .ContinueWith(t => Console.WriteLine("The maxinum is: " + t.Result),
                      TaskContinuationOptions.ExecuteSynchronously).Wait(); // Wait用于测试
            });

            // 子任务完成后，也显示任何未处理的异常
            parent.ContinueWith(p =>
            {
                // 用StringBuilder输出所有

                StringBuilder sb = new StringBuilder("The following exception(s) occurred:" + Environment.NewLine);
                foreach (var e in p.Exception.Flatten().InnerExceptions)
                    sb.AppendLine("   " + e.GetType().ToString());
                Console.WriteLine(sb.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted);

            // 启动父任务
            parent.Start();

            try
            {
                parent.Wait(); //显示结果
            }
            catch (AggregateException)
            {
            }
        }

        private static int circleCal(int idx)
        {
            int sum = 0;
            for(int i = 0; i < idx; i++)
                sum += i;
            return sum;
        }


        private static Int32 Sum(CancellationToken ct, Int32 n, string addNum)
        {
            Int32 sum = n;
            sum += Int32.Parse(addNum.Trim());
            return sum;
        }

        public static void randCalculate()
        {
            ProbabilityCalculator calculator = new ProbabilityCalculator();
            PokerCollection pokerCollection = calculator.PokerModel.ModelPokerCollect;
            PokerCombModel pokerModel = calculator.PokerModel;

            int pokerNum = 8;
            bool[] takenStats = new bool[pokerNum * 13];

            long playerWinTimes = 0L;
            long bankerWinTimes = 0L;
            long bothTieTimes = 0L;

            long resultTimes = 0L;
            long totalCircleTimes = 48888888;
            for (int circleIndex = 0; circleIndex < totalCircleTimes; circleIndex++)
            {

                Random rand = new Random();
                for (int takenIndex = 0; takenIndex < takenStats.Length; takenIndex++)
                {
                    takenStats[takenIndex] = false;
                }

                int playerCardOneIndex = -1, playerCardTwoIndex = -1, playerCardThreeIndex = -1;
                int bankerCardOneIndex = -1, bankerCardTwoIndex = -1, bankerCardThreeIndex = -1;

                int index = 0;
                while (true)
                {
                    index = rand.Next(pokerNum * 13);
                    if (!takenStats[index])
                    {
                        takenStats[index] = true;
                        playerCardOneIndex = index % 13 + 1;
                        break;
                    }
                }
                while (true)
                {
                    index = rand.Next(pokerNum * 13);
                    if (!takenStats[index])
                    {
                        takenStats[index] = true;
                        bankerCardOneIndex = index % 13 + 1;
                        break;
                    }
                }
                while (true)
                {
                    index = rand.Next(pokerNum * 13);
                    if (!takenStats[index])
                    {
                        takenStats[index] = true;
                        playerCardTwoIndex = index % 13 + 1;
                        break;
                    }
                }
                while (true)
                {
                    index = rand.Next(pokerNum * 13);
                    if (!takenStats[index])
                    {
                        takenStats[index] = true;
                        bankerCardTwoIndex = index % 13 + 1;
                        break;
                    }
                }
                int playerTwoCardPoint = pokerCollection.getTotalPoint(playerCardOneIndex % 13 + 1, playerCardTwoIndex % 13 + 1);
                int bankerTwoCardPoint = pokerCollection.getTotalPoint(bankerCardOneIndex % 13 + 1, bankerCardTwoIndex % 13 + 1);
                PokerCardResult result = null;
                //For test.
                //addModelDictionary(playerCard1Index, bankerCard1Index, playerCard2Index, bankerCard2Index, EMPTY_CARD_INDEX, EMPTY_CARD_INDEX);
                //continue;


                //闲家两张牌大于等于6点，闲家无需补牌
                if (playerTwoCardPoint >= 6)
                {
                    //闲家两张牌大于等于6点，庄家两张牌小于6点，庄家补牌
                    if (bankerTwoCardPoint < 6)
                    {
                        playerCardThreeIndex = 14;

                        while (true)
                        {
                            index = rand.Next(pokerNum * 13);
                            if (!takenStats[index])
                            {
                                takenStats[index] = true;
                                bankerCardThreeIndex = index % 13 + 1;
                                break;
                            }
                        }
                    }
                    //闲家两张牌大于等于6点，庄家两张牌大于等于6点，庄家无需补牌
                    else
                    {
                        playerCardThreeIndex = 14;
                        bankerCardThreeIndex = 14;
                    }

                }
                //闲家两张牌小于6点，闲家需要补牌
                else
                {
                    while (true)
                    {
                        index = rand.Next(pokerNum * 13);
                        if (!takenStats[index])
                        {
                            takenStats[index] = true;
                            playerCardThreeIndex = index % 13 + 1;
                            break;
                        }
                    }

                    int playerThreeCardPoint = pokerCollection.getTotalPoint(playerCardOneIndex, playerCardTwoIndex, playerCardThreeIndex);
                    //闲家补三张牌后，庄家两张牌小于3点，庄家补牌
                    if (bankerTwoCardPoint < 3)
                    {
                        while (true)
                        {
                            index = rand.Next(pokerNum * 13);
                            if (!takenStats[index])
                            {
                                takenStats[index] = true;
                                bankerCardThreeIndex = index % 13 + 1;
                                break;
                            }
                        }
                    }
                    //闲家补三张牌后，庄家两张牌等于3点
                    if (bankerTwoCardPoint == 3)
                    {
                        //闲家三张牌等于8点，庄家两张牌等于3点，庄家无需补牌
                        if (playerThreeCardPoint == 8)
                        {
                            bankerCardThreeIndex = 14;
                        }
                        //闲家三张牌不等于8点，庄家两张牌等于3点，庄家补牌
                        else
                        {
                            while (true)
                            {
                                index = rand.Next(pokerNum * 13);
                                if (!takenStats[index])
                                {
                                    takenStats[index] = true;
                                    bankerCardThreeIndex = index % 13 + 1;
                                    break;
                                }
                            }
                        }
                    }
                    //闲家补三张牌后，庄家两张牌等于4点
                    if (bankerTwoCardPoint == 4)
                    {
                        //闲家三张牌等在0/1/8/9点中，庄家两张牌等于4点，庄家无需补牌
                        if (playerThreeCardPoint == 0 || playerThreeCardPoint == 1 ||
                            playerThreeCardPoint == 8 || playerThreeCardPoint == 9)
                        {
                            bankerCardThreeIndex = 14;
                        }
                        //闲家三张牌等不在0/1/8/9点中，庄家两张牌等于4点，庄家补牌
                        else
                        {
                            while (true)
                            {
                                index = rand.Next(pokerNum * 13);
                                if (!takenStats[index])
                                {
                                    takenStats[index] = true;
                                    bankerCardThreeIndex = index % 13 + 1;
                                    break;
                                }
                            }
                        }
                    }
                    //闲家补三张牌后，庄家两张牌等于5点
                    if (bankerTwoCardPoint == 5)
                    {
                        //闲家三张牌等在0/1//2/3/8/9点中，庄家两张牌等于5点，庄家无需补牌
                        if (playerThreeCardPoint == 0 || playerThreeCardPoint == 1 ||
                            playerThreeCardPoint == 2 || playerThreeCardPoint == 3 ||
                            playerThreeCardPoint == 8 || playerThreeCardPoint == 9)
                        {
                            bankerCardThreeIndex = 14;
                        }
                        //闲家三张牌等不在0/1/2/3/8/9点中，庄家两张牌等于5点，庄家补牌
                        else
                        {
                            while (true)
                            {
                                index = rand.Next(pokerNum * 13);
                                if (!takenStats[index])
                                {
                                    takenStats[index] = true;
                                    bankerCardThreeIndex = index % 13 + 1;
                                    break;
                                }
                            }
                        }
                    }
                    //闲家补三张牌后，庄家两张牌等于6点
                    if (bankerTwoCardPoint == 6)
                    {
                        //闲家三张牌在6/7点中，庄家两张牌等于6点，庄家补牌
                        if (playerThreeCardPoint == 6 || playerThreeCardPoint == 7)
                        {
                            while (true)
                            {
                                index = rand.Next(pokerNum * 13);
                                if (!takenStats[index])
                                {
                                    takenStats[index] = true;
                                    bankerCardThreeIndex = index % 13 + 1;
                                    break;
                                }
                            }
                        }
                        //闲家三张牌等不在6/7点中，庄家两张牌等于6点，庄家无需补牌
                        else
                        {
                            bankerCardThreeIndex = 14;
                        }
                    }

                    //闲家补三张牌后，庄家两张牌大于６，无需补牌
                    if (bankerTwoCardPoint > 6)
                    {
                        bankerCardThreeIndex = 14;
                    }
                }


                result = pokerModel.getCardResult(playerCardOneIndex, bankerCardOneIndex,
                                                        playerCardTwoIndex, bankerCardTwoIndex,
                                                        playerCardThreeIndex, bankerCardThreeIndex);
                resultTimes++;
                if (result.PlayerResult == 1)
                {
                    playerWinTimes++;
                }
                if (result.BankerResult == 1)
                {
                    bankerWinTimes++;
                }
                if (result.TieResult == 1)
                {
                    bothTieTimes++;
                }

                if (result.PlayerResult != 1 && result.BankerResult != 1 && result.TieResult != 1)
                {
                    Console.WriteLine("Unexpected result.");
                }
            }
            Console.WriteLine(resultTimes);
            Console.WriteLine(playerWinTimes * 1.0 / totalCircleTimes);
            Console.WriteLine(bankerWinTimes * 1.0 / totalCircleTimes);
            Console.WriteLine(bothTieTimes * 1.0 / totalCircleTimes);
        }


    }
}
