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
    /// Логика взаимодействия для Maketalon.xaml
    /// </summary>
    public partial class Maketalon : Window
    {
        int ID=0;
        DateTime realtime;
        List<WorkerFull> workers1 = WorkWithData.LoadData(true).ToList();
        ObservableCollection<MedVisitor> medvis = WorkWithData.LoadMedVis();
        ОкноРегистратора temp;
        Window1 temp2;
        public Maketalon(int id, ОкноРегистратора a)
        {
            InitializeComponent();
            temp = a;
            ID = id;
            realtime = DateTime.Now;
            textmonth.Text = MonthesNames.GetMonthName(realtime.Month);
            Workers.ItemsSource = workers1;
            Med1.ItemsSource = medvis;
        }
        public Maketalon(int id,Window1  a)
        {
            InitializeComponent();
            temp2 = a;
            ID = id;
            realtime = DateTime.Now;
            textmonth.Text = MonthesNames.GetMonthName(realtime.Month);
            Workers.ItemsSource = workers1;
            Med1.ItemsSource = medvis;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) //добавление месяза через +
        {
            if (realtime.Month + 1 > DateTime.Now.Month + 2)
            {
                MessageBox.Show("Нельзя выбрать слишком дальний месяц!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                realtime = realtime.AddMonths(1);
                textmonth.Text = MonthesNames.GetMonthName(realtime.Month);
                if(Workers.SelectedItem!=null)
                {
                    TimeTableOfStom a = WorkWithData.TimeTableCheck((int)Workers.SelectedValue, realtime, ((WorkerFull)Workers.SelectedItem).Name);
                    Listv.ItemsSource = a.elements;
                }
                TextMonth.Text = textmonth.Text;
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)//уменьшение месяза через -
        {
            if (realtime.Month - 1 < DateTime.Now.Month)
            {
                MessageBox.Show("Нельзя создать расписание на прошлый месяц!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                realtime = realtime.AddMonths(-1);
                textmonth.Text = MonthesNames.GetMonthName(realtime.Month);
                if (Workers.SelectedItem != null)
                {
                    TimeTableOfStom a = WorkWithData.TimeTableCheck((int)Workers.SelectedValue, realtime, ((WorkerFull)Workers.SelectedItem).Name);
                    Listv.ItemsSource = a.elements;
                }
                TextMonth.Text = textmonth.Text;
            }
        }

        private void Workers_SelectionChanged(object sender, SelectionChangedEventArgs e)//при изменении элемента в списке сотрудинков
        {
            if (Listv.SelectedItem != null)
            {
                Listv.SelectedItem = null;
                Listb.ItemsSource = null;
                write.Visibility = Visibility.Collapsed;
                Med1.Visibility = Visibility.Collapsed;
                Listb.Visibility = Visibility.Collapsed;
            }
            TimeTableOfStom a = WorkWithData.TimeTableCheck((int)Workers.SelectedValue, realtime, ((WorkerFull)Workers.SelectedItem).Name);
            Listv.ItemsSource = a.elements;
            TextMonth.Text = textmonth.Text;
        }

        private void Listv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListForPriems priems = WorkWithData.CheckTimeTableForTalon((WorkerFull)Workers.SelectedItem, (TimeTableElement)Listv.SelectedItem);
            Listb.ItemsSource = priems.listPriem;
            if (write.Visibility == Visibility.Collapsed)
            {
                write.Visibility = Visibility.Visible;
                Med1.Visibility = Visibility.Visible;
                Listb.Visibility = Visibility.Visible;
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)//записать
        {
            if (Med1.SelectedItem != null && Listv.SelectedItem!=null&&Listb.SelectedItem!=null)
            {
                MessageBox.Show(WorkWithData.WriteTalon(ID, (MedVisitor)Med1.SelectedItem, (WorkerFull)Workers.SelectedItem, (Priem)Listb.SelectedItem, (TimeTableElement)Listv.SelectedItem), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                Listb.ItemsSource = null;
                ListForPriems priems = WorkWithData.CheckTimeTableForTalon((WorkerFull)Workers.SelectedItem, (TimeTableElement)Listv.SelectedItem);
                Listb.ItemsSource = priems.listPriem;

                temp.visitslist = WorkWithData.ListOfVisits();
                temp.listofVisits.ItemsSource = temp.visitslist.ToList().FindAll(x => x.IDStatus != 3 && x.IDStatus != 2 && x.IDStatus != 4);
                temp.DropSearch();
            }
            else
            {
                MessageBox.Show("Вы не выбрали пациента для записи!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
