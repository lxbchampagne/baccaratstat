using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;


namespace BaccaratStat_V2._0
{
    public class ProbabilityCalculator
    {
        public ProbabilityCalculator()
        {
            probabResult = new ProbabilityResult();
            pokerModel = new PokerCombModel();
        }

        private long cpuCoreNum = Environment.ProcessorCount;

        public long CPUCoreNum
        {
            get { return cpuCoreNum; }
        }

        public ProbabilityResult calculateProbabil(PokerCollection pokerCollect)
        {
            DateTime beginCalTime = DateTime.Now;

            Task<ProbabilityResult>[] taskList = new Task<ProbabilityResult>[CPUCoreNum];
            for (int cpuIndex = 0; cpuIndex < CPUCoreNum; cpuIndex++)
            {
                int taskIndex = cpuIndex;
                taskList[taskIndex] = new Task<ProbabilityResult>(() => { return calculateProbabl(taskIndex, pokerCollect); });
            }

            for (int index = 0; index < taskList.Length; index++)
            {
                taskList[index].Start();
            }
            for (int index = 0; index < taskList.Length; index++)
            {
                taskList[index].Wait();
            }

            ProbabilityResult sumResult = new ProbabilityResult();
            foreach (Task<ProbabilityResult> task in taskList)
            {
                sumResult.TotalCombAmount += task.Result.TotalCombAmount;
                sumResult.BankerWinAmount += task.Result.BankerWinAmount;
                sumResult.PlayerWinAmount += task.Result.PlayerWinAmount;
                sumResult.BothTieAmount += task.Result.BothTieAmount;
                sumResult.SinglePairAmount += task.Result.SinglePairAmount;
                sumResult.TwoPairAmount += task.Result.TwoPairAmount;
                sumResult.TotalCombAmount += task.Result.TotalCombAmount;
            }

            int totalCardNumber = 0;
            for (int cardIndex = 1; cardIndex <= 13; cardIndex++)
            {
                totalCardNumber += pokerCollect.getCard(cardIndex).CardNumber;
            }

            long totalCombAmount = 1L;
            for (int index = 0; index < 6; index++)
            {
                totalCombAmount *= (totalCardNumber - index);
            }

            sumResult.TotalCombAmount = totalCombAmount;

            DateTime endCalTime = DateTime.Now;
            TimeSpan costTime = endCalTime.Subtract(beginCalTime);
            Console.WriteLine("Calculate " + costTime.Seconds + ":" + costTime.Milliseconds);

            return sumResult;   
        }

        private ProbabilityResult calculateProbabl(int taskId, PokerCollection pokerCollect)
        {
            DateTime taskBeginTime = DateTime.Now;

            ProbabilityResult calResult = new ProbabilityResult();
            calResult.reset();

            int totalCardNumber = 0;
            for (int cardIndex = 1; cardIndex <= 13; cardIndex++)
            {
                totalCardNumber += pokerCollect.getCard(cardIndex).CardNumber;
            }

            Dictionary<int, int> localDictionary = new Dictionary<int, int>();
            for(int cardIndex = 1; cardIndex <= 14; cardIndex++)
            {
                localDictionary.Add(cardIndex, 0);
            }

            long playerWinTimes = 0L;
            long bankerWinTimes = 0L;
            long tieWinTimes = 0L;
            long singlePairTimes = 0L;
            long twoPairTimes = 0L;

            int itemIndex = 0;
            foreach(var item in PokerModel.ModelDictionary)
            {
                itemIndex++;
                if ((itemIndex - 1) % CPUCoreNum != taskId)
                {
                    continue;
                }

                for (int cardIndex = 1; cardIndex <= 14; cardIndex++)
                {
                    localDictionary[cardIndex] = 0;
                }

                long itemKey = item.Key;
                PokerCardResult itemValue = item.Value;

                localDictionary[PokerModel.getPlayerCardOneIndex(itemKey)] += 1;
                localDictionary[PokerModel.getBankerCardOneIndex(itemKey)] += 1;
                localDictionary[PokerModel.getPlayerCardTwoIndex(itemKey)] += 1;
                localDictionary[PokerModel.getBankerCardTwoIndex(itemKey)] += 1;
                localDictionary[PokerModel.getPlayerCardThreeIndex(itemKey)] += 1;
                localDictionary[PokerModel.getBankerCardThreeIndex(itemKey)] += 1;

                long combOccurTimes = 1L;

                for (int cardIndex = 1; cardIndex <= 13; cardIndex++)
                {
                    for (int localIndex = 0; localIndex < localDictionary[cardIndex]; localIndex++)
                    {
                        combOccurTimes *= (pokerCollect.getCard(cardIndex).CardNumber - localIndex);
                    }
                }
                
                switch (localDictionary[14])
                {
                    case 0:
                        combOccurTimes *= 1;
                        break;
                    case 1:
                        combOccurTimes *= (totalCardNumber - 5);
                        break;
                    case 2:
                        combOccurTimes *= (totalCardNumber - 4) * (totalCardNumber - 5);
                        break;
                    default:
                        break;
                }

                if (itemValue.PlayerResult == 1)
                {
                    playerWinTimes += combOccurTimes;
                }
                if (itemValue.BankerResult == 1)
                {
                    bankerWinTimes += combOccurTimes;
                }
                if (itemValue.TieResult == 1)
                {
                    tieWinTimes += combOccurTimes;
                }
                if (itemValue.SinglePairResult == 1)
                {
                    singlePairTimes += combOccurTimes;
                }
                if (itemValue.TwoPairResult == 1)
                {
                    twoPairTimes += combOccurTimes;
                }
            }

            calResult.PlayerWinAmount = playerWinTimes;
            calResult.BankerWinAmount = bankerWinTimes;
            calResult.BothTieAmount = tieWinTimes;
            calResult.SinglePairAmount = singlePairTimes;
            calResult.TwoPairAmount = twoPairTimes;

            DateTime taskEndTime = DateTime.Now;

            TimeSpan costTime = taskEndTime.Subtract(taskBeginTime);
            Console.WriteLine("Task " + taskId + " " + costTime.Seconds + ":" + costTime.Milliseconds);

            return calResult;
        }

        private ProbabilityResult probabResult;

        public ProbabilityResult ProbablResult
        {
            get { return probabResult; }
            set { probabResult = value; }
        }
        private PokerCombModel pokerModel;

        public PokerCombModel PokerModel
        {
            get { return pokerModel; }
            set { pokerModel = value; }
        }

    }
}
