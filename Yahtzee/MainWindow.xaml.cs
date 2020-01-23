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
        //Public variable
        public Random rnd = new Random();
        public int aantalGooien = 0;
        //Beurt
        public int beurt = 1; //Must be 1 because he starts at turn 1 not turn 0 !!
        //The dices
        public int dobbelsteen1 = 0;
        public int dobbelsteen2 = 0;
        public int dobbelsteen3 = 0;
        public int dobbelsteen4 = 0;
        public int dobbelsteen5 = 0;
        //Stopped dices
        public bool alGestoptDobbelsteen1 = false;
        public bool alGestoptDobbelsteen2 = false;
        public bool alGestoptDobbelsteen3 = false;
        public bool alGestoptDobbelsteen4 = false;
        public bool alGestoptDobbelsteen5 = false;
        //Score of player:
        public int score;
        public int rondeScore;
        public bool yahtzeeGegooid = false; //Game stops when a player throws a Yahtzee
        public bool stopKnoppen = false;
        //What the player throws:
        public int gegooideDrieGelijke = 0;
        public int gegooideVierGelijke = 0;
        public int gegooideKans = 0;
        public int gegooideFullHouse = 0;
        public int gegooideKleineStraat = 0;
        public int gegooideGroteStraat = 0;
        public int gegooideYahtzee = 0;
        public int getal;

        public string gegooid;

        public bool kleineStraat = false;
        public bool groteStraat = false;
        public bool drieGelijke = false;
        public bool vierGelijke = false;


        public void Rollen_Click(object sender, RoutedEventArgs e)
        {
            waarschuwingen.Text = "Aan het gooien...";

            RandomGetallen(); //RandomNumber throwing
            
            StopKnoppen();
            /*SoundPlayer sd = new SoundPlayer();
            sd.SoundLocation = Server.MapPath("~/sounds/File.wav");
            sd.Play();*/
            string link = @"http://www.110studios.nl/wp-content/uploads/2020/01/";
            
            if (aantalGooien < 3) //Ensures that no more throwing is possible than 3 times
            {
                //If the stop button of a dice is clicked, he must not change the number
                if (alGestoptDobbelsteen1 != true)
                    DobbelsteenFoto(dobbelsteen1, een, link);
                if (alGestoptDobbelsteen2 != true)
                    DobbelsteenFoto(dobbelsteen2, twee, link);
                if (alGestoptDobbelsteen3 != true)
                    DobbelsteenFoto(dobbelsteen3, drie, link);
                if (alGestoptDobbelsteen4 != true)
                    DobbelsteenFoto(dobbelsteen4, vier, link);
                if (alGestoptDobbelsteen5 != true)
                    DobbelsteenFoto(dobbelsteen5, vijf, link);

                aantalGooien += 1;
                AllesGestopt();
            }
            else
            {
                waarschuwingen.Text = "Je hebt al 3 keer gegooid"; //If the player has thrown 3 times and the player wants to throw again, it will be shown
            }
        }
        public void DobbelsteenFoto(int dobbel, Image dobbelsteenFoto, string link)
        {
            dobbelsteenFoto.Source = new BitmapImage(new Uri(link + dobbel + ".png", UriKind.RelativeOrAbsolute));
        }

        private void RandomGetallen()
        {
            if (aantalGooien < 3) //Ensures that the dice receive a random number a maximum of 3 times
            {
                //Choose a random number for each die
                if (!alGestoptDobbelsteen1)
                    dobbelsteen1 = rnd.Next(1, 7);
                if (!alGestoptDobbelsteen2)
                    dobbelsteen2 = rnd.Next(1, 7);
                if (!alGestoptDobbelsteen3)
                    dobbelsteen3 = rnd.Next(1, 7);
                if (!alGestoptDobbelsteen4)
                    dobbelsteen4 = rnd.Next(1, 7);
                if (!alGestoptDobbelsteen5)
                    dobbelsteen5 = rnd.Next(1, 7);
            }
        }

        private void DobbelVast1Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen1 != true)
            {
                alGestoptDobbelsteen1 = true;
                dobbelVast1Knop.Opacity = 0;
                AllesGestopt();
            }
        }
        private void DobbelVast2Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen2 != true)
            {
                alGestoptDobbelsteen2 = true;
                dobbelVast2Knop.Opacity = 0;
                AllesGestopt();
            }
        }
        private void DobbelVast3Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen3 != true)
            {
                alGestoptDobbelsteen3 = true;
                dobbelVast3Knop.Opacity = 0;
                AllesGestopt();
            }
        }
        private void DobbelVast4Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen4 != true)
            {
                alGestoptDobbelsteen4 = true;
                dobbelVast4Knop.Opacity = 0;
                AllesGestopt();
            }
        }
        private void DobbelVast5Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen5 != true)
            {
                alGestoptDobbelsteen5 = true;
                dobbelVast5Knop.Opacity = 0;
                AllesGestopt();
            }
        }
        private void AllesGestopt()
        {
            if (alGestoptDobbelsteen1 == true && alGestoptDobbelsteen2 == true && alGestoptDobbelsteen3 == true && alGestoptDobbelsteen4 == true && alGestoptDobbelsteen5 == true)
            {
                rollen.IsEnabled = false;
                rollen.Opacity = 0;
                Punten();
            }
            else if (aantalGooien == 3)
            {
                //Stop the dices
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

                Punten();
            }
        }
        private void Straten()
        {
            int[] dobbelstenen = { dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5 };
            //Small street
            if (Array.Exists(dobbelstenen, element => element == 1) && Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4)
                || Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5)
                || Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5) && Array.Exists(dobbelstenen, element => element == 6))
            {
                score += 30;
                rondeScore += 30;

                //Big street
                if (Array.Exists(dobbelstenen, element => element == 1) && Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5)
                || Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5) && Array.Exists(dobbelstenen, element => element == 6))
                {
                    if (gegooideGroteStraat < 1)
                    {
                        score += 10;
                        rondeScore += 10;

                        waarschuwingen.Text = "Grote Straat";
                        gegooideGroteStraat++;
                        scoreTekst.Text = Convert.ToString(score);
                        rondeScoreTekst.Text = Convert.ToString(rondeScore);
                        groteStraatTekst.Text = Convert.ToString(rondeScore);

                        kleineStraat = false;
                        groteStraat = true;
                    }
                    else
                    {
                        waarschuwingen.Text = "Je hebt al Grote Straat gegooid";
                    }
                }
                else
                {
                    if (gegooideKleineStraat < 1)
                    {
                        waarschuwingen.Text = "Kleine Straat";
                        gegooideKleineStraat++;
                        scoreTekst.Text = Convert.ToString(score);
                        rondeScoreTekst.Text = Convert.ToString(rondeScore);
                        kleineStraatTekst.Text = Convert.ToString(rondeScore);

                        groteStraat = false;
                        kleineStraat = true;
                    }
                    else
                    {
                        waarschuwingen.Text = "Je hebt al Kleine Straat gegooid";
                    }
                }
            }
        }
        private bool IsGelijke (int vergelijk, int d1, int d2, int d3, int d4, int d5)
        {
            int i = 0;
            int result = 0;

            while (i<7 && result < vergelijk)
            {
                result = Convert.ToInt32(d1 == i) + Convert.ToInt32(d2 == i) + Convert.ToInt32(d3 == i) + Convert.ToInt32(d4 == i) + Convert.ToInt32(d5 == i) ; 

                i++;
            }
            return (result == vergelijk);
        }
        
        private void DrieGelijke()
        {
            if (IsGelijke( 3, dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5))
            {
                drieGelijke = true;

                if (gegooideDrieGelijke < 1)
                {
                    int optel = dobbelsteen1 + dobbelsteen2 + dobbelsteen3 + dobbelsteen4 + dobbelsteen5;
                    score += optel;
                    rondeScore += optel;
                    waarschuwingen.Text = "Drie Gelijke";
                    scoreTekst.Text = Convert.ToString(score);
                    rondeScoreTekst.Text = Convert.ToString(rondeScore);

                    gegooideDrieGelijke++;
                    drieGelijkeTekst.Text = Convert.ToString(rondeScore);
                }
                else
                {
                    waarschuwingen.Text = "Je hebt al Drie Gelijke gegooid";
                }
            }
            else
            {
                drieGelijke = false;
            }
        }
        private void VierGelijke()
        {
            if (IsGelijke(4, dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5))
            {
                vierGelijke = true;
                if (gegooideVierGelijke < 1)
                {
                    int optel = dobbelsteen1 + dobbelsteen2 + dobbelsteen3 + dobbelsteen4 + dobbelsteen5;
                    score += optel;
                    rondeScore += optel;
                    waarschuwingen.Text = "Vier Gelijke";
                    scoreTekst.Text = Convert.ToString(score);
                    rondeScoreTekst.Text = Convert.ToString(rondeScore);

                    gegooideVierGelijke++;
                    vierGelijkeTekst.Text = Convert.ToString(rondeScore);
                }
                else
                {
                    waarschuwingen.Text = "Je hebt al Vier Gelijke gegooid";
                }
            }
            else
            {
                vierGelijke = false;
            }
        }
        private void Yahtzee()
        {
            int[] dobbelstenen = { dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5 };
            //Yahtzee
            if (dobbelstenen[0] == dobbelstenen[1] && dobbelstenen[1] == dobbelstenen[2] && dobbelstenen[2] == dobbelstenen[3] && dobbelstenen[3] == dobbelstenen[4]
                && !groteStraat && !kleineStraat)
            {
                score += 50;
                rondeScore += 50;
                scoreTekst.Text = Convert.ToString(score);
                rondeScoreTekst.Text = Convert.ToString(rondeScore);
                waarschuwingen.Text = "YATHZEE!";

                gegooideYahtzee++;
                yahtzeeTekst.Text += rondeScore;
                yahtzeeGegooid = true;
            }
            else
            {
                yahtzeeGegooid = false;
            }
        }
        private void Kans()
        {
            int[] dobbelstenen = { dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5 };
            bool FullHouse = (dobbelstenen.Distinct().Count() == 2) &&
                                dobbelstenen.GroupBy(x => x).Any(g => g.Count() == 2);//Source: https://stackoverflow.com/questions/59820298/yahtzee-game-full-house

            //Chance
            if (rondeScore < 1 && !drieGelijke && !vierGelijke && !FullHouse && !kleineStraat && !groteStraat)
            {
                if (gegooideKans < 1)
                {
                    int optel = dobbelstenen[0] + dobbelstenen[1] + dobbelstenen[2] + dobbelstenen[3] + dobbelstenen[4];
                    score += optel;
                    rondeScore += optel;

                    scoreTekst.Text = Convert.ToString(score); //Score Text updating
                    rondeScoreTekst.Text = Convert.ToString(rondeScore); //Round Score Text update
                    waarschuwingen.Text = "Kans"; //Warnings Set text to "Opportunity"

                    gegooideKans++; //1 added to the chance
                    kansTekst.Text += rondeScore;
                }
                else
                {
                    waarschuwingen.Text = "Je hebt al Kans gegooid";
                }
            }
        }

        private void Punten()
        {
            int[] dobbelstenen = { dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5 };
            bool FullHouse = (dobbelstenen.Distinct().Count() == 2) &&
                    dobbelstenen.GroupBy(x => x).Any(g => g.Count() == 2);//Source: https://stackoverflow.com/questions/59820298/yahtzee-game-full-house

            /*Three equal: The score is the total of all eyes, if there are at least 3 dice with the same number of eyes.
              Four equal: The score is the total of all eyes, if there are at least 4 dice with the same number of eyes.
              Small street: 30 points for 4 consecutive eyes.
              Large street: 40 points for 5 consecutive eyes.
              Full House: 25 points for 3 equal and one pair.
              Chance: The score is the total number of eyes of all dice.
              Yahtzee: 50 points if all dice have the same number of eyes.*/

            //Call functions
            Straten();
            if (!groteStraat && !kleineStraat)
            {
                Yahtzee();
                if (!yahtzeeGegooid)
                {
                    VierGelijke();
                    if (!vierGelijke)
                    {
                        if (!FullHouse)
                        {
                            DrieGelijke();
                            if (!drieGelijke)
                                Kans();
                        }
                        else
                        {
                            //Full House
                            if (gegooideFullHouse < 1)
                            {
                                score += 25;
                                rondeScore += 25;
                                waarschuwingen.Text = "Full House";
                                scoreTekst.Text = Convert.ToString(score);
                                rondeScoreTekst.Text = Convert.ToString(rondeScore);

                                gegooideFullHouse++;
                                fullHouseTekst.Text = Convert.ToString(rondeScore);
                            }
                            else
                            {
                                waarschuwingen.Text = "Je hebt al Full House gegooid";
                            }
                        }
                    }
                }
            }

            volgendeBeurt.Opacity = 1;
            volgendeBeurt.IsEnabled = true;

            gemiddeldTekst.Text = Convert.ToString(score / beurt); //Show the total average

            SpelAfgelopen();
            KiesOgenKnoppen();
        }
        private void StopKnoppen()
        {
            //Reset the "Hold" buttons
            if (stopKnoppen != true)
            {
                dobbelVast1Knop.Opacity = 1; dobbelVast1Knop.IsEnabled = true;
                dobbelVast2Knop.Opacity = 1; dobbelVast2Knop.IsEnabled = true;
                dobbelVast3Knop.Opacity = 1; dobbelVast3Knop.IsEnabled = true;
                dobbelVast4Knop.Opacity = 1; dobbelVast4Knop.IsEnabled = true;
                dobbelVast5Knop.Opacity = 1; dobbelVast5Knop.IsEnabled = true;

                stopKnoppen = true;
            }
        }
        /*private void Choose (int [] dice, Button button)
        {
            int count = 0;
            while (count <6)
            {
                for (int i = 0; i <5; i ++)
                {
                    if (dice [count] == ​​i)
                    {
                        button.Opacity = 1;
                        knop.IsEnabled = true;
                    }
                }
                count ++;
            }
        }*/
        private void KiesOgenKnoppen()
        {
            ResetSelectie();
            int[] dobbelstenen = { dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5 };

            if (dobbelsteen1 == 1 || dobbelsteen2 == 1 || dobbelsteen3 == 1 || dobbelsteen4 == 1 || dobbelsteen5 == 1)
            {
                Selecteer1Enen.Opacity = 1;
                Selecteer1Enen.IsEnabled = true;
            }
            if (dobbelsteen1 == 2 || dobbelsteen2 == 2 || dobbelsteen3 == 2 || dobbelsteen4 == 2 || dobbelsteen5 == 2)
            {
                Selecteer2Tweeen.Opacity = 1;
                Selecteer2Tweeen.IsEnabled = true;
            }
            if (dobbelsteen1 == 3 || dobbelsteen2 == 3 || dobbelsteen3 == 3 || dobbelsteen4 == 3 || dobbelsteen5 == 3)
            {
                Selecteer3Drieen.Opacity = 1;
                Selecteer3Drieen.IsEnabled = true;
            }
            if (dobbelsteen1 == 4 || dobbelsteen2 == 4 || dobbelsteen3 == 4 || dobbelsteen4 == 4 || dobbelsteen5 == 4)
            {
                Selecteer4Vieren.Opacity = 1;
                Selecteer4Vieren.IsEnabled = true;
            }
            if (dobbelsteen1 == 5 || dobbelsteen2 == 5 || dobbelsteen3 == 5 || dobbelsteen4 == 5 || dobbelsteen5 == 5)
            {
                Selecteer5Vijven.Opacity = 1;
                Selecteer5Vijven.IsEnabled = true;
            }
            if (dobbelsteen1 == 6 || dobbelsteen2 == 6 || dobbelsteen3 == 6 || dobbelsteen4 == 6 || dobbelsteen5 == 6)
            {
                Selecteer6Zessen.Opacity = 1;
                Selecteer6Zessen.IsEnabled = true;
            }
        }
        private void ResetSelectie()
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
        private void VolgendeBeurtKlik(object sender, RoutedEventArgs e)
        {
            if (yahtzeeGegooid != true)
            {
                rondeScore = 0;
                beurt += 1;
                rondeScoreTekst.Text = "0";

                stopKnoppen = false;

                alGestoptDobbelsteen1 = false;
                alGestoptDobbelsteen2 = false;
                alGestoptDobbelsteen3 = false;
                alGestoptDobbelsteen4 = false;
                alGestoptDobbelsteen5 = false;

                kleineStraat = false;
                groteStraat = false;
                drieGelijke = false;
                vierGelijke = false;

                aantalGooien = 0;

                dobbelsteen1 = 0;
                dobbelsteen2 = 0;
                dobbelsteen3 = 0;
                dobbelsteen4 = 0;
                dobbelsteen5 = 0;

                rollen.IsEnabled = true;
                rollen.Opacity = 1;

                volgendeBeurt.IsEnabled = false;
                volgendeBeurt.Opacity = 0;
            }
        }

        private void Spelregels_Click(object sender, RoutedEventArgs e)
        {
            Window1 sw = new Window1();
            sw.Show();
        }

        private void SpelAfgelopen()
        {
            if (yahtzeeGegooid == true)
            {
                volgendeBeurt.IsEnabled = false;
                volgendeBeurt.Opacity = 0;

                waarschuwingen.Text += " | Spel Afgelopen";
            }
        }

        private void NieuwSpel(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        }
    }
}