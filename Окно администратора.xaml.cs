using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Drawing.Slicer;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing;

//using Clases;

namespace Stomatologia
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime realtime;
        ObservableCollection<TimeTableOfStom> stoms = new ObservableCollection<TimeTableOfStom>();
        ObservableCollection<WorkerFull> workers = WorkWithData.LoadData(false);
        ObservableCollection<WorkerFull> workers1 = WorkWithData.LoadData(true);
        ObservableCollection<Spec> specs = WorkWithData.LoadSpec();
        ObservableCollection<Rooms> rooms = WorkWithData.LoadRoom();
        ObservableCollection<EmplStatus> emplstatus = WorkWithData.LoadEpmpstatus();
        bool fortemproom=false;
        bool forpersonal = false;
        public MainWindow()//заполнение таблиц
        {
            InitializeComponent();
            realtime = DateTime.Now;
            textmonth.Text = MonthesNames.GetMonthName(realtime.Month);
           Workers.ItemsSource = workers1;
            DataGrid1.ItemsSource = workers;
            DataGrid2.ItemsSource = rooms;
            comboingrid.ItemsSource = specs;
            comboingrid1.ItemsSource = rooms;
            comboingrid2.ItemsSource = emplstatus;
        }
        private void UpdateInsertRoom(object sender, RoutedEventArgs e)//добаление нового кабинета или изменение старого
        {
            DataGrid2.CommitEdit();//применить изменение и закончить редактирование
            DataGridRow row = DataGrid2.ItemContainerGenerator.ContainerFromItem(DataGrid2.SelectedItem) as DataGridRow;
            row.Background = (Brush)new BrushConverter().ConvertFrom("#ffffff");
            Rooms w = (Rooms)DataGrid2.SelectedItem;
            if (w.NameRooms != null || w.NameRooms != "")
            {
                if (w.ID2 == 1 || w.ID2 == 2)//проверка на стандартные кабинеты
                {
                    MessageBox.Show("Нельзя изменить стандартные кабинеты!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    string pattern = @"\w\s{1}\d";//проверка правильного фармата ввода кабинета
                    if (Regex.IsMatch(w.NameRooms, pattern))
                    {
                        int tempID = WorkWithData.InsertOrUpdateRoom(w);//метод внесения измененией
                        if (tempID != -1)//если -1 то значит был изменен существующий кабинет
                        {

                            w.ID2 = tempID;
                            fortemproom = false;
                        }
                        MessageBox.Show("Изменение завершено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не верный формат (Название номер)!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void DoInsUpdEmplOperation(WorkerFull w)
        {
            if (w.SpecNum != 1)
            {
                if (w.Name != null && w.Name != "" && w.NumRoom != 0 && w.Pass != null && w.Pass != "" && w.SpecNum != 0 && w.NumStatus != 0)
                {
                    int tempID = WorkWithData.InsertOrUpdateEmpl(w);
                    if (tempID != -1)
                    {

                        w.ID = tempID;
                        forpersonal = false;
                    }

                    MessageBox.Show("Изменение завершено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    workers1.Clear();
                    workers1 = WorkWithData.LoadData(true);
                    Workers.ItemsSource = workers1;

                }
                else
                {
                    MessageBox.Show("Не все поля заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                workers = WorkWithData.LoadData(false);
                DataGrid1.ItemsSource = workers;
                MessageBox.Show("Нельзя изменить администратора!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Button_Click1(object sender, RoutedEventArgs e)//так же как и с кабинетами
        {
            DataGrid1.CommitEdit();
            DataGridRow row = DataGrid1.ItemContainerGenerator.ContainerFromItem(DataGrid1.SelectedItem) as DataGridRow;
            row.Background= (Brush)new BrushConverter().ConvertFrom("#ffffff");
            WorkerFull w = (WorkerFull)DataGrid1.SelectedItem;
            if(w.NumStatus==3&&w.ID!=0)
            {
                if (MessageBox.Show("Если поставить этому сотруднику статус уволен, то все записанные к нему талоны будут отменены. Вы действительно хотите выполнить эту операцию?",
"Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DoInsUpdEmplOperation(w);
                }
            }
            else
            {
                DoInsUpdEmplOperation(w);
            }
        }
        private void DataGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)//цвет при изменнии ячеек
        {
            e.Row.Background = (Brush)new BrushConverter().ConvertFrom("#FFF08080");
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)//кнопка добавления поля для создания нового сотрудника
        {
            if(forpersonal!=true)
            {
                workers.Add(new WorkerFull());
                forpersonal = true;
            }
            else
            {
                MessageBox.Show("Вы уже добавели 1 строку для заполнения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)//кнопка добавления поля для создания нового кабинета
        {
            if(fortemproom!=true)
            {
                rooms.Add(new Rooms());
                fortemproom = true;
            }
            else
            {
                MessageBox.Show("Вы уже добавели 1 строку для заполнения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
        private void Workers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void Add(object sender, RoutedEventArgs e)//добавления месяца при прокрутки месяцев в расписании
        {
            if (realtime.Month+1>DateTime.Now.Month+2)//проверка на дальность месяца которую нельзя привышать
            {
                MessageBox.Show("Нельзя выбрать слишком дальний месяц!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
               realtime= realtime.AddMonths(1);
                textmonth.Text = MonthesNames.GetMonthName(realtime.Month);
            }
        }
        private void Back(object sender, RoutedEventArgs e)//тоже самое что и выше только наоборот
        {
            if(realtime.Month - 1 <DateTime.Now.Month)
            {
                MessageBox.Show("Нельзя создать расписание на прошлый месяц!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                realtime = realtime.AddMonths(-1);
                textmonth.Text = MonthesNames.GetMonthName(realtime.Month);
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)//загрузка или создания расписание на этот месяцй для данного стоматолога
        {
           if(Workers.SelectedItem!=null)
            {
                bool temp = false;
                foreach (TimeTableOfStom t in stoms)//проверка на возможность добавления элемента в списков(елси тот же сотрудник и месяц уже выбраны то нельзя добавить ещё такой же элемент в список)
                {
                    if (t.ID == (int)Workers.SelectedValue && realtime.Month == t.MounthDate.Month)
                    {
                        temp = true;
                        break;
                    }
                }
                if (temp == true)
                {
                    MessageBox.Show("Данный элемент уже существует в списке!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    TimeTableOfStom a = WorkWithData.TimeTableCheck((int)Workers.SelectedValue, realtime, ((WorkerFull)Workers.SelectedItem).Name);//загрузка из Бд расписания
                    stoms.Add(a);
                    Listv.ItemsSource = a.elements;
                    Listb.ItemsSource = stoms;
                    Listb.SelectedItem = a;
                }
            }
           else
            {
                MessageBox.Show("Не выбран стоматолог!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Listb_SelectionChanged(object sender, SelectionChangedEventArgs e)//действия при смене итемов в списке расписаний
        {
            if(Listb.SelectedItem!=null)
            {
                Listv.ItemsSource = ((TimeTableOfStom)Listb.SelectedItem).elements;
                TextMonth.Text = MonthesNames.GetMonthName(((TimeTableOfStom)Listb.SelectedItem).MounthDate.Month);
                if (Listv.Visibility == Visibility.Hidden)
                {
                    Listv.Visibility = Visibility.Visible;
                    dayofweek.Visibility = Visibility.Visible;
                    month.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (Listv.Visibility == Visibility.Visible)
                {
                    Listv.Visibility = Visibility.Hidden;
                    dayofweek.Visibility = Visibility.Hidden;
                    month.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)//удаление только из списка
        {
            if(Listb.SelectedItem!=null)
            {
                stoms.Remove((TimeTableOfStom)Listb.SelectedItem);
                if (Listv.Visibility == Visibility.Visible)
                {
                    Listv.Visibility = Visibility.Hidden;
                }
                MessageBox.Show("Элемент удалён из спсика!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Не выбран элемент в списке справа!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)//сохранить
        {
            if(Listb.SelectedItem!=null)
            {
                WorkWithData.SaveElementInTimeTable((TimeTableOfStom)Listb.SelectedItem, ((TimeTableOfStom)Listb.SelectedItem).elements.ToList());
                MessageBox.Show("Сохранено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Вы не выбрали сохраняемый элемент из списка ниже!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)//сохранить всё
        {
            if(Listb.Items.Count!=0)
            {
                foreach (TimeTableOfStom a in stoms)
                {
                    WorkWithData.SaveElementInTimeTable(a, a.elements.ToList());
                }
                MessageBox.Show("Сохранено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Для сохранения изменений нужен хоты бы один элемент в списке ниже!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)//выход
        {
            new Окно_авторизации().Show();
            this.Close();
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)//справка
        {
            new Spravka().Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Отчёт
        {
            FileInfo template = new FileInfo(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Отчёт.xlsx");

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage package = new ExcelPackage(null, template);
            ExcelWorksheet sheet = package.Workbook.Worksheets[1];

            


            sheet.Columns.AutoFit();
            sheet.Columns.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            int row = 2;

            List<Obrashen> list= WorkWithData.LoadObrashen();
            foreach (Obrashen item in list)
            {
                sheet.Cells[row, 1].Value = item.FIOPac;
                sheet.Cells[row, 2].Value = item.FIO_Spec;
                sheet.Cells[row, 3].Value = item.Givetalon;
                row++;
            }
            ExcelWorksheet wsPivot = sheet.Workbook.Worksheets[0];
            ExcelPivotTableSlicer monthSlicer = wsPivot.PivotTables[0].Fields["Стоматолог"].AddSlicer();
            monthSlicer.Caption = "Стоматолог";
            monthSlicer.ChangeCellAnchor(eEditAs.Absolute);
            monthSlicer.SetPosition(80, 1000);
            monthSlicer.SetSize(200, 200);
            monthSlicer.Style = eSlicerStyle.Other2;

            byte[] reportExcel = package.GetAsByteArray();
            string commandText = pathToFile + @"\Отчёт.xlsx";
            File.WriteAllBytes(commandText, reportExcel);

            OpenFile(commandText, reportExcel);
        }
        private void OpenFile(string path, byte[] reportExcel)
        {
            File.WriteAllBytes(path, reportExcel);
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = path;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
        private readonly string pathToFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
    }
}
