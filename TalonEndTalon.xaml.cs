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
    /// Логика взаимодействия для TalonEndTalon.xaml
    /// </summary>
    public partial class TalonEndTalon : Window
    {
        EndTalon info;
        int numtalon2=0;
        Window1 c;
        bool done = false;
        public TalonEndTalon(List<Talon> a,Talon b,Window1 c,bool mode)
        {
            InitializeComponent();
            this.c = c;
            switch (mode)
            {
                case false://режим для талонов по записи
                    {
                        info = WorkWithData.EndTalonLoad(b.ID);//загрузка данных из представления endtalon
                        if(a.Count== a.IndexOf(b)+1)//проверка на конец списка во избежание ошибок в следующем этапе
                        {
                            Usluga.Items.Add("Осмотр");
                            Usluga.SelectedItem = "Осмотр";
                            Usluga.IsEnabled = false;
                        }
                        else
                        {
                            if (a.ElementAt(a.IndexOf(b) + 1).IDMedVis == b.IDMedVis)//если за выбранным элементом нет элемента с таким же пациентом то это процедура
                            {
                                numtalon2 = a.ElementAt(a.IndexOf(b) + 1).ID;
                                Usluga.Items.Add("Профессиональная чистка полости рта");
                                Usluga.Items.Add("Лечение кариеса зубов");
                                Usluga.Items.Add("Лечение пульпита 1 коренового зуба");
                                Usluga.Items.Add("Лечение пульпита 2 коренового зуба");
                                Usluga.Items.Add("Лечение пульпита 3 коренового зуба");
                            }
                            else//в иных случаях осомтр
                            {
                                Usluga.Items.Add("Осмотр");
                                Usluga.SelectedItem = "Осмотр";
                                Usluga.IsEnabled = false;
                            }
                        }
                        BoxSername.Text = info.SerName;//далее заполнение полей информацией
                        BoxName.Text = info.Name;
                        BoxThirdName.Text = info.Thirdname;
                        BoxBirthDate.Text = info.BirthDate.ToShortDateString();
                        BoxAge.Text = info.Age.ToString();
                        switch (info.Sex)
                        {
                            case false:
                                {
                                    BoxSex.Text = "Мужской";
                                    break;
                                }
                            case true:
                                {
                                    BoxSex.Text = "Женский";
                                    break;
                                }
                        }
                        BoxTel.Text = info.TelNumber;
                        NumberTalon.Text = info.TalonNum.ToString();
                        ArriveTime.Text = info.TimeArrive.ToShortDateString();
                        ArriveTimeTime.Text = info.TimeArrive.ToShortTimeString();
                        BoxFIO.Text = info.FIO + " " + $"({info.SpecName})";
                        NumOfRoom.Text = info.NumRoom.ToString();
                        Status.Items.Add("Записан");
                        Status.Items.Add("Пришёл");
                        Status.Items.Add("Завершено");
                        switch (info.Status)
                        {
                            case "Записан":
                                {
                                    Status.SelectedItem = "Записан";
                                    break;
                                }
                            case "Пришёл":
                                {
                                    Status.SelectedItem = "Пришёл";
                                    break;
                                }
                            case "Завершено":
                                {
                                    Status.SelectedItem = "Завершено";
                                    break;
                                }
                        }
                        break;

                    }
                case true://режим без записи (только осомтр)
                    {
                        //далее заполнение данными полей
                        info = WorkWithData.EndTalonLoad(b.ID);
                        Usluga.Items.Add("Осмотр");
                        Usluga.SelectedItem = "Осмотр";
                        Usluga.IsEnabled = false;
                        BoxSername.Text = info.SerName;
                        BoxName.Text = info.Name;
                        BoxThirdName.Text = info.Thirdname;
                        BoxBirthDate.Text = info.BirthDate.ToShortDateString();
                        BoxAge.Text = info.Age.ToString();
                        switch (info.Sex)
                        {
                            case false:
                                {
                                    BoxSex.Text = "Мужской";
                                    break;
                                }
                            case true:
                                {
                                    BoxSex.Text = "Женский";
                                    break;
                                }
                        }
                        BoxTel.Text = info.TelNumber;
                        NumberTalon.Text = info.TalonNum.ToString();
                        ArriveTime.Text = info.TimeArrive.ToShortDateString();
                        ArriveTimeTime.Text = info.TimeArrive.ToShortTimeString();
                        BoxFIO.Text = info.FIO + " " + $"({info.SpecName})";
                        NumOfRoom.Text = info.NumRoom.ToString();
                        Status.Items.Add("Записан");
                        Status.Items.Add("Пришёл");
                        Status.Items.Add("Завершено");
                        switch (info.Status)
                        {
                            case "Записан":
                                {
                                    Status.SelectedItem = "Записан";
                                   
                                    break;
                                }
                            case "Пришёл":
                                {
                                    Status.SelectedItem = "Пришёл";
                                    break;
                                }
                            case "Завершено":
                                {
                                    Status.SelectedItem = "Завершено";
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(done==false)//проверка на повторное проведение операции(если она была проведена то этапы с запись в таблицу в БД не выполняются)
            {
                if (Usluga.SelectedItem != null)
                {
                    if ((string)Usluga.SelectedItem != "Осмотр")//если осмотр
                    {
                        new Chek($"{info.SerName} {info.Name} {info.Thirdname}", $"{BoxFIO.Text}", Cost.Text, (string)Usluga.SelectedItem, info.TalonNum).Show();//окно чека
                        WorkWithData.EndtalonMethod(info, Cost.Text, (string)Usluga.Text, numtalon2);//метод для записи операции в БД
                        c.ListtalonsonTime.ItemsSource = WorkWithData.LoadTalons(c.ID);//обновление списков
                        c.UnqueueList.ItemsSource = WorkWithData.LoadTalonsUnQueue(c.ID);//обновление списков
                        Status.SelectedItem = "Завершено";
                        Status.IsEnabled = false;
                        c.Update();//обновление списков
                        done = true;
                    }
                    else
                    {
                        new Chek($"{info.SerName} {info.Name} {info.Thirdname}", $"{BoxFIO.Text}", Cost.Text, (string)Usluga.SelectedItem, info.TalonNum).Show();// окно чека
                        WorkWithData.EndtalonMethod(info, Cost.Text, (string)Usluga.Text, 0);//метод для записи операции в БД
                        c.ListtalonsonTime.ItemsSource = WorkWithData.LoadTalons(c.ID);//обновление списков
                        c.UnqueueList.ItemsSource = WorkWithData.LoadTalonsUnQueue(c.ID);//обновление списков
                        Status.SelectedItem = "Завершено";
                        Status.IsEnabled = false;
                        c.Update();//обновление списков
                        done = true;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите услугу!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                new Chek($"{info.SerName} {info.Name} {info.Thirdname}", $"{BoxFIO.Text}", Cost.Text, (string)Usluga.SelectedItem, info.TalonNum).Show();//если действие было выполнено уже то только печатать талон
            }
        }
        private void Usluga_SelectionChanged(object sender, SelectionChangedEventArgs e)//смена спика услуг
        {
            switch((string)Usluga.SelectedItem)
            {
                case "Профессиональная чистка полости рта":
                    {
                        Cost.Text = "200,00";
                        break;
                    }
                case "Лечение кариеса зубов":
                    {
                        Cost.Text = "150,00";
                        break;
                    }
                case "Лечение пульпита 1 коренового зуба":
                    {
                        Cost.Text = "200,00";
                        break;
                    }
                case "Лечение пульпита 2 коренового зуба":
                    {
                        Cost.Text = "300,00";
                        break;
                    }
                case "Лечение пульпита 3 коренового зуба":
                    {
                        Cost.Text = "400,00";
                        break; 
                    }
                default:
                    {
                        Cost.Text="20,00";
                        break;
                    }
            }
        }
    }
}
