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
using System.Data.SqlClient;


namespace Stomatologia
{
    /// <summary>
    /// Логика взаимодействия для Окно_авторизации.xaml
    /// </summary>
    public partial class Окно_авторизации : Window
    {
        List<WorkerFull> WorkerList = Inizialize.FillCombobox();
        public Окно_авторизации()
        {
            InitializeComponent();
            Combo.ItemsSource = WorkerList;
        }
        private void Button_Click(object sender, RoutedEventArgs e)//вход
        {
            if(Combo.SelectedItem!=null&&Pass.Password!=null&&Pass.Password!="")//проверка на заполненые поля
            {
                int temp;
                temp = Inizialize.Autorization(((WorkerFull)Combo.SelectedItem).ID, Pass.Password);//вызов метода авторизации
                if (temp == -1)//если резальтат равен -1 то пароль не верный
                {
                    MessageBox.Show("Неверный пароль!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    switch (temp)//если не -1 то открыть окно соответствющей специальности
                    {
                        case 1:
                            {
                                new MainWindow().Show();
                                this.Close();
                                break;
                            }
                        case 2:
                            {
                                new ОкноРегистратора(((WorkerFull)Combo.SelectedItem).ID).Show();
                                this.Close();
                                break;
                            }
                        default:
                            {
                                new Window1(((WorkerFull)Combo.SelectedItem).ID).Show();
                                this.Close();
                                break;
                            }
                    }
                }
            }
            else
            {
                MessageBox.Show("Поля не заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)//отмена
        {
            this.Close();
        }
    }
}
