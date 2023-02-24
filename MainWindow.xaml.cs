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
using System.IO;
using WpfAppNepesseg.Model;

namespace nepesseg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        List<Telepules> telepulesek;   
        public MainWindow()
        {
            InitializeComponent();
            telepulesek = new List<Telepules>();
            StreamReader sr = new StreamReader("Adatok\\kozerdeku_lakossag_2022.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string CSVsor = sr.ReadLine();
                string[] mezok = CSVsor.Split(";");
                Telepules ujTelepules = new Telepules(mezok[2],
                    mezok[3],
                    mezok[4],
                    int.Parse(mezok[5].Replace(" ", "")),
                    int.Parse(mezok[6].Replace(" ", "")));
                telepulesek.Add(ujTelepules);
            }
            sr.Close();
            dgTelepulesek.ItemsSource = telepulesek;
        }
    }
}
