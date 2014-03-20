using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Management.Instrumentation;
using System.Configuration;

namespace TestApp
{
    class CalLastCard
    {
        static void Main(string[] args)
        {
            int totalCardNum = 35;
            int maxSingleCardNum = 32;

            long possCombCount = 0;
            for (int cardAIndex = 0; cardAIndex <= maxSingleCardNum; cardAIndex++)
            {
                if (cardAIndex == totalCardNum)
                {
                    possCombCount += 1;
                    break;
                }
                for (int card2Index = 0; card2Index <= maxSingleCardNum; card2Index++)
                {
                    if (cardAIndex + card2Index == totalCardNum)
                    {
                        possCombCount += 1;
                        break;
                    }
                    for (int card3Index = 0; card3Index <= maxSingleCardNum; card3Index++)
                    {
                        if (cardAIndex + card2Index + card3Index == totalCardNum)
                        {
                            possCombCount += 1;
                            break;
                        }
                        for (int card4Index = 0; card4Index <= maxSingleCardNum; card4Index++)
                        {
                            if (cardAIndex + card2Index + card3Index + card4Index == totalCardNum)
                            {
                                possCombCount += 1;
                                break;
                            }
                            for (int card5Index = 0; card5Index <= maxSingleCardNum; card5Index++)
                            {
                                if (cardAIndex + card2Index + card3Index + card4Index
                                    + card5Index == totalCardNum)
                                {
                                    possCombCount += 1;
                                    break;
                                }
                                for (int card6Index = 0; card6Index <= maxSingleCardNum; card6Index++)
                                {
                                    if (cardAIndex + card2Index + card3Index + card4Index
                                        + card5Index + card6Index == totalCardNum)
                                    {
                                        possCombCount += 1;
                                        break;
                                    }
                                    for (int card7Index = 0; card7Index <= maxSingleCardNum; card7Index++)
                                    {
                                        if (cardAIndex + card2Index + card3Index + card4Index
                                            + card5Index + card6Index + card7Index == totalCardNum)
                                        {
                                            possCombCount += 1;
                                            break;
                                        }
                                        for (int card8Index = 0; card8Index <= maxSingleCardNum; card8Index++)
                                        {
                                            if (cardAIndex + card2Index + card3Index + card4Index + card5Index
                                                + card6Index + card7Index + card8Index == totalCardNum)
                                            {
                                                possCombCount += 1;
                                                break;
                                            }
                                            for (int card9Index = 0; card9Index <= maxSingleCardNum; card9Index++)
                                            {
                                                if (cardAIndex + card2Index + card3Index + card4Index 
                                                    + card5Index + card6Index + card7Index + card8Index
                                                    + card9Index == totalCardNum)
                                                {
                                                    possCombCount += 1;
                                                    break;
                                                }
                                                for (int card10Index = 0; card10Index <= maxSingleCardNum; card10Index++)
                                                {
                                                    if (cardAIndex + card2Index + card3Index + card4Index 
                                                        + card5Index + card6Index + card7Index + card8Index
                                                        + card9Index + card10Index == totalCardNum)
                                                    {
                                                        possCombCount += 1;
                                                        break;
                                                    }
                                                    for (int cardJIndex = 0; cardJIndex <= maxSingleCardNum; cardJIndex++)
                                                    {
                                                        if (cardAIndex + card2Index + card3Index + card4Index
                                                            + card5Index + card6Index + card7Index + card8Index
                                                            + card9Index + card10Index + cardJIndex == totalCardNum)
                                                        {
                                                            possCombCount += 1;
                                                            break;
                                                        }
                                                        for (int cardQIndex = 0; cardQIndex <= maxSingleCardNum; cardQIndex++)
                                                        {
                                                            if (cardAIndex + card2Index + card3Index + card4Index
                                                                + card5Index + card6Index + card7Index + card8Index
                                                                + card9Index + card10Index + cardJIndex + cardQIndex == totalCardNum)
                                                            {
                                                                possCombCount += 1;
                                                                break;
                                                            }
                                                            for (int cardKIndex = 0; cardKIndex <= maxSingleCardNum; cardKIndex++)
                                                            {
                                                                if (cardAIndex + card2Index + card3Index + card4Index
                                                                    + card5Index + card6Index + card7Index + card8Index
                                                                    + card9Index + card10Index + cardJIndex + cardQIndex
                                                                    + cardKIndex == totalCardNum)
                                                                {
                                                                    possCombCount += 1;
                                                                    break;
                                                                }
                                                            }//cardKIndex
                                                        }//cardQIndex
                                                    }//cardJIndex
                                                }//card10Index
                                            }//card9Index
                                        }//card8Index
                                    }//card7Index
                                }//card6Index
                            }//card5Index
                        }//card4Index
                    }//card3Index
                }//card2Index
            }//cardAIndex

            Console.WriteLine("Possible Combination Count::" + possCombCount);

            Console.ReadLine();
        }
    }
}
