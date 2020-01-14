using System;
using System.Collections.Generic;
using System.Linq;
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
        public int alRandom = 0;
        public int aantalGooien = 0;
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
        int score;

        private void rollen_Click(object sender, RoutedEventArgs e)
        {
            RandomGetallen(); //RandomGetallen functie aanroepen

            if (aantalGooien < 3) //Zorgt ervoor dat er niet vaker dan 3 keer kan worden gegooid
            {
                //Als er op de stop knop is geklikt van een dobbelsteen moet hij het getal niet meer veranderen
                if (alGestoptDobbelsteen1 != true)
                {
                    dobbeltt1.Text = Convert.ToString(dobbelsteen1);
                }
                if (alGestoptDobbelsteen2 != true)
                {
                    dobbeltt2.Text = Convert.ToString(dobbelsteen2);
                }
                if (alGestoptDobbelsteen3 != true)
                {
                    dobbeltt3.Text = Convert.ToString(dobbelsteen3);
                }
                if (alGestoptDobbelsteen4 != true)
                {
                    dobbeltt4.Text = Convert.ToString(dobbelsteen4);
                }
                if (alGestoptDobbelsteen5 != true)
                {
                    dobbeltt5.Text = Convert.ToString(dobbelsteen5);
                }
                aantalGooien +=1;
                AllesGestopt();
            }
            else
            {
                waarschuwingen.Text = "Je hebt al 3 keer gegooid"; //Als er 3 keer is gegooid en de speler wil nog een keer gooien komt dit er te staan
            }
        }
        private void RandomGetallen()
        {
            if(alRandom < 3) //Zorgt ervoor dat de dobbelstenen maximaal 3 keer een random getal krijgen
            {
                //Random getal kiezen voor elke dobbelsteen
                dobbelsteen1 = rnd.Next(1, 7);
                dobbelsteen2 = rnd.Next(1, 7);
                dobbelsteen3 = rnd.Next(1, 7);
                dobbelsteen4 = rnd.Next(1, 7);
                dobbelsteen5 = rnd.Next(1, 7);
                alRandom += 1;
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
                Punten();
            }
            else if (aantalGooien > 3)
            {
                //Dobbelstenen stoppen
                dobbeltt1.IsEnabled = false;
                dobbeltt2.IsEnabled = false;
                dobbeltt3.IsEnabled = false;
                dobbeltt4.IsEnabled = false;
                dobbeltt5.IsEnabled = false;

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
            int[] dobbelstenen = {dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4, dobbelsteen5};
            int totaalScore = dobbelsteen1 + dobbelsteen2 + dobbelsteen3 + dobbelsteen4 + dobbelsteen5;

            /*Drie gelijke: De score is het totaal van alle ogen, als er minstens 3 dobbelstenen met hetzelfde aantal ogen zijn.
              Vier gelijke: De score is het totaal van alle ogen, als er minstens 4 dobbelstenen met hetzelfde aantal ogen zijn.
              Kleine straat: 30 punten voor 4 opeenvolgende ogenaantallen.
              Grote straat: 40 punten voor 5 opeenvolgende ogenaantallen.
              Full House: 25 punten voor 3 gelijke en één paar.
              Kans: De score is het totaal aantal ogen van alle dobbelstenen.
              Yahtzee: 50 punten als alle dobbelstenen hetzelfde aantal ogen hebben.*/

            //Kleine Straat
            if (Array.Exists(dobbelstenen, element => element == 1) && Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4)
                || Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5)
                || Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5) && Array.Exists(dobbelstenen, element => element == 6))
            {
                score += 30;
                scoreTekst.Text = Convert.ToString(score);
            }

            //Grote Straat
            if (Array.Exists(dobbelstenen, element => element == 1) && Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5)
                || Array.Exists(dobbelstenen, element => element == 2) && Array.Exists(dobbelstenen, element => element == 3) && Array.Exists(dobbelstenen, element => element == 4) && Array.Exists(dobbelstenen, element => element == 5) && Array.Exists(dobbelstenen, element => element == 6))
            {
                score += 40;
                scoreTekst.Text = Convert.ToString(score);
            }

            //Yahtzee
            if (dobbelstenen[0] == dobbelstenen[1])
            {
                if(dobbelstenen[1] == dobbelstenen[2])
                {
                    if(dobbelstenen[2] == dobbelstenen[3])
                    {
                        if (dobbelstenen[3] == dobbelstenen[4])
                        {
                            if (dobbelstenen[4] == dobbelstenen[5])
                            {
                                score += 50;
                                scoreTekst.Text = Convert.ToString(score);
                            }
                        }
                    }
                }
            }
        }
    }
}