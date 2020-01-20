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
        //Public variabelen
        public Random rnd = new Random();
        public int aantalGooien = 0;
        //Beurt
        public int beurt = 1; //Moet 1 zijn omdat hij bij beurt 1 start niet beurt 0!!
        //De dobbelstenen
        public int dobbelsteen1 = 0;
        public int dobbelsteen2 = 0;
        public int dobbelsteen3 = 0;
        public int dobbelsteen4 = 0;
        public int dobbelsteen5 = 0;
        //Gestopte dobbelstenen
        public bool alGestoptDobbelsteen1 = false;
        public bool alGestoptDobbelsteen2 = false;
        public bool alGestoptDobbelsteen3 = false;
        public bool alGestoptDobbelsteen4 = false;
        public bool alGestoptDobbelsteen5 = false;
        //Score van de speler
        public int score;
        public int rondeScore;
        public bool yahtzeeGegooid = false; //Spel stopt wanneer er Yahtzee is gegooid
        public bool stopKnoppen = false;
        //Wat heeft de speler gegooid
        public int gegooideDrieGelijke = 0;
        public int gegooideVierGelijke = 0;
        public int gegooideKans = 0;
        public int gegooideFullHouse = 0;
        public int gegooideKleineStraat = 0;
        public int gegooideGroteStraat = 0;
        public int gegooideYahtzee = 0;
        public int getal;

        public void Rollen_Click(object sender, RoutedEventArgs e)
        {
            RandomGetallen(); //RandomGetallen functie aanroepen

            StopKnoppen();
            SoundPlayer sd = new SoundPlayer();
            sd.SoundLocation = Server.MapPath("~/sounds/File.wav");
            sd.Play();

            if (aantalGooien < 3) //Zorgt ervoor dat er niet vaker dan 3 keer kan worden gegooid
            {
                //Als er op de stop knop is geklikt van een dobbelsteen moet hij het getal niet meer veranderen
                if (alGestoptDobbelsteen1 != true)
                {
                    dobbeltt1.Text = Convert.ToString(dobbelsteen1);
                    if (dobbeltt1.Text == "1")
                    {
                        een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/XJKR2Xd/een.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt1.Text == "2")
                    {
                        een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/hmPLq6m/twee.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt1.Text == "3")
                    {
                        een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/1rQXN5Q/drie.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt1.Text == "4")
                    {
                        een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/frQ4DQq/vier.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt1.Text == "5")
                    {
                        een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/cXJDkc0/vijf.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt1.Text == "6")
                    {
                        een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/DbymGG4/zes.png", UriKind.RelativeOrAbsolute));
                    }
                }
                if (alGestoptDobbelsteen2 != true)
                {
                    dobbeltt2.Text = Convert.ToString(dobbelsteen2);
                    if (dobbeltt2.Text == "1")
                    {
                        twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/XJKR2Xd/een.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt2.Text == "2")
                    {
                        twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/hmPLq6m/twee.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt2.Text == "3")
                    {
                        twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/1rQXN5Q/drie.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt2.Text == "4")
                    {
                        twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/frQ4DQq/vier.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt2.Text == "5")
                    {
                        twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/cXJDkc0/vijf.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt2.Text == "6")
                    {
                        twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/DbymGG4/zes.png", UriKind.RelativeOrAbsolute));
                    }
                }
                if (alGestoptDobbelsteen3 != true)
                {
                    dobbeltt3.Text = Convert.ToString(dobbelsteen3);
                    if (dobbeltt3.Text == "1")
                    {
                        drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/XJKR2Xd/een.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt3.Text == "2")
                    {
                        drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/hmPLq6m/twee.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt3.Text == "3")
                    {
                        drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/1rQXN5Q/drie.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt3.Text == "4")
                    {
                        drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/frQ4DQq/vier.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt3.Text == "5")
                    {
                        drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/cXJDkc0/vijf.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt3.Text == "6")
                    {
                        drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/DbymGG4/zes.png", UriKind.RelativeOrAbsolute));
                    }
                }
                if (alGestoptDobbelsteen4 != true)
                {
                    dobbeltt4.Text = Convert.ToString(dobbelsteen4);
                    if (dobbeltt4.Text == "1")
                    {
                        vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/XJKR2Xd/een.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt4.Text == "2")
                    {
                        vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/hmPLq6m/twee.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt4.Text == "3")
                    {
                        vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/1rQXN5Q/drie.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt4.Text == "4")
                    {
                        vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/frQ4DQq/vier.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt4.Text == "5")
                    {
                        vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/cXJDkc0/vijf.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt4.Text == "6")
                    {
                        vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/DbymGG4/zes.png", UriKind.RelativeOrAbsolute));
                    }
                }
                if (alGestoptDobbelsteen5 != true)
                {
                    dobbeltt5.Text = Convert.ToString(dobbelsteen5);
                    if (dobbeltt5.Text == "1")
                    {
                        vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/XJKR2Xd/een.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt5.Text == "2")
                    {
                        vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/hmPLq6m/twee.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt5.Text == "3")
                    {
                        vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/1rQXN5Q/drie.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt5.Text == "4")
                    {
                        vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/frQ4DQq/vier.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt5.Text == "5")
                    {
                        vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/cXJDkc0/vijf.png", UriKind.RelativeOrAbsolute));
                    }
                    if (dobbeltt5.Text == "6")
                    {
                        vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/DbymGG4/zes.png", UriKind.RelativeOrAbsolute));
                    }
                }
                aantalGooien += 1;
                AllesGestopt();
            }
            else
            {
                waarschuwingen.Text = "Je hebt al 3 keer gegooid"; //Als er 3 keer is gegooid en de speler wil nog een keer gooien komt dit er te staan
            }
        }
        private void RandomGetallen()
        {
            if (aantalGooien < 3) //Zorgt ervoor dat de dobbelstenen maximaal 3 keer een random getal krijgen
            {
                //Random getal kiezen voor elke dobbelsteen
                dobbelsteen1 = rnd.Next(1, 7);
                dobbelsteen2 = rnd.Next(1, 7);
                dobbelsteen3 = rnd.Next(1, 7);
                dobbelsteen4 = rnd.Next(1, 7);
                dobbelsteen5 = rnd.Next(1, 7);
            }
        }
        private void DobbelVast1Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen1 != true) //Zorgt ervoor dat de code niet wordt uitgevoerd als er op de stop knop is geklikt
            {
                string vast = Convert.ToString(dobbelsteen1);
                dobbeltt1.Text = vast;
                dobbeltt1.IsEnabled = false;
                alGestoptDobbelsteen1 = true;
                dobbelVast1Knop.Opacity = 0;
                AllesGestopt();
            }
        }
        private void DobbelVast2Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen2 != true)
            {
                string vast = Convert.ToString(dobbelsteen2);
                dobbeltt2.Text = vast;
                dobbeltt2.IsEnabled = false;
                alGestoptDobbelsteen2 = true;
                dobbelVast2Knop.Opacity = 0;
                AllesGestopt();
            }
        }
        private void DobbelVast3Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen3 != true)
            {
                string vast = Convert.ToString(dobbelsteen3);
                dobbeltt3.Text = vast;
                dobbeltt3.IsEnabled = false;
                alGestoptDobbelsteen3 = true;
                dobbelVast3Knop.Opacity = 0;
                AllesGestopt();
            }
        }
        private void DobbelVast4Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen4 != true)
            {
                string vast = Convert.ToString(dobbelsteen4);
                dobbeltt4.Text = vast;
                dobbeltt4.IsEnabled = false;
                alGestoptDobbelsteen4 = true;
                dobbelVast4Knop.Opacity = 0;
                AllesGestopt();
            }
        }
        private void DobbelVast5Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen5 != true)
            {
                string vast = Convert.ToString(dobbelsteen5);
                dobbeltt5.Text = vast;
                dobbeltt5.IsEnabled = false;
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
                //Dobbelstenen stoppen
                dobbelsteen1 = 0;
                dobbelsteen2 = 0;
                dobbelsteen3 = 0;
                dobbelsteen4 = 0;
                dobbelsteen5 = 0;

                dobbeltt1.IsEnabled = false;
                dobbeltt2.IsEnabled = false;
                dobbeltt3.IsEnabled = false;
                dobbeltt4.IsEnabled = false;
                dobbeltt5.IsEnabled = false;

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
        private void Punten()
        {
            dobbelsteen1 = Convert.ToInt32(dobbeltt1.Text);
            dobbelsteen2 = Convert.ToInt32(dobbeltt2.Text);
            dobbelsteen3 = Convert.ToInt32(dobbeltt3.Text);
            dobbelsteen4 = Convert.ToInt32(dobbeltt4.Text);
            dobbelsteen5 = Convert.ToInt32(dobbeltt5.Text);
            int[] dobbelstenen = { dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5 };
            int totaalScore = dobbelsteen1 + dobbelsteen2 + dobbelsteen3 + dobbelsteen4 + dobbelsteen5;
            bool drieGelijke = false;
            bool vierGelijke = false;
            bool Fullhouse = false;

            /*Drie gelijke: De score is het totaal van alle ogen, als er minstens 3 dobbelstenen met hetzelfde aantal ogen zijn.
              Vier gelijke: De score is het totaal van alle ogen, als er minstens 4 dobbelstenen met hetzelfde aantal ogen zijn.
              Kleine straat: 30 punten voor 4 opeenvolgende ogenaantallen.
              Grote straat: 40 punten voor 5 opeenvolgende ogenaantallen.
              Full House: 25 punten voor 3 gelijke en één paar.
              Kans: De score is het totaal aantal ogen van alle dobbelstenen.
              Yahtzee: 50 punten als alle dobbelstenen hetzelfde aantal ogen hebben.*/

            //Check voor FullHouse
            int[] FullhouseCheck = { dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5 }; //Een extra array voor het checken van alle getallen
            int[] FullHouseDubbelVerwijderen = FullhouseCheck.Distinct().ToArray(); //Verwijderen van duplicaten in de array waaronder de uitkomst 2 moet zijn voor fullhouse

            //Kleine Straat
            if (Array.Exists(dobbelstenen, element => element == 1) && Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4)
                || Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5)
                || Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5) && Array.Exists(dobbelstenen, element => element == 6))
            {
                score += 30;
                rondeScore += 30;

                //Grote straat
                if (Array.Exists(dobbelstenen, element => element == 1) && Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5)
                || Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5) && Array.Exists(dobbelstenen, element => element == 6))
                {
                    score += 10;
                    rondeScore += 10;
                    waarschuwingen.Text = "Grote Straat!";
                    gegooideGroteStraat++;
                }
                else
                {
                    waarschuwingen.Text = "Kleine Straat";
                    gegooideKleineStraat++;
                }
                scoreTekst.Text = Convert.ToString(score);
                rondeScoreTekst.Text = Convert.ToString(rondeScore);
            }

            //Yahtzee
            if (dobbelstenen[0] == dobbelstenen[1] && dobbelstenen[1] == dobbelstenen[2] && dobbelstenen[2] == dobbelstenen[3] && dobbelstenen[3] == dobbelstenen[4])
            {
                score += 50;
                rondeScore += 50;
                scoreTekst.Text = Convert.ToString(score);
                rondeScoreTekst.Text = Convert.ToString(rondeScore);
                waarschuwingen.Text = "YATHZEE!";
                gegooideYahtzee++;
                yahtzeeGegooid = true;
            }
            else
            {
                //Drie Gelijke
                for (int i = 0; i <= 6; i++)
                {
                    int tellen = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (dobbelstenen[j] == i)
                        {
                            tellen++;
                            getal = dobbelstenen[j];
                        }
                        if (tellen == 3)
                        {
                            drieGelijke = true;
                        }
                    }
                }

                if (drieGelijke == true)
                {
                    //Vier gelijke
                    for (int k = 0; k <= 6; k++)
                    {
                        int tellen2 = 0;
                        for (int f = 0; f < 5; f++)
                        {
                            if (dobbelstenen[f] == k)
                            {
                                tellen2++;
                            }
                            if (tellen2 == 4)
                            {
                                drieGelijke = false;
                                vierGelijke = true;
                            }
                        }
                    }
                }
                //FULLHOUSE
                if (FullHouseDubbelVerwijderen == null || FullHouseDubbelVerwijderen.Length == 2) //Als uitkomst op lijn 356 2 is, activeer fullhouse
                {
                    score += 25;
                    rondeScore += 25;
                    waarschuwingen.Text = "Full House";
                    scoreTekst.Text = Convert.ToString(score);
                    rondeScoreTekst.Text = Convert.ToString(rondeScore);
                    gegooideFullHouse++;
                    Fullhouse = true;
                }
                if (drieGelijke == true && Fullhouse == false)
                {
                    int optel = dobbelstenen[0] + dobbelstenen[1] + dobbelstenen[2] + dobbelstenen[3] + dobbelstenen[4];
                    score += optel;
                    rondeScore += optel;
                    waarschuwingen.Text = "Drie Gelijke";
                    scoreTekst.Text = Convert.ToString(score);
                    rondeScoreTekst.Text = Convert.ToString(rondeScore);
                    gegooideDrieGelijke++;
                }
                if (vierGelijke == true)
                {
                    int optel = dobbelstenen[0] + dobbelstenen[1] + dobbelstenen[2] + dobbelstenen[3] + dobbelstenen[4];
                    score += optel;
                    rondeScore += optel;
                    waarschuwingen.Text = "Vier Gelijke";
                    scoreTekst.Text = Convert.ToString(score);
                    rondeScoreTekst.Text = Convert.ToString(rondeScore);
                    gegooideVierGelijke++;
                }
            }

            //Kans
            if (rondeScore == 0 && drieGelijke == false && vierGelijke == false)
            {
                int optel = dobbelstenen[0] + dobbelstenen[1] + dobbelstenen[2] + dobbelstenen[3] + dobbelstenen[4];
                score += optel;
                rondeScore += optel;

                scoreTekst.Text = Convert.ToString(score);
                rondeScoreTekst.Text = Convert.ToString(rondeScore);
                waarschuwingen.Text = "Kans";
                gegooideKans++;
            }

            volgendeBeurt.Opacity = 1;
            volgendeBeurt.IsEnabled = true;

            SpelAfgelopen();
        }
        private void StopKnoppen()
        {
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
        private void VolgendeBeurtKlik(object sender, RoutedEventArgs e)
        {
            if (yahtzeeGegooid != true)
            {
                rondeScore = 0;
                beurt += 1;
                rondeScoreTekst.Text = "0";

                dobbeltt1.IsEnabled = true;
                dobbeltt2.IsEnabled = true;
                dobbeltt3.IsEnabled = true;
                dobbeltt4.IsEnabled = true;
                dobbeltt5.IsEnabled = true;

                stopKnoppen = false;

                alGestoptDobbelsteen1 = false;
                alGestoptDobbelsteen2 = false;
                alGestoptDobbelsteen3 = false;
                alGestoptDobbelsteen4 = false;
                alGestoptDobbelsteen5 = false;

                aantalGooien = 0;

                dobbeltt1.Text = "0";
                dobbeltt2.Text = "0";
                dobbeltt3.Text = "0";
                dobbeltt4.Text = "0";
                dobbeltt5.Text = "0";

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

                waarschuwingen.Text = "Spel Afgelopen";

                /*kansTekst.Text += gegooideKans;
                drieGelijkeTekst.Text += gegooideDrieGelijke;
                vierGelijkeTekst.Text += gegooideVierGelijke;
                fullHouseTekst.Text += gegooideFullHouse;
                kleineStraatTekst.Text += gegooideKleineStraat;
                groteStraatTekst.Text += gegooideGroteStraat;
                yahtzeeTekst.Text += gegooideYahtzee;
                gemiddeldTekst.Text += score / beurt;*/
            }
        }

        private void NieuwSpel(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        }
    }
}