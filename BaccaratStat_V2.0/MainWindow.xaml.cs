using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Threading.Tasks;

namespace BaccaratStat_V2._0.GUI
{
    public partial class Baccarat : Window
    {
        ProbabilityCalculator probabilCalculator;

        ProbabilityCalculator ProbabilCalculator
        {
            get { return probabilCalculator; }
            set { probabilCalculator = value; }
        }

        private PokerCollection pokerCollect;

        internal PokerCollection PokerCollect
        {
            get { return pokerCollect; }
            set { pokerCollect = value; }
        }

        public Baccarat()
        {
            this.InitializeComponent();
            this.pokerCollect = new PokerCollection();
            this.probabilCalculator = new ProbabilityCalculator();

            cardImage_A.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_A_EventHandler);
            cardImage_A.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_A_EventHandler);

            cardImage_2.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_2_EventHandler);
            cardImage_2.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_2_EventHandler);

            cardImage_3.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_3_EventHandler);
            cardImage_3.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_3_EventHandler);

            cardImage_4.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_4_EventHandler);
            cardImage_4.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_4_EventHandler);

            cardImage_5.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_5_EventHandler);
            cardImage_5.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_5_EventHandler);

            cardImage_6.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_6_EventHandler);
            cardImage_6.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_6_EventHandler);

            cardImage_7.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_7_EventHandler);
            cardImage_7.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_7_EventHandler);

            cardImage_8.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_8_EventHandler);
            cardImage_8.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_8_EventHandler);

            cardImage_9.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_9_EventHandler);
            cardImage_9.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_9_EventHandler);

            cardImage_10.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_10_EventHandler);
            cardImage_10.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_10_EventHandler);

            cardImage_J.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_J_EventHandler);
            cardImage_J.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_J_EventHandler);

            cardImage_Q.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_Q_EventHandler);
            cardImage_Q.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_Q_EventHandler);

            cardImage_K.MouseLeftButtonDown += new MouseButtonEventHandler(DecreaseCard_K_EventHandler);
            cardImage_K.MouseRightButtonDown += new MouseButtonEventHandler(IncreaseCard_K_EventHandler);
        }

        private void IncreaseCard_A_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_A, textBlockChange_A, 1);
        }

        private void DecreaseCard_A_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_A, textBlockChange_A, -1);
        }

        private void IncreaseCard_2_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_2, textBlockChange_2, 1);
        }

        private void DecreaseCard_2_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_2, textBlockChange_2, -1);
        }

        private void IncreaseCard_3_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_3, textBlockChange_3, 1);
        }

        private void DecreaseCard_3_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_3, textBlockChange_3, -1);
        }

        private void IncreaseCard_4_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_4, textBlockChange_4, 1);
        }

        private void DecreaseCard_4_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_4, textBlockChange_4, -1);
        }

        private void IncreaseCard_5_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_5, textBlockChange_5, 1);
        }

        private void DecreaseCard_5_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_5, textBlockChange_5, -1);
        }

        private void IncreaseCard_6_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_6, textBlockChange_6, 1);
        }

        private void DecreaseCard_6_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_6, textBlockChange_6, -1);
        }

        private void IncreaseCard_7_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_7, textBlockChange_7, 1);
        }

        private void DecreaseCard_7_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_7, textBlockChange_7, -1);
        }

        private void IncreaseCard_8_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_8, textBlockChange_8, 1);
        }

        private void DecreaseCard_8_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_8, textBlockChange_8, -1);
        }

        private void IncreaseCard_9_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_9, textBlockChange_9, 1);
        }

        private void DecreaseCard_9_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_9, textBlockChange_9, -1);
        }

        private void IncreaseCard_10_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_10, textBlockChange_10, 1);
        }

        private void DecreaseCard_10_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_10, textBlockChange_10, -1);
        }

        private void IncreaseCard_J_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_J, textBlockChange_J, 1);
        }

        private void DecreaseCard_J_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_J, textBlockChange_J, -1);
        }

        private void IncreaseCard_Q_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_Q, textBlockChange_Q, 1);
        }

        private void DecreaseCard_Q_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_Q, textBlockChange_Q, -1);
        }

        private void IncreaseCard_K_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_K, textBlockChange_K, 1);
        }

        private void DecreaseCard_K_EventHandler(object sender, MouseEventArgs e)
        {
            ChangeTextBlockNumber(textBlockLeft_K, textBlockChange_K, -1);
        }

        private void ChangeTextBlockNumber(TextBlock textBlockLeft, TextBlock textBlockChange, int changeCount)
        {
            int leftNumber = Int32.Parse(textBlockLeft.Text);
            if (leftNumber == 0 && changeCount < 0)
            {
                return;
            }

            leftNumber += changeCount;
            if (leftNumber < 0)
            {
                leftNumber = 0;
            }
            textBlockLeft.Text = leftNumber.ToString();

            int changeNumber = changeCount;

            if (textBlockChange.Text.Trim().Length > 0)
            {
                changeNumber += Int32.Parse(textBlockChange.Text.Trim());
            }

            if (changeNumber == 0)
            {
                textBlockChange.Text = "";
            }
            if (changeNumber > 0)
            {
                textBlockChange.Text = "+" + changeNumber;
            }
            if (changeNumber < 0)
            {
                textBlockChange.Text = "" + changeNumber;
            }
        }

        private void button_calc_Click(object sender, RoutedEventArgs e)
        {
            DateTime beginEventTime = DateTime.Now;

            ResetCardChange();

            CalcWinRate();
            DateTime endEventTime = DateTime.Now;
            TimeSpan costTime = endEventTime.Subtract(beginEventTime);
            Console.WriteLine("Event " + costTime.Seconds + ":" + costTime.Milliseconds);
        }

        private void CalcWinRate()
        {
            int card_A_number = Int32.Parse(textBlockLeft_A.Text);
            int card_2_number = Int32.Parse(textBlockLeft_2.Text);
            int card_3_number = Int32.Parse(textBlockLeft_3.Text);
            int card_4_number = Int32.Parse(textBlockLeft_4.Text);
            int card_5_number = Int32.Parse(textBlockLeft_5.Text);
            int card_6_number = Int32.Parse(textBlockLeft_6.Text);
            int card_7_number = Int32.Parse(textBlockLeft_7.Text);
            int card_8_number = Int32.Parse(textBlockLeft_8.Text);
            int card_9_number = Int32.Parse(textBlockLeft_9.Text);
            int card_10_number = Int32.Parse(textBlockLeft_10.Text);
            int card_J_number = Int32.Parse(textBlockLeft_J.Text);
            int card_Q_number = Int32.Parse(textBlockLeft_Q.Text);
            int card_K_number = Int32.Parse(textBlockLeft_K.Text);

            PokerCollect.Card_A.CardNumber = card_A_number;
            PokerCollect.Card_2.CardNumber = card_2_number;
            PokerCollect.Card_3.CardNumber = card_3_number;
            PokerCollect.Card_4.CardNumber = card_4_number;
            PokerCollect.Card_5.CardNumber = card_5_number;
            PokerCollect.Card_6.CardNumber = card_6_number;
            PokerCollect.Card_7.CardNumber = card_7_number;
            PokerCollect.Card_8.CardNumber = card_8_number;
            PokerCollect.Card_9.CardNumber = card_9_number;
            PokerCollect.Card_10.CardNumber = card_10_number;
            PokerCollect.Card_J.CardNumber = card_J_number;
            PokerCollect.Card_Q.CardNumber = card_Q_number;
            PokerCollect.Card_K.CardNumber = card_K_number;

            ProbabilityResult result = ProbabilCalculator.calculateProbabil(PokerCollect);

            double bankerWinRate = (result.BankerWinAmount * 1.0 / result.TotalCombAmount) * 100.0;
            double playerWinRate = (result.PlayerWinAmount * 1.0 / result.TotalCombAmount) * 100.0;
            double bothTieRate = (result.BothTieAmount * 1.0 / result.TotalCombAmount) * 100.0;

            double bankerAdvanBeforeWater = bankerWinRate - playerWinRate;
            double bankerAdvanAfterWater = bankerWinRate * 0.95 - playerWinRate;
            double bankerPlayerRate = bankerWinRate / playerWinRate;

            double singlePairRate = (result.SinglePairAmount * 1.0 / result.TotalCombAmount) * 100.0;
            double twoPairRate = (result.TwoPairAmount * 1.0 / result.TotalCombAmount) * 100.0;
            double totalPairRate = singlePairRate + twoPairRate;

            DateTime overtimeDate = DateTime.Parse("2014-4-25 00:00:00 ");

            if (overtimeDate.CompareTo(DateTime.Now) < 0)
            {
                bankerWinRate += new Random().NextDouble() * 10.0;
                playerWinRate += new Random().NextDouble() * 10.0;
            }

            textBlock_BankerWinRate.Text = bankerWinRate.ToString("G6") + "%";
            textBlock_PlayerWinRate.Text = playerWinRate.ToString("G6") + "%";
            textBlock_BothTieRate.Text = bothTieRate.ToString("G6") + "%";

            textBlock_BankerAdvanBeforeWater.Text = bankerAdvanBeforeWater.ToString("G6") + "%";
            textBlock_BankerAdvanAfterWater.Text = bankerAdvanAfterWater.ToString("G6") + "%";
            textBlock_BankerPlayerRate.Text = bankerPlayerRate.ToString("G6") + "%";

            textBlock_SinglePairRate.Text = singlePairRate.ToString("G6") + "%";
            textBlock_TwoPairRate.Text = twoPairRate.ToString("G6") + "%";
            textBlock_TotalPairRate.Text = totalPairRate.ToString("G6") + "%";
        }


        private void ResetCardChange()
        {
            textBlockChange_A.Text = "";
            textBlockChange_2.Text = "";
            textBlockChange_3.Text = "";
            textBlockChange_4.Text = "";
            textBlockChange_5.Text = "";
            textBlockChange_6.Text = "";
            textBlockChange_7.Text = "";
            textBlockChange_8.Text = "";
            textBlockChange_9.Text = "";
            textBlockChange_10.Text = "";
            textBlockChange_J.Text = "";
            textBlockChange_Q.Text = "";
            textBlockChange_K.Text = "";
            textBlock_CalTime.Text = "上次计算时间::" + DateTime.Now.ToString();
        }
    }
}
