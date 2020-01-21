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

        public bool kleineStraat = false;
        public bool groteStraat = false;
        public bool drieGelijke = false;
        public bool vierGelijke = false;
        

        public void Rollen_Click(object sender, RoutedEventArgs e)
        {
            waarschuwingen.Text = "Aan het gooien...";

            RandomGetallen(); //RandomGetallen functie aanroepen

            StopKnoppen();
            /*SoundPlayer sd = new SoundPlayer();
            sd.SoundLocation = Server.MapPath("~/sounds/File.wav");
            sd.Play();*/

            if (aantalGooien < 3) //Zorgt ervoor dat er niet vaker dan 3 keer kan worden gegooid
            {
                //Als er op de stop knop is geklikt van een dobbelsteen moet hij het getal niet meer veranderen
                if (alGestoptDobbelsteen1 != true)
                {
                    switch (dobbelsteen1)
                    {
                        case 1:
                            een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/XJKR2Xd/een.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 2:
                            een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/hmPLq6m/twee.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 3:
                            een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/1rQXN5Q/drie.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 4:
                            een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/frQ4DQq/vier.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 5:
                            een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/cXJDkc0/vijf.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 6:
                            een.Source = new BitmapImage(new Uri(@"https://i.ibb.co/DbymGG4/zes.png", UriKind.RelativeOrAbsolute));
                            break;
                    }
                }
                if (alGestoptDobbelsteen2 != true)
                {
                    switch (dobbelsteen2)
                    {
                        case 1:
                            twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/XJKR2Xd/een.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 2:
                            twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/hmPLq6m/twee.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 3:
                            twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/1rQXN5Q/drie.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 4:
                            twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/frQ4DQq/vier.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 5:
                            twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/cXJDkc0/vijf.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 6:
                            twee.Source = new BitmapImage(new Uri(@"https://i.ibb.co/DbymGG4/zes.png", UriKind.RelativeOrAbsolute));
                            break;
                    }
                }
                if (alGestoptDobbelsteen3 != true)
                {
                    switch (dobbelsteen3)
                    {
                        case 1:
                            drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/XJKR2Xd/een.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 2:
                            drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/hmPLq6m/twee.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 3:
                            drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/1rQXN5Q/drie.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 4:
                            drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/frQ4DQq/vier.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 5:
                            drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/cXJDkc0/vijf.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 6:
                            drie.Source = new BitmapImage(new Uri(@"https://i.ibb.co/DbymGG4/zes.png", UriKind.RelativeOrAbsolute));
                            break;
                    }
                }
                if (alGestoptDobbelsteen4 != true)
                {
                    switch (dobbelsteen4)
                    {
                        case 1:
                            vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/XJKR2Xd/een.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 2:
                            vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/hmPLq6m/twee.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 3:
                            vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/1rQXN5Q/drie.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 4:
                            vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/frQ4DQq/vier.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 5:
                            vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/cXJDkc0/vijf.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 6:
                            vier.Source = new BitmapImage(new Uri(@"https://i.ibb.co/DbymGG4/zes.png", UriKind.RelativeOrAbsolute));
                            break;
                    }
                }
                if (alGestoptDobbelsteen5 != true)
                {
                    switch (dobbelsteen5)
                    {
                        case 1:
                            vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/XJKR2Xd/een.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 2:
                            vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/hmPLq6m/twee.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 3:
                            vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/1rQXN5Q/drie.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 4:
                            vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/frQ4DQq/vier.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 5:
                            vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/cXJDkc0/vijf.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 6:
                            vijf.Source = new BitmapImage(new Uri(@"https://i.ibb.co/DbymGG4/zes.png", UriKind.RelativeOrAbsolute));
                            break;
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
                if (!alGestoptDobbelsteen1)
                {
                    dobbelsteen1 = rnd.Next(1, 7);
                }
                if (!alGestoptDobbelsteen2)
                {
                    dobbelsteen2 = rnd.Next(1, 7);
                }
                if (!alGestoptDobbelsteen3)
                {
                    dobbelsteen3 = rnd.Next(1, 7);
                }
                if (!alGestoptDobbelsteen4)
                {
                    dobbelsteen4 = rnd.Next(1, 7);
                }
                if (!alGestoptDobbelsteen5)
                {
                    dobbelsteen5 = rnd.Next(1, 7);
                }
            }
        }
        private void DobbelVast1Klik(object sender, RoutedEventArgs e)
        {
            if (alGestoptDobbelsteen1 != true) //Zorgt ervoor dat de code niet wordt uitgevoerd als er op de stop knop is geklikt
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
                //Dobbelstenen stoppen
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
            //Kleine Straat 
            if (Array.Exists(dobbelstenen, element => element == 1) && Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4)
                || Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5)
                || Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5) && Array.Exists(dobbelstenen, element => element == 6))
            {
                score += 30;
                rondeScore += 30;

                //Grote Straat
                if (Array.Exists(dobbelstenen, element => element == 1) && Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5)
                || Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5) && Array.Exists(dobbelstenen, element => element == 6))
                {
                    score += 10;
                    rondeScore += 10;

                    waarschuwingen.Text = "Grote Straat";
                    gegooideGroteStraat++;
                    scoreTekst.Text = Convert.ToString(score);
                    rondeScoreTekst.Text = Convert.ToString(rondeScore);
                    groteStraatTekst.Text += rondeScore;

                    kleineStraat = false;
                    groteStraat = true;
                }
                else
                {
                    waarschuwingen.Text = "Kleine Straat";
                    gegooideKleineStraat++;
                    scoreTekst.Text = Convert.ToString(score);
                    rondeScoreTekst.Text = Convert.ToString(rondeScore);
                    kleineStraatTekst.Text += rondeScore;

                    groteStraat = false;
                    kleineStraat = true;
                }
            }
        }
        private void Gelijken()
        {
            int[] dobbelstenen = { dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5 };

            //Drie Gelijke
            for (int i = 0; i <= 6; i++)
            {
                int tellen = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (dobbelstenen[j] == i)
                    {
                        tellen++;
                    }
                    if (tellen > 2)
                    {
                        if (gegooideDrieGelijke < 1)
                        {
                            drieGelijke = true;

                            int optel = dobbelsteen1 + dobbelsteen2 + dobbelsteen3 + dobbelsteen4 + dobbelsteen5;
                            score += optel;
                            rondeScore += optel;
                            waarschuwingen.Text = "Drie Gelijke";
                            scoreTekst.Text = Convert.ToString(score);
                            rondeScoreTekst.Text = Convert.ToString(rondeScore);

                            gegooideDrieGelijke++;
                            drieGelijkeTekst.Text += rondeScore;
                        }
                        else
                        {
                            waarschuwingen.Text = "Je hebt al Drie Gelijke gegooid";
                        }
                    }
                    //Vier Gelijke
                    else if (tellen > 3)
                    {
                        if (gegooideVierGelijke < 1)
                        {
                            vierGelijke = true;

                            int optel = dobbelsteen1 + dobbelsteen2 + dobbelsteen3 + dobbelsteen4 + dobbelsteen5;
                            score += optel;
                            rondeScore += optel;
                            waarschuwingen.Text = "Drie Gelijke";
                            scoreTekst.Text = Convert.ToString(score);
                            rondeScoreTekst.Text = Convert.ToString(rondeScore);

                            gegooideVierGelijke++;
                            vierGelijkeTekst.Text += rondeScore;
                        }
                        else
                        {
                            waarschuwingen.Text = "Je hebt al Vier Gelijke gegooid";
                        }
                    }
                }
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
        }

        private void Punten()
        {
            int[] dobbelstenen = { dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5 };
            bool FullHouse = (dobbelstenen.Distinct().Count() == 2) &&
                                dobbelstenen.GroupBy(x => x).Any(g => g.Count() == 2);//Source: https://stackoverflow.com/questions/59820298/yahtzee-game-full-house

            /*Drie gelijke: De score is het totaal van alle ogen, als er minstens 3 dobbelstenen met hetzelfde aantal ogen zijn.
              Vier gelijke: De score is het totaal van alle ogen, als er minstens 4 dobbelstenen met hetzelfde aantal ogen zijn.
              Kleine straat: 30 punten voor 4 opeenvolgende ogenaantallen.
              Grote straat: 40 punten voor 5 opeenvolgende ogenaantallen.
              Full House: 25 punten voor 3 gelijke en één paar.
              Kans: De score is het totaal aantal ogen van alle dobbelstenen.
              Yahtzee: 50 punten als alle dobbelstenen hetzelfde aantal ogen hebben.*/

            //Functies aanroepen
            Yahtzee();
            if (!yahtzeeGegooid)
            {
                Straten();
                if (!kleineStraat && !groteStraat)
                {
                    if (!FullHouse)
                    {
                        Gelijken();
                    }
                    else
                    {
                        if (gegooideFullHouse < 1)
                        {
                            //Full House
                            score += 25;
                            rondeScore += 25;
                            waarschuwingen.Text = "Full House";
                            scoreTekst.Text = Convert.ToString(score);
                            rondeScoreTekst.Text = Convert.ToString(rondeScore);

                            gegooideFullHouse++;
                            fullHouseTekst.Text += rondeScore;
                        }
                        else
                        {
                            waarschuwingen.Text = "Je hebt al Full House gegooid";
                        }
                    }
                }
            }

            //Kans
            if (rondeScore < 1 && !drieGelijke && !vierGelijke && !FullHouse && !kleineStraat && !groteStraat)
            {
                if (gegooideKans < 1)
                {
                    int optel = dobbelstenen[0] + dobbelstenen[1] + dobbelstenen[2] + dobbelstenen[3] + dobbelstenen[4];
                    score += optel;
                    rondeScore += optel;

                    scoreTekst.Text = Convert.ToString(score); //Score Tekst bijwerken
                    rondeScoreTekst.Text = Convert.ToString(rondeScore); //Ronde Score Tekst bijwerken
                    waarschuwingen.Text = "Kans"; //Waarschuwingen Tekst naar "Kans" zetten

                    gegooideKans++; //1 bij gegooideKans erbij
                    kansTekst.Text += rondeScore;
                }
                else
                {
                    waarschuwingen.Text = "Je hebt al Kans gegooid";
                }
            }

            volgendeBeurt.Opacity = 1;
            volgendeBeurt.IsEnabled = true;

            gemiddeldTekst.Text = Convert.ToString(score / beurt); //Laat het totale gemiddelde zien

            SpelAfgelopen();
        }
        private void StopKnoppen()
        {
            //Resetten de "Vasthoud" knoppen
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
        private void KiesOgenKnoppen()
        {
            ResetSelectie();
            if (dobbelsteen1 == 1 || dobbelsteen2 == 1 || dobbelsteen3 == 1 || dobbelsteen4 == 1 || dobbelsteen5 == 1)
                Selecteer1Enen.Opacity = 1;
            if (dobbelsteen1 == 2 || dobbelsteen2 == 2 || dobbelsteen3 == 2 || dobbelsteen4 == 2 || dobbelsteen5 == 2)
                Selecteer2Tweeen.Opacity = 1;
            if (dobbelsteen1 == 3 || dobbelsteen2 == 3 || dobbelsteen3 == 3 || dobbelsteen4 == 3 || dobbelsteen5 == 3)
                Selecteer3Drieen.Opacity = 1;
            if (dobbelsteen1 == 4 || dobbelsteen2 == 4 || dobbelsteen3 == 4 || dobbelsteen4 == 4 || dobbelsteen5 == 4)
                Selecteer4Vieren.Opacity = 1;
            if (dobbelsteen1 == 5 || dobbelsteen2 == 5 || dobbelsteen3 == 5 || dobbelsteen4 == 5 || dobbelsteen5 == 5)
                Selecteer5Vijven.Opacity = 1;
            if (dobbelsteen1 == 6 || dobbelsteen2 == 6 || dobbelsteen3 == 6 || dobbelsteen4 == 6 || dobbelsteen5 == 6)
                Selecteer6Zessen.Opacity = 1;
        }
        private void ResetSelectie()
        {
            Selecteer1Enen.Opacity = 0;
            Selecteer2Tweeen.Opacity = 0;
            Selecteer3Drieen.Opacity = 0;
            Selecteer4Vieren.Opacity = 0;
            Selecteer5Vijven.Opacity = 0;
            Selecteer6Zessen.Opacity = 0;
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