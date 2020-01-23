using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yahtzee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Public Variables
        public Random rnd = new Random(); //Generates a random number
        public int AmountThrown = 0;
        //Current throw turn
        public int turn = 1; //Is 1 because Round does not start at 0!!
        //The dice to throw
        public int Die1 = 0;
        public int Die2 = 0;
        public int Die3 = 0;
        public int Die4 = 0;
        public int Die5 = 0;
        //Bools to check for stopped dice
        public bool StoppedDie1 = false;
        public bool StoppedDie2 = false;
        public bool StoppedDie3 = false;
        public bool StoppedDie4 = false;
        public bool StoppedDie5 = false;
        //Player's score
        public int score;
        public int RoundScore;
        public bool YahtzeeThrown = false; //Game ends when Yahtzee has been thrown.
        public bool StopButtons = false;
        //How many times has the player thrown them
        public int ThrownThreeOfAKind = 0;
        public int ThrownFourOfAKind = 0;
        public int ThrownChance = 0;
        public int ThrownFullHouse = 0;
        public int ThrownSmallStraight = 0;
        public int ThrownLargeStraight = 0;
        public int ThrownYahtzee = 0;
        public int Number;

        public string Thrown;

        public bool SmallStraight = false;
        public bool LargeStraight = false;
        public bool ThreeOfAKind = false;
        public bool FourOfAKind = false;


        public void Rollen_Click(object sender, RoutedEventArgs e)
        {
            waarschuwingen.Text = "Aan het gooien...";

            RandomNumberlen(); //RandomNumberlen functie aanroepen

            StopButtonsMethod();
            /*SoundPlayer sd = new SoundPlayer();
            sd.SoundLocation = Server.MapPath("~/sounds/File.wav");
            sd.Play();*/
            string link = @"http://www.110studios.nl/wp-content/uploads/2020/01/";

            if (AmountThrown < 3) //Makes sure the player does not throw more than 3 times
            {
                //Freeze the dice numbers after all turns are used
                if (StoppedDie1 != true)
                    DicePicture(Die1, een, link);
                if (StoppedDie2 != true)
                    DicePicture(Die2, twee, link);
                if (StoppedDie3 != true)
                    DicePicture(Die3, drie, link);
                if (StoppedDie4 != true)
                    DicePicture(Die4, vier, link);
                if (StoppedDie5 != true)
                    DicePicture(Die5, vijf, link);

                AmountThrown += 1;
                AllStopped();
            }
            else
            {
                waarschuwingen.Text = "Je hebt al 3 keer gegooid!"; //If you try to roll again, return this error
            }
        }
        public void DicePicture(int dobbel, Image DicePicture, string link)
        {
            DicePicture.Source = new BitmapImage(new Uri(link + dobbel + ".png", UriKind.RelativeOrAbsolute));
        }

        private void RandomNumberlen()
        {
            if (AmountThrown < 3) //Makes sure the dice are only thrown 3 times per turn
            {
                //Picking a random number for the dice
                if (!StoppedDie1)
                    Die1 = rnd.Next(1, 7);
                if (!StoppedDie2)
                    Die2 = rnd.Next(1, 7);
                if (!StoppedDie3)
                    Die3 = rnd.Next(1, 7);
                if (!StoppedDie4)
                    Die4 = rnd.Next(1, 7);
                if (!StoppedDie5)
                    Die5 = rnd.Next(1, 7);
            }
        }

        private void DiceStopClick1(object sender, RoutedEventArgs e)
        {
            if (StoppedDie1 != true)
            {
                StoppedDie1 = true;
                dobbelVast1Knop.Opacity = 0;
                AllStopped();
            }
        }
        private void DiceStopClick2(object sender, RoutedEventArgs e)
        {
            if (StoppedDie2 != true)
            {
                StoppedDie2 = true;
                dobbelVast2Knop.Opacity = 0;
                AllStopped();
            }
        }
        private void DiceStopClick3(object sender, RoutedEventArgs e)
        {
            if (StoppedDie3 != true)
            {
                StoppedDie3 = true;
                dobbelVast3Knop.Opacity = 0;
                AllStopped();
            }
        }
        private void DiceStopClick4(object sender, RoutedEventArgs e)
        {
            if (StoppedDie4 != true)
            {
                StoppedDie4 = true;
                dobbelVast4Knop.Opacity = 0;
                AllStopped();
            }
        }
        private void DiceStopClick5(object sender, RoutedEventArgs e)
        {
            if (StoppedDie5 != true)
            {
                StoppedDie5 = true;
                dobbelVast5Knop.Opacity = 0;
                AllStopped();
            }
        }
        private void AllStopped() //Disabling the buttons after all dice have been stopped.
        {
            if (StoppedDie1 == true && StoppedDie2 == true && StoppedDie3 == true && StoppedDie4 == true && StoppedDie5 == true)
            {
                rollen.IsEnabled = false;
                rollen.Opacity = 0;
                Points();
            }
            else if (AmountThrown == 3)
            {
                dobbelVast1Knop.Opacity = 0;
                dobbelVast2Knop.Opacity = 0;
                dobbelVast3Knop.Opacity = 0;
                dobbelVast4Knop.Opacity = 0;
                dobbelVast5Knop.Opacity = 0;
                dobbelVast1Knop.IsEnabled = false;
                dobbelVast2Knop.IsEnabled = false;
                dobbelVast3Knop.IsEnabled = false;
                dobbelVast4Knop.IsEnabled = false;
                dobbelVast5Knop.IsEnabled = false;

                rollen.IsEnabled = false;
                rollen.Opacity = 0;

                Points();
            }
        }
        private void Straights()
        {
            int[] Die = { Die1, Die2, Die3, Die4, Die5 };
            //Small Straight
            if (Array.Exists(Die, element => element == 1) && Array.Exists(Die, element => element == 2) && Array.Exists(Die, element => element == 3) && Array.Exists(Die, element => element == 4)
                || Array.Exists(Die, element => element == 2) && Array.Exists(Die, element => element == 3) && Array.Exists(Die, element => element == 4) && Array.Exists(Die, element => element == 5)
                || Array.Exists(Die, element => element == 3) && Array.Exists(Die, element => element == 4) && Array.Exists(Die, element => element == 5) && Array.Exists(Die, element => element == 6))
            {
                score += 30;
                RoundScore += 30;

                //Large Straight
                if (Array.Exists(Die, element => element == 1) && Array.Exists(Die, element => element == 2) && Array.Exists(Die, element => element == 3) && Array.Exists(Die, element => element == 4) && Array.Exists(Die, element => element == 5)
                || Array.Exists(Die, element => element == 2) && Array.Exists(Die, element => element == 3) && Array.Exists(Die, element => element == 4) && Array.Exists(Die, element => element == 5) && Array.Exists(Die, element => element == 6))
                {
                    if (ThrownLargeStraight < 1)
                    {
                        score += 10;
                        RoundScore += 10;

                        waarschuwingen.Text = "Grote Straat";
                        ThrownLargeStraight++;
                        scoreTekst.Text = Convert.ToString(score);
                        rondeScoreTekst.Text = Convert.ToString(RoundScore);
                        LargeStraightText.Text = Convert.ToString(RoundScore);

                        SmallStraight = false;
                        LargeStraight = true;
                    }
                    else
                    {
                        waarschuwingen.Text = "Je hebt al Grote Straat gegooid!";
                    }
                }
                else
                {
                    if (ThrownSmallStraight < 1)
                    {
                        waarschuwingen.Text = "Kleine Straat";
                        ThrownSmallStraight++;
                        scoreTekst.Text = Convert.ToString(score);
                        rondeScoreTekst.Text = Convert.ToString(RoundScore);
                        SmallStraightText.Text = Convert.ToString(RoundScore);

                        LargeStraight = false;
                        SmallStraight = true;
                    }
                    else
                    {
                        waarschuwingen.Text = "Je hebt al Kleine Straat gegooid!";
                    }
                }
            }
        }
        private bool EqualsTo (int CompareDifference, int d1, int d2, int d3, int d4, int d5)
        {
            int i = 0;
            int result = 0;

            while (i<7 && result < CompareDifference)
            {
                result = Convert.ToInt32(d1 == i) + Convert.ToInt32(d2 == i) + Convert.ToInt32(d3 == i) + Convert.ToInt32(d4 == i) + Convert.ToInt32(d5 == i) ;

                i++;
            }
            return (result == CompareDifference);
        }

        private void ThreeOfAKindMethod()
        {
            if (EqualsTo( 3, Die1, Die2, Die3, Die4, Die5))
            {
                ThreeOfAKind = true;

                if (ThrownThreeOfAKind < 1)
                {
                    int Sum = Die1 + Die2 + Die3 + Die4 + Die5;
                    score += Sum;
                    RoundScore += Sum;
                    waarschuwingen.Text = "Drie Gelijke";
                    scoreTekst.Text = Convert.ToString(score);
                    rondeScoreTekst.Text = Convert.ToString(RoundScore);

                    ThrownThreeOfAKind++;
                    ThreeOfAKindText.Text = Convert.ToString(RoundScore);
                }
                else
                {
                    waarschuwingen.Text = "Je hebt al Drie Gelijke gegooid!";
                }
            }
            else
            {
                ThreeOfAKind = false;
            }
        }
        private void FourOfAKindMethod()
        {
            if (EqualsTo(4, Die1, Die2, Die3, Die4, Die5))
            {
                FourOfAKind = true;
                if (ThrownFourOfAKind < 1)
                {
                    int Sum = Die1 + Die2 + Die3 + Die4 + Die5;
                    score += Sum;
                    RoundScore += Sum;
                    waarschuwingen.Text = "Vier Gelijke";
                    scoreTekst.Text = Convert.ToString(score);
                    rondeScoreTekst.Text = Convert.ToString(RoundScore);

                    ThrownFourOfAKind++;
                    FourOfAKindText.Text = Convert.ToString(RoundScore);
                }
                else
                {
                    waarschuwingen.Text = "Je hebt al Vier Gelijke gegooid!";
                }
            }
            else
            {
                FourOfAKind = false;
            }
        }
        private void Yahtzee()
        {
            int[] Die = { Die1, Die2, Die3, Die4, Die5 };
            //Yahtzee
            if (Die[0] == Die[1] && Die[1] == Die[2] && Die[2] == Die[3] && Die[3] == Die[4]
                && !LargeStraight && !SmallStraight)
            {
                score += 50;
                RoundScore += 50;
                scoreTekst.Text = Convert.ToString(score);
                rondeScoreTekst.Text = Convert.ToString(RoundScore);
                waarschuwingen.Text = "YAHTZEE!";

                ThrownYahtzee++;
                yahtzeeTekst.Text += RoundScore;
                YahtzeeThrown = true;
            }
            else
            {
                YahtzeeThrown = false;
            }
        }
        private void Chance()
        {
            int[] Die = { Die1, Die2, Die3, Die4, Die5 };
            bool FullHouse = (Die.Distinct().Count() == 2) &&
                                Die.GroupBy(x => x).Any(g => g.Count() == 2);//Source: https://stackoverflow.com/questions/59820298/yahtzee-game-full-house

            //Chance
            if (RoundScore < 1 && !ThreeOfAKind && !FourOfAKind && !FullHouse && !SmallStraight && !LargeStraight)
            {
                if (ThrownChance < 1)
                {
                    int Sum = Die[0] + Die[1] + Die[2] + Die[3] + Die[4];
                    score += Sum;
                    RoundScore += Sum;

                    scoreTekst.Text = Convert.ToString(score); //Adjust score text
                    rondeScoreTekst.Text = Convert.ToString(RoundScore); //Adjust RoundScore text
                    waarschuwingen.Text = "Kans"; //Show Chance in Warningtext

                    ThrownChance++; //Add one to chance counter
                    ChanceText.Text += RoundScore;
                }
                else
                {
                    waarschuwingen.Text = "Je hebt al kans gegooid!";
                }
            }
        }

        private void Points()
        {
            int[] Die = { Die1, Die2, Die3, Die4, Die5 };
            bool FullHouse = (Die.Distinct().Count() == 2) &&
                    Die.GroupBy(x => x).Any(g => g.Count() == 2);//Source: https://stackoverflow.com/questions/59820298/yahtzee-game-full-house

            /*Drie gelijke: De score is het totaal van alle ogen, als er minstens 3 Die met hetzelfde aantal ogen zijn.
              Vier gelijke: De score is het totaal van alle ogen, als er minstens 4 Die met hetzelfde aantal ogen zijn.
              Kleine straat: 30 Points voor 4 opeenvolgende ogenaantallen.
              Grote straat: 40 Points voor 5 opeenvolgende ogenaantallen.
              Full House: 25 Points voor 3 gelijke en één paar.
              Chance: De score is het totaal aantal ogen van alle Die.
              Yahtzee: 50 Points als alle Die hetzelfde aantal ogen hebben.*/

            //Calling Functions
            Straights();
            if (!LargeStraight && !SmallStraight)
            {
                Yahtzee();
                if (!YahtzeeThrown)
                {
                    FourOfAKindMethod();
                    if (!FourOfAKind)
                    {
                        if (!FullHouse)
                        {
                            ThreeOfAKindMethod();
                            if (!ThreeOfAKind)
                                Chance();
                        }
                        else
                        {
                            //Full House
                            if (ThrownFullHouse < 1)
                            {
                                score += 25;
                                RoundScore += 25;
                                waarschuwingen.Text = "Full House";
                                scoreTekst.Text = Convert.ToString(score);
                                rondeScoreTekst.Text = Convert.ToString(RoundScore);

                                ThrownFullHouse++;
                                fullHouseTekst.Text = Convert.ToString(RoundScore);
                            }
                            else
                            {
                                waarschuwingen.Text = "Je hebt al Full House gegooid!";
                            }
                        }
                    }
                }
            }

            NextTurn.Opacity = 1;
            NextTurn.IsEnabled = true;

            gemiddeldTekst.Text = Convert.ToString(score / turn); //Shows average of the total sum

            GameQuit();
            ChooseEyeAmount();
        }
        private void StopButtonsMethod()
        {
            //Resets the hold buttons
            if (StopButtons != true)
            {
                dobbelVast1Knop.Opacity = 1; dobbelVast1Knop.IsEnabled = true;
                dobbelVast2Knop.Opacity = 1; dobbelVast2Knop.IsEnabled = true;
                dobbelVast3Knop.Opacity = 1; dobbelVast3Knop.IsEnabled = true;
                dobbelVast4Knop.Opacity = 1; dobbelVast4Knop.IsEnabled = true;
                dobbelVast5Knop.Opacity = 1; dobbelVast5Knop.IsEnabled = true;

                StopButtons = true;
            }
        }
        /*private void Kies(int[] dobbel, Button knop)
        {
            int tel = 0;
            while (tel < 6)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (dobbel[tel] == i)
                    {
                        knop.Opacity = 1;
                        knop.IsEnabled = true;
                    }
                }
                tel++;
            }
        }*/
        private void ChooseEyeAmount()
        {
            ResetSelection();
            int[] DiceCheck = { Die1, Die2, Die3, Die4, Die5 };

            if (Die1 == 1 || Die2 == 1 || Die3 == 1 || Die4 == 1 || Die5 == 1)
            {
                Selecteer1Enen.Opacity = 1;
                Selecteer1Enen.IsEnabled = true;
            }
            if (Die1 == 2 || Die2 == 2 || Die3 == 2 || Die4 == 2 || Die5 == 2)
            {
                Selecteer2Tweeen.Opacity = 1;
                Selecteer2Tweeen.IsEnabled = true;
            }
            if (Die1 == 3 || Die2 == 3 || Die3 == 3 || Die4 == 3 || Die5 == 3)
            {
                Selecteer3Drieen.Opacity = 1;
                Selecteer3Drieen.IsEnabled = true;
            }
            if (Die1 == 4 || Die2 == 4 || Die3 == 4 || Die4 == 4 || Die5 == 4)
            {
                Selecteer4Vieren.Opacity = 1;
                Selecteer4Vieren.IsEnabled = true;
            }
            if (Die1 == 5 || Die2 == 5 || Die3 == 5 || Die4 == 5 || Die5 == 5)
            {
                Selecteer5Vijven.Opacity = 1;
                Selecteer5Vijven.IsEnabled = true;
            }
            if (Die1 == 6 || Die2 == 6 || Die3 == 6 || Die4 == 6 || Die5 == 6)
            {
                Selecteer6Zessen.Opacity = 1;
                Selecteer6Zessen.IsEnabled = true;
            }
        }
        private void ResetSelection()
        {
            Selecteer1Enen.Opacity = 0;
            Selecteer2Tweeen.Opacity = 0;
            Selecteer3Drieen.Opacity = 0;
            Selecteer4Vieren.Opacity = 0;
            Selecteer5Vijven.Opacity = 0;
            Selecteer6Zessen.Opacity = 0;

            Selecteer1Enen.IsEnabled = false;
            Selecteer2Tweeen.IsEnabled = false;
            Selecteer3Drieen.IsEnabled = false;
            Selecteer4Vieren.IsEnabled = false;
            Selecteer5Vijven.IsEnabled = false;
            Selecteer6Zessen.IsEnabled = false;
        }
        private void NextTurnClick(object sender, RoutedEventArgs e)
        {
            if (YahtzeeThrown != true)
            {
                RoundScore = 0;
                turn += 1;
                rondeScoreTekst.Text = "0";

                StopButtons = false;

                StoppedDie1 = false;
                StoppedDie2 = false;
                StoppedDie3 = false;
                StoppedDie4 = false;
                StoppedDie5 = false;

                SmallStraight = false;
                LargeStraight = false;
                ThreeOfAKind = false;
                FourOfAKind = false;

                AmountThrown = 0;

                Die1 = 0;
                Die2 = 0;
                Die3 = 0;
                Die4 = 0;
                Die5 = 0;

                rollen.IsEnabled = true;
                rollen.Opacity = 1;

                NextTurn.IsEnabled = false;
                NextTurn.Opacity = 0;
            }
        }

        private void Spelregels_Click(object sender, RoutedEventArgs e)
        {
            Window1 sw = new Window1();
            sw.Show();
        }

        private void GameQuit()
        {
            if (YahtzeeThrown == true)
            {
                NextTurn.IsEnabled = false;
                NextTurn.Opacity = 0;

                waarschuwingen.Text += " | Spel Afgelopen";
            }
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        }
    }
}