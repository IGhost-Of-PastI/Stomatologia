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
    /// Логика взаимодействия для ОкноРегистратора.xaml
    /// </summary>
    public partial class ОкноРегистратора : Window
    {
        int ID=0;
        public ObservableCollection<MedVisitor> medvis = WorkWithData.LoadMedVis();
       public ObservableCollection<ElementOfVisitorList> visitslist = WorkWithData.ListOfVisits();
        public List<ElementOfVisitorList> cancelTalons = WorkWithData.LoadTalons().ToList();
        public ОкноРегистратора(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            combostatus.Items.Add("Пришёл");//заполнение списков
            combostatus.Items.Add("Не пришёл");
            listofVisits.ItemsSource = visitslist.ToList().FindAll(x=>x.IDStatus!=3 && x.IDStatus != 2&& x.IDStatus != 4);//заполнение списков
            listcancel.ItemsSource = cancelTalons.FindAll(x => x.IDStatus == 3);//заполнение списков
            doc.ItemsSource = medvis;
            ListOfCards.ItemsSource = medvis;
            doc_Copy.ItemsSource = medvis;
            searchdate_Copy.ItemsSource= MonthesNames.GetDates(); //заполнение списков
            searchdate.ItemsSource = MonthesNames.GetDates();//заполнение списков
            searchstatus.ItemsSource = WorkWithData.LoadStatus().FindAll(x=>x.IDStatus!=2 && x.IDStatus!=3&&x.IDStatus!=4);//заполнение списков
        }
        private void Button_Click(object sender, RoutedEventArgs e)//добавление мед карты(кнопка)
        {
            new MedVisCard(this).ShowDialog();
        }
        private void ChangeMedCard_Click(object sender, RoutedEventArgs e)//изменение карты пациента
        {
            if(ListOfCards.SelectedItem!=null)//проверка на выбранного пациента
            {
                new MedVisCard((MedVisitor)ListOfCards.SelectedItem,false,this).ShowDialog();//окно мед карты в режиме редактирования
            }
            else
            {
                MessageBox.Show("Не выбрана карта!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void doc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchFin();//запуск процедуры поиска при изменении
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)//изменение статуса приема
        {
            if(combostatus!=null&&listofVisits.SelectedItem!=null)
            {
                    if ((string)combostatus.SelectedValue == "Пришёл")
                    {
                        if (((ElementOfVisitorList)listofVisits.SelectedItem).ArrivingTime.ToShortDateString() == DateTime.Now.ToShortDateString())
                        {
                        WorkWithData.ChangeStatus(((ElementOfVisitorList)listofVisits.SelectedItem).NumberTalon, 2, ID);
                        this.DropSearch();//сброс настроек поиска
                        visitslist= WorkWithData.ListOfVisits();
                        listofVisits.ItemsSource = visitslist.ToList().FindAll(x => x.IDStatus != 3 && x.IDStatus != 2 && x.IDStatus != 4);//обновление списка
                        }
                    }
                    else//тоже самое но для статуса не пришёл
                    {
                        WorkWithData.ChangeStatus(((ElementOfVisitorList)listofVisits.SelectedItem).NumberTalon, 5, ID);
                        this.DropSearch();
                        visitslist=WorkWithData.ListOfVisits();
                        listofVisits.ItemsSource = visitslist.ToList().FindAll(x => x.IDStatus != 3 && x.IDStatus != 2 && x.IDStatus != 4);
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали статус приёма!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void VeiwButton_Click(object sender, RoutedEventArgs e)//просмотр карты пациента
        {
            if (ListOfCards.SelectedItem != null)
            {
                new MedVisCard((MedVisitor)ListOfCards.SelectedItem, true,this).ShowDialog();
            }
            else
            {
                MessageBox.Show("Не выбрана карта!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)//запись пациентов на приём
        {
            new Maketalon(this.ID,this).ShowDialog();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)//поиск у пациентов по фамилии
        {
            List<MedVisitor> temp=medvis.ToList();
            if (Serch.Text!="")
            {
                temp = temp.FindAll(x => x.SerName.Contains(Serch.Text) == true);
            }
            if(downup.IsChecked==true)
            {
                temp = temp.OrderByDescending(x => x.SerName).ToList();
            }
            else
            {
                if (updown.IsChecked == true)
                {
                    temp = temp.OrderBy(x => x.SerName).ToList();
                }
            }
            ListOfCards.ItemsSource = temp;
        }
        private void updown_Checked(object sender, RoutedEventArgs e)//сортировка
        {
            List<MedVisitor> temp = medvis.ToList();
            if (Serch.Text != "")
            {
                temp = temp.FindAll(x => x.SerName.Contains(Serch.Text) == true);

            }
            if (downup.IsChecked == true)
            {
                temp =temp.OrderByDescending(x => x.SerName).ToList();
            }
            else
            {
                if (updown.IsChecked == true)
                {
                    temp = temp.OrderBy(x => x.SerName).ToList();
                }
            }
            ListOfCards.ItemsSource = temp;
        }
        public void SearchFin()//поиск в списке записей
        {
            List<ElementOfVisitorList> temp = WorkWithData.ListOfVisits().ToList().FindAll(x => x.IDStatus != 3 && x.IDStatus != 2 && x.IDStatus != 4);
            if (doc.SelectedItem != null)
            {
                temp = temp.FindAll(x => x.SerName == ((MedVisitor)doc.SelectedItem).SerName && x.FirstName == ((MedVisitor)doc.SelectedItem).FirstName && x.ThridName == ((MedVisitor)doc.SelectedItem).ThirdName);
            }
            if (searchdate.SelectedItem != null)
            {
                temp = temp.FindAll(x => x.ArrivingTime.ToShortDateString() == (string)searchdate.SelectedValue);
            }
            if (searchstatus.SelectedItem != null)
            {
                temp = temp.FindAll(x => x.IDStatus == ((Status)searchstatus.SelectedItem).IDStatus);
            }
            if (downup_Copy.IsChecked == true)
            {
                temp = temp.OrderBy(x => x.ArrivingTime).ToList();
               
            }
            else
            {
                if (updown_Copy.IsChecked == true)
                {
                    temp = temp.OrderByDescending(x => x.ArrivingTime).ToList();
                }
            }
            listofVisits.ItemsSource = temp;
        }
        private void downup_Checked(object sender, RoutedEventArgs e)//сортировка списка пациентов
        {
            List<MedVisitor> temp = medvis.ToList();
            if (Serch.Text != "")
            {
                temp = temp.FindAll(x => x.SerName.Contains(Serch.Text) == true);
            }
            if (downup.IsChecked == true)
            {
               temp= temp.OrderByDescending(x => x.SerName).ToList();
            }
            else
            {
                if (updown.IsChecked == true)
                {
                  temp= temp.OrderBy(x => x.SerName).ToList();
                }
            }
            ListOfCards.ItemsSource = temp;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)//запись вне очереди
        {
            new UnQueueReg(this.ID).ShowDialog();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)//выход
        {
            new Окно_авторизации().Show();
            this.Close();
        }
        public void DropSearch()//сброс поиска в пациентах
        {
            doc.SelectedItem = null;
            searchdate.SelectedItem = null;
            searchstatus.SelectedItem = null;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)//отчистить
        {
            this.DropSearch();
        }
        private void searchdate_SelectionChanged(object sender, SelectionChangedEventArgs e)//поиск в списке талонов
        {
            SearchFin();
        }
        private void searchstatus_SelectionChanged(object sender, SelectionChangedEventArgs e)//поиск в списке талонов
        {
            SearchFin();
        }
        public void DropSearch2()//сброс в отменнёных талонах
        {
            doc_Copy.SelectedItem = null;
            searchdate_Copy.SelectedItem = null;
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)//сброс настроек поиска
        {
            this.DropSearch2();
        }
        private void doc_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)//поиск в отменнёх талонах
        {
            List<ElementOfVisitorList> temp = WorkWithData.LoadTalons().ToList().FindAll(x => x.IDStatus == 3);
            if (doc_Copy.SelectedItem != null)
            {
                temp = temp.FindAll(x => x.SerName == ((MedVisitor)doc_Copy.SelectedItem).SerName && x.FirstName == ((MedVisitor)doc_Copy.SelectedItem).FirstName && x.ThridName == ((MedVisitor)doc_Copy.SelectedItem).ThirdName);
            }
            if (searchdate_Copy.SelectedItem != null)
            {
                temp = temp.FindAll(x => x.ArrivingTime.ToShortDateString() == (string)searchdate_Copy.SelectedValue);
            }
            listcancel.ItemsSource = temp;
        }
        private void searchdate_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)//поиск в отменнёх талонах
        {
            List<ElementOfVisitorList> temp = WorkWithData.LoadTalons().ToList().FindAll(x => x.IDStatus == 3);
            if (doc_Copy.SelectedItem != null)
            {
                temp = temp.FindAll(x => x.SerName == ((MedVisitor)doc_Copy.SelectedItem).SerName && x.FirstName == ((MedVisitor)doc_Copy.SelectedItem).FirstName && x.ThridName == ((MedVisitor)doc_Copy.SelectedItem).ThirdName);
            }
            if (searchdate_Copy.SelectedItem != null)
            {
                temp = temp.FindAll(x => x.ArrivingTime.ToShortDateString() == (string)searchdate_Copy.SelectedValue);
            }
            listcancel.ItemsSource = temp;
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)//удаление из отменнёх талонов
        {
            if(listcancel.SelectedItem!=null)
            {
                WorkWithData.DeletefromTalons(((ElementOfVisitorList)listcancel.SelectedItem).NumberTalon);
                cancelTalons.Remove(listcancel.SelectedItem as ElementOfVisitorList);
                cancelTalons = WorkWithData.LoadTalons().ToList().FindAll(x => x.IDStatus == 3);
                listcancel.ItemsSource = cancelTalons;
                MessageBox.Show("Удаление завершено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void downup_Copy_Checked(object sender, RoutedEventArgs e)//соритровка
        {
            SearchFin();
        }
        private void updown_Copy_Checked(object sender, RoutedEventArgs e)//соритровка
        {
            SearchFin();
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)//справка
        {
            new Spravka().Show();
        }
    }
}
