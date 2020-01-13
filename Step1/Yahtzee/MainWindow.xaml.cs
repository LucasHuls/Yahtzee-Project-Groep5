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

        private void rollen_Click(object sender, RoutedEventArgs e)
        {
            int dobbel1 = rnd.Next(1, 6);
            int dobbel2 = rnd.Next(1, 6);
            int dobbel3 = rnd.Next(1, 6);
            int dobbel4 = rnd.Next(1, 6);
            int dobbel5 = rnd.Next(1, 6);
            int[] Scores = { dobbel1, dobbel2, dobbel3, dobbel4, dobbel5 };
            this.dobbeltt1.Text = Convert.ToString(dobbel1);
            this.dobbeltt2.Text = Convert.ToString(dobbel2);
            this.dobbeltt3.Text = Convert.ToString(dobbel3);
            this.dobbeltt4.Text = Convert.ToString(dobbel4);
            this.dobbeltt5.Text = Convert.ToString(dobbel5);
        }
        public Random rnd = new Random();
    }
}
