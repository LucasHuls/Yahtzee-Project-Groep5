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
        public bool start = false;
        //Beurt
        public int beurt = 1; //Moet 1 zijn omdat hij bij beurt 1 start niet beurt 0!!
        //De dobbelstenen
        public int dobbelsteen1 = 0;
        public int dobbelsteen2 = 0;
        public int dobbelsteen3 = 0;
        public int dobbelsteen4 = 0;
        public int dobbelsteen5 = 0;
        //Score van de speler
        public int score;
        public int rondeScore;
        public bool yahtzeeGegooid = false; //Spel stopt wanneer er Yahtzee is gegooid
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
            Rol();
        }
        private void Rol()
        {

            waarschuwingen.Text = "Aan het gooien...";

            RandomGetallen(); //RandomGetallen functie aanroepen

            string link = @"http://www.110studios.nl/wp-content/uploads/2020/01/";

            if (aantalGooien < 3) //Zorgt ervoor dat er niet vaker dan 3 keer kan worden gegooid
            {
                //Als er op de stop knop is geklikt van een dobbelsteen moet hij het getal niet meer veranderen
                DobbelsteenFoto(dobbelsteen1, een, link);
                DobbelsteenFoto(dobbelsteen2, twee, link);
                DobbelsteenFoto(dobbelsteen3, drie, link);
                DobbelsteenFoto(dobbelsteen4, vier, link);
                DobbelsteenFoto(dobbelsteen5, vijf, link);

                aantalGooien += 1;
                AllesGestopt();
            }
            else
            {
                waarschuwingen.Text = "Je hebt al 3 keer gegooid"; //Als er 3 keer is gegooid en de speler wil nog een keer gooien komt dit er te staan
            }
        }
            
        public void DobbelsteenFoto(int dobbel, Image dobbelsteenFoto, string link)
        {
            dobbelsteenFoto.Source = new BitmapImage(new Uri(link + dobbel + ".png", UriKind.RelativeOrAbsolute));
        }

        private void RandomGetallen()
        {
            if (aantalGooien < 2) //Zorgt ervoor dat de dobbelstenen maximaal 3 keer een random getal krijgen
            {
                //Random getal kiezen voor elke dobbelsteen
                dobbelsteen1 = rnd.Next(1, 7);
                dobbelsteen2 = rnd.Next(1, 7);
                dobbelsteen3 = rnd.Next(1, 7);
                dobbelsteen4 = rnd.Next(1, 7);
                dobbelsteen5 = rnd.Next(1, 7);
            }
        }
        private void AllesGestopt()
        {
            if (aantalGooien < 2)
            {
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
                    groteStraatTekst.Text = Convert.ToString(gegooideGroteStraat);

                    kleineStraat = false;
                    groteStraat = true;
                }
                else
                {
                    waarschuwingen.Text = "Kleine Straat";
                    gegooideKleineStraat++;
                    scoreTekst.Text = Convert.ToString(score);
                    rondeScoreTekst.Text = Convert.ToString(rondeScore);
                    kleineStraatTekst.Text = Convert.ToString(gegooideKleineStraat);

                    groteStraat = false;
                    kleineStraat = true;
                }
            }
        }
        private bool IsGelijke(int vergelijk, int d1, int d2, int d3, int d4, int d5)
        {
            int i = 0;
            int result = 0;

            while (i < 7 && result < vergelijk)
            {
                result = Convert.ToInt32(d1 == i) + Convert.ToInt32(d2 == i) + Convert.ToInt32(d3 == i) + Convert.ToInt32(d4 == i) + Convert.ToInt32(d5 == i);
                i++;
            }
            return (result == vergelijk);
        }

        private void DrieGelijke()
        {
            if (IsGelijke(3, dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5))
            {
                drieGelijke = true;

                int optel = dobbelsteen1 + dobbelsteen2 + dobbelsteen3 + dobbelsteen4 + dobbelsteen5;
                score += optel;
                rondeScore += optel;
                waarschuwingen.Text = "Drie Gelijke";
                scoreTekst.Text = Convert.ToString(score);
                rondeScoreTekst.Text = Convert.ToString(rondeScore);

                gegooideDrieGelijke++;
                drieGelijkeTekst.Text = Convert.ToString(gegooideDrieGelijke);
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

                int optel = dobbelsteen1 + dobbelsteen2 + dobbelsteen3 + dobbelsteen4 + dobbelsteen5;
                score += optel;
                rondeScore += optel;
                waarschuwingen.Text = "Vier Gelijke";
                scoreTekst.Text = Convert.ToString(score);
                rondeScoreTekst.Text = Convert.ToString(rondeScore);

                gegooideVierGelijke++;
                vierGelijkeTekst.Text = Convert.ToString(gegooideVierGelijke);
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
                yahtzeeTekst.Text = Convert.ToString(gegooideYahtzee);
                yahtzeeGegooid = true;
            }
        }

        private void Kans()
        {
            int[] dobbelstenen = { dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5 };
            bool FullHouse = (dobbelstenen.Distinct().Count() == 2) &&
                                dobbelstenen.GroupBy(x => x).Any(g => g.Count() == 2);//Source: https://stackoverflow.com/questions/59820298/yahtzee-game-full-house

            //Kans
            if (rondeScore < 1 && !drieGelijke && !vierGelijke && !FullHouse && !kleineStraat && !groteStraat)
            {
                int optel = dobbelstenen[0] + dobbelstenen[1] + dobbelstenen[2] + dobbelstenen[3] + dobbelstenen[4];
                score += optel;
                rondeScore += optel;

                scoreTekst.Text = Convert.ToString(score); //Score Tekst bijwerken
                rondeScoreTekst.Text = Convert.ToString(rondeScore); //Ronde Score Tekst bijwerken
                waarschuwingen.Text = "Kans"; //Waarschuwingen Tekst naar "Kans" zetten

                gegooideKans++; //1 bij gegooideKans erbij
                kansTekst.Text = Convert.ToString(gegooideKans);
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
                            score += 25;
                            rondeScore += 25;
                            waarschuwingen.Text = "Full House";
                            scoreTekst.Text = Convert.ToString(score);
                            rondeScoreTekst.Text = Convert.ToString(rondeScore);

                            gegooideFullHouse++;
                            fullHouseTekst.Text = Convert.ToString(gegooideFullHouse);
                        }
                    }
                }
            }

            gemiddeldTekst.Text = Convert.ToString(score / beurt); //Laat het totale gemiddelde zien

            SpelAfgelopen();
            VolgendeBeurt();
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
                waarschuwingen.Text += " | Spel Afgelopen";
            }
        }

        private void NieuwSpel(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        }
        private void VolgendeBeurt()
        {
            if (yahtzeeGegooid != true)
            {
                rondeScore = 0;
                beurt += 1;
                rondeScoreTekst.Text = "0";

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
            }
        }

        private void Yahtzee_Loop(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Het kan even duren!");
            while (!yahtzeeGegooid)
            {
                Rol();
            }
        }
    }
}