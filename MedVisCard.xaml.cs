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
using System.Text.RegularExpressions;
//using Clases;
using System.Collections.ObjectModel;

namespace Stomatologia
{
    /// <summary>
    /// Логика взаимодействия для MedVisCard.xaml
    /// </summary>
    public partial class MedVisCard : Window
    {
        List<Republics> rep = WorkWithData.LoadRepub();
        MedVisitor temp;
        ОкноРегистратора temp2;
        public MedVisCard(ОкноРегистратора a)
        {
            InitializeComponent();
            temp2 = a;
            Rep.ItemsSource = rep;
            Year.ItemsSource = MonthesNames.GetYears();
            Month.ItemsSource = MonthesNames.GetMonthes();
        }

        public MedVisCard(MedVisitor a, bool mode,ОкноРегистратора temp2)
        {
            InitializeComponent();
            Rep.ItemsSource = rep;
            Year.ItemsSource = MonthesNames.GetYears();
            Month.ItemsSource = MonthesNames.GetMonthes();
            switch (mode)
            {
                case false://изменение
                    {

                        this.temp2 = temp2;
                        temp = a;

                        firstname.Text = temp.FirstName;
                        sername.Text = temp.SerName;
                        thirdname.Text = temp.ThirdName;
                        Year.SelectedItem = temp.BirthDate.Year;
                        Month.SelectedItem = temp.BirthDate.Month;
                        Day.SelectedItem = temp.BirthDate.Day;
                        if (temp.Sex == false)
                        {
                            radM.IsChecked = true;
                        }
                        else
                        {
                            radJ.IsChecked = true;
                        }
                        NumberTel.Text = temp.PhoneNum;
                        Rep.SelectedItem = rep.Find(x => x.ID == temp.NumOfRep);
                        break;
                    }
                case true://просмотр
                    {
                       
                        datagrider.ItemsSource = WorkWithData.LoadObrashen(a.ID);

                        Savebutton.Visibility = Visibility.Collapsed;
                        temp = a;

                        firstname.Text = temp.FirstName;
                        sername.Text = temp.SerName;
                        thirdname.Text = temp.ThirdName;
                        Year.SelectedItem = temp.BirthDate.Year;
                        Month.SelectedItem = temp.BirthDate.Month;
                        Day.SelectedItem = temp.BirthDate.Day;
                        if (temp.Sex == false)
                        {
                            radM.IsChecked = true;
                        }
                        else
                        {
                            radJ.IsChecked = true;
                        }
                        NumberTel.Text = temp.PhoneNum;
                        Rep.SelectedItem = rep.Find(x => x.ID == temp.NumOfRep);

                        firstname.IsReadOnly = true;
                        sername.IsReadOnly = true;
                        thirdname.IsReadOnly = true;
                        Year.IsEnabled = false;
                        Month.IsEnabled = false;
                        Day.IsEnabled = false;
                        radM.IsEnabled = false;
                        radJ.IsEnabled = false;
                        NumberTel.IsReadOnly = true;
                        Rep.IsEnabled = false;

                        break;
                    }
            }
          
        }
        private void Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Year.SelectedItem != null && Month.SelectedItem != null)
            {
                Day.IsEnabled = true;
                Day.ItemsSource = MonthesNames.GetDays((int)Month.SelectedItem, (int)Year.SelectedItem);
            }
            else
            {
                Day.IsEnabled = false;
            }
        }
        private void Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Year.SelectedItem != null && Month.SelectedItem != null)
            {
                Day.IsEnabled = true;
                Day.ItemsSource = MonthesNames.GetDays((int)Month.SelectedItem, (int)Year.SelectedItem);
            }
            else
            {
                Day.IsEnabled = false;
            }
        }
        private static bool IsText(string str)
        {
            Regex reg = new Regex(@"^\+\d{1,3}\s{1}\(\d{1,3}\)\s{1}\d{3}\-\d{2}\-\d{2}$");
            return reg.IsMatch(str);
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (firstname.Text != string.Empty && sername.Text != string.Empty && Year.SelectedItem != null && Month.SelectedItem != null && Day.SelectedItem != null && NumberTel.Text != string.Empty && Rep.SelectedItem != null && radJ.IsChecked == true ^ radM.IsChecked == true)
            {
                if (IsText(NumberTel.Text))
                {
                    bool temp;
                    if (radM.IsChecked == true)
                    {
                        temp = false;
                    }
                    else
                    {
                        temp = true;
                    }
                    
                    if (this.temp == null)
                    {
                        WorkWithData.SaveAMBCard(new MedVisitor(firstname.Text, sername.Text, thirdname.Text, new DateTime((int)Year.SelectedItem, (int)Month.SelectedItem, (int)Day.SelectedItem), temp, NumberTel.Text, ((Republics)Rep.SelectedItem).ID, 0));
                    }
                    else
                    {
                        WorkWithData.SaveAMBCard(new MedVisitor(firstname.Text,
                            sername.Text, thirdname.Text,
                            new DateTime((int)Year.SelectedItem,
                            (int)Month.SelectedItem,
                            (int)Day.SelectedItem),
                            temp, NumberTel.Text,
                            ((Republics)Rep.SelectedItem).ID,
                            this.temp.ID));
                    }

                    temp2.visitslist = WorkWithData.ListOfVisits();
                    temp2.listofVisits.ItemsSource = temp2.visitslist;
                    temp2.medvis = WorkWithData.LoadMedVis();
                    temp2.ListOfCards.ItemsSource = temp2.medvis;
                    temp2.doc.ItemsSource = temp2.medvis;
                    temp2.cancelTalons = WorkWithData.LoadTalons().ToList();
                    temp2.listcancel.ItemsSource = temp2.cancelTalons.FindAll(x => x.IDStatus == 3);
                    temp2.Serch.Text = "";
                    temp2.downup.IsChecked = false;
                    temp2.updown.IsChecked = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Формат телефона не соостветствует формату +xxx (xx) xxx-xx-xx", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
               
            }
            else
            {
                MessageBox.Show("Не все пункты заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
