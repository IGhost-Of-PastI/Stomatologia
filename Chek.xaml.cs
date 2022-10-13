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
using System.Windows.Shapes;

namespace Stomatologia
{
    /// <summary>
    /// Логика взаимодействия для Chek.xaml
    /// </summary>
    public partial class Chek : Window
    {
        public Chek(string FIOPac,string FIODoc,string cost, string uslug,int talon)
        {
            InitializeComponent();
            centername.Text = "Стоматологический центр \"Здоровые зубки\"";
            NameOfVisiot.Text = FIOPac;
            NameofTeathDoc.Text = FIODoc;
            Cost.Text = cost;
            Usluga.Text = uslug;
            plata.Text += $"{talon}";
            Datenow.Text = DateTime.Now.ToString();
            PrintDialog p = new PrintDialog();
            if(p.ShowDialog()==true)
            {
                p.PrintVisual(printgrid, "Печать");
            }
        }
    }
}
