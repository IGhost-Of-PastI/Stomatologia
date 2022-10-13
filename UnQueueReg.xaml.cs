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
using System.Collections.ObjectModel;


namespace Stomatologia
{
    /// <summary>
    /// Логика взаимодействия для UnQueueReg.xaml
    /// </summary>
    public partial class UnQueueReg : Window
    {
        List<MedVisitor> medvis = WorkWithData.LoadMedVis().ToList();
        List<WorkerFull> workers1 = WorkWithData.LoadData(true).ToList();
        int ID;
        public UnQueueReg(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            Worker.ItemsSource=workers1;
            MedVis.ItemsSource = medvis;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//запись без предварительной записи
        {
            if(MedVis.SelectedItem!=null&&Worker.SelectedItem!=null)
            {
                WorkWithData.WriteTalonUnQueue(ID, (MedVisitor)MedVis.SelectedItem, (WorkerFull)Worker.SelectedItem);
                MessageBox.Show("Записан!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Не выбран врач или пациент!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
