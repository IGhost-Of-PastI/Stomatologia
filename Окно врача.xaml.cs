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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int ID;
        ObservableCollection<Talon> talons;
        List<Talon> unqueue;
        public Window1(int id)
        {
            InitializeComponent();
            ID = id; //ID персонала
            talons = WorkWithData.LoadTalons(ID); //загрузка талонов по предварительной записи
            unqueue = WorkWithData.LoadTalonsUnQueue(ID); //загрузка талон вне очереди
            ListtalonsonTime.ItemsSource = talons;//заполнение listbox
            UnqueueList.ItemsSource = unqueue;//заполнение listbox
        }
        public void Update()//обновление всех списков
        {
            talons = WorkWithData.LoadTalons(ID);
            unqueue = WorkWithData.LoadTalonsUnQueue(ID);
            ListtalonsonTime.ItemsSource = talons;
            UnqueueList.ItemsSource = unqueue;
        }
        private void ListtalonsonTime_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Maketalon(ID,this).ShowDialog();//окно записи пациента
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)//завршени е сеанса
        {
            if(ListtalonsonTime.SelectedItem!=null||UnqueueList.SelectedItem!=null)//проверка на вырбранные скписки
            {
                if(ListtalonsonTime.SelectedItem!=null)//проверка из какого списка выбран элемент для выбора определнного режима работы
                {
                        new TalonEndTalon(talons.ToList(), (Talon)ListtalonsonTime.SelectedItem, this,false).ShowDialog(); //по записи
                }
                else
                {
                    new TalonEndTalon(unqueue,(Talon)UnqueueList.SelectedItem,this,true).ShowDialog();//по очереди
                }
            }
            else
            {
                MessageBox.Show("Не выбран талон!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void UnqueueList_SelectionChanged(object sender, SelectionChangedEventArgs e)//смена списков
        {
            ListtalonsonTime.SelectedItem = null;
        }
        private void ListtalonsonTime_SelectionChanged(object sender, SelectionChangedEventArgs e)//смена списков
        {
            UnqueueList.SelectedItem = null;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)//кнопка выхода
        {
            new Окно_авторизации().Show();
            this.Close();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)//кнопка справки
        {
            new Spravka().Show();
        }
    }
}
