using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace Stomatologia
{
    public class Obrashen
    {
        public int NumTalon {get;set;}

        public string FIOPac { get; set; }
        public string NameStats { get; set; }
        public DateTime Paymenttime { get; set; }
        public decimal Cost { get; set; }
        public string FIO_Spec { get; set; }
        public string FIO_reg { get; set; }
        public string FIO_givetalon { get; set;}
        public DateTime Writetalon { get; set; }
        public DateTime Givetalon { get; set; }
        public string Usluga { get; set; }
        public Obrashen(int numtalon,string namestatus, DateTime paymenttime, decimal cost,string fiospecial,string fioreg,string fiogivetalon,DateTime writetalon,DateTime givetalon, string usluga)
        {
            NumTalon = numtalon;
            NameStats = namestatus;
            Paymenttime = paymenttime;
            Cost = cost;
            FIO_Spec = fiospecial;
            FIO_reg = fioreg;
            FIO_givetalon = fiogivetalon;
            Writetalon = writetalon;
            Givetalon = givetalon;
            Usluga = usluga;
        }
        public Obrashen(int numtalon,string FIOPac, string namestatus, DateTime paymenttime, decimal cost, string fiospecial, string fioreg, string fiogivetalon, DateTime writetalon, DateTime givetalon, string usluga)
        {
            NumTalon = numtalon;
            this.FIOPac = FIOPac;
            NameStats = namestatus;
            Paymenttime = paymenttime;
            Cost = cost;
            FIO_Spec = fiospecial;
            FIO_reg = fioreg;
            FIO_givetalon = fiogivetalon;
            Writetalon = writetalon;
            Givetalon = givetalon;
            Usluga = usluga;
        }
    }
    public class EndTalon
    {
        public string SerName { get; set; }
        public string Name { get; set; }
        public string Thirdname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public string TelNumber { get; set; }
        public int TalonNum { get; set; }
        public string Status { get; set; }
        public DateTime TimeArrive { get; set; }
        public string FIO { get; set; }
        public string SpecName { get; set; }
        public string NumRoom { get; set; }
        public int IdPac { get; set; }
        public int IdStatus { get; set; }
        public int IdSpeccial { get; set; }
        public int IdReg { get; set; }
        public int IdGiveTalon { get; set; }
        public DateTime writedate { get; set; }
        public DateTime givetalon { get; set; }
        public EndTalon(string sername, string name, string thirdname, DateTime birthdate, int age, bool sex, string telnumber, int talonnum, string status, DateTime timearrive, string fio, string specname, string numroom, int Idpac, int idstatus, int idspecial, int idreg, int idgivetalon, DateTime writetime, DateTime givetime)
        {
            SerName = sername;
            Name = name;
            Thirdname = thirdname;
            BirthDate = birthdate;
            Age = age;
            Sex = sex;
            TelNumber = telnumber;
            TalonNum = talonnum;
            Status = status;
            TimeArrive = timearrive;
            FIO = fio;
            SpecName = specname;
            NumRoom = numroom;
            IdPac = Idpac;
            IdStatus = idstatus;
            IdSpeccial = idspecial;
            IdReg = idreg;
            IdGiveTalon = idgivetalon;
            writedate = writetime;
            givetalon = givetime;
        }
        public EndTalon()
        {
        }
    }
    public class EmplStatus
    {
        public string Name { get; set; }
        public int ID3 { get; set; }
        public EmplStatus(string Name, int ID)
        {
            this.Name = Name;
            ID3 = ID;
        }
    }

    public class ElementOfVisitorList
    {
        public string SerName { get; set; }
        public string FirstName { get; set; }
        public string ThridName { get; set; }
        public string FIODoc { get; set; }
        public string NameSpec { get; set; }
        public string Status { get; set; }
        public int IDStatus { get; set; }
        public int NumberTalon { get; set; }
        public DateTime ArrivingTime { get; set; }
        public string RoomName { get; set; }
        public int IDRoom { get; set; }
        public string TelNumber { get; set; }
        public ElementOfVisitorList(string sername, string fristname, string thirdname, string fiodoc, string namespec, string namestatus, int idstatus, int numtalon, DateTime arrivetime, string roomname, int numofroom)
        {
            SerName = sername;
            FirstName = fristname;
            ThridName = thirdname;
            FIODoc = fiodoc;
            NameSpec = namespec;
            Status = namestatus;
            IDStatus = idstatus;
            NumberTalon = numtalon;
            ArrivingTime = arrivetime;
            RoomName = roomname;
            IDRoom = numofroom;
        }
        public ElementOfVisitorList(string sername, string fristname, string thirdname, string fiodoc, string namespec, string namestatus, int idstatus, int numtalon, DateTime arrivetime, string roomname, int numofroom, string telnumber)
        {
            SerName = sername;
            FirstName = fristname;
            ThridName = thirdname;
            FIODoc = fiodoc;
            NameSpec = namespec;
            Status = namestatus;
            IDStatus = idstatus;
            NumberTalon = numtalon;
            ArrivingTime = arrivetime;
            RoomName = roomname;
            IDRoom = numofroom;
            TelNumber = telnumber;
        }
    }
    public class Priem
    {
        public DateTime TimeOfPriem { get; set; }
        public bool NotFree { get; set; }
        public Priem(DateTime time, bool free)
        {
            TimeOfPriem = time;
            NotFree = free;
        }
        public Priem(DateTime time)
        {
            TimeOfPriem = time;
        }
    }
    public class ListForPriems
    {
        public List<Priem> listPriem = new List<Priem>();
        public ListForPriems()
        {
        }
        public void MakeTable(int shift)
        {
            List<Priem> templistofelements = listPriem;
            List<Priem> list = new List<Priem>();
            DateTime temp = new DateTime();
            switch (shift)
            {
                case 1:
                    {
                        temp = temp.AddHours(8);
                        break;
                    }
                case 2:
                    {
                        temp = temp.AddHours(15);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            for (int i = 0; i < 12; i++)
            {
                if (templistofelements.Find(x => x.TimeOfPriem.TimeOfDay == temp.TimeOfDay) == null)
                {
                    list.Add(new Priem(temp, false));
                }
                else
                {
                    list.Add(new Priem(temp, true));
                }
                temp = temp.AddMinutes(30);
            }
            listPriem.Clear();
            listPriem = list;
        }
    }
    public class Talon
    {
        public string NameOfVisitor { get; set; }
        public int ID { get; set; }
        public int IDMedVis { get; set; }
        public int IDStats { get; set; }
        public DateTime PaymentTime { get; set; }
        public decimal Cost { get; set; }
        public int IDDoc { get; set; }
        public int IDRegister { get; set; }
        public int IDWhoGiveTalon { get; set; }
        public DateTime TimeOfRegistration { get; set; }//время на которое записан
        public DateTime TimeWhenGiveTalon { get; set; }
        public DateTime TimeInTimeTable { get; set; }
        public DateTime NumInQueue { get; set; }
        public bool IsInTimeQuere { get; set; }
        public bool Exist { get; set; }
        public Talon(int id, int medvisid, int idstat, int iddoc, int idreg, DateTime timereg, DateTime timeintimetable, string sername, string name, string lastname)
        {
            NameOfVisitor = sername + " " + name + " " + lastname;
            ID = id;
            IDMedVis = medvisid;
            IDStats = idstat;
            IDDoc = iddoc;
            IDRegister = idreg;
            TimeOfRegistration = timereg;
            TimeInTimeTable = timeintimetable;
            Exist = true;
        }
        public Talon(int id, int medvisid, int idstat, int iddoc, int idreg, DateTime timereg, DateTime timeintimetable, string sername, string name, string lastname, DateTime time, bool IsIn)
        {
            NameOfVisitor = sername + " " + name + " " + lastname;
            ID = id;
            IDMedVis = medvisid;
            IDStats = idstat;
            IDDoc = iddoc;
            IDRegister = idreg;
            TimeOfRegistration = timereg;
            TimeInTimeTable = timeintimetable;
            NumInQueue = time;
            IsInTimeQuere = IsIn;
            Exist = true;
        }
        public Talon(DateTime a)
        {
            TimeInTimeTable = a;
            Exist = false;
        }
    }
    public class Republics
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Republics(string Name, int ID)
        {
            this.Name = Name;
            this.ID = ID;
        }
    }
    public class MedVisitor
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string SerName { get; set; }
        public string ThirdName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public string PhoneNum { get; set; }
        public int NumOfRep { get; set; }
        public int ID { get; set; }
        public MedVisitor(string FirstName, string SerName, string ThirdName, DateTime BirthDate, bool Sex, string PhoneNum, int NumOfRep, int ID)
        {
            this.FullName = SerName + " " + FirstName + " " + ThirdName;
            this.FirstName = FirstName;
            this.SerName = SerName;
            this.ThirdName = ThirdName;
            this.BirthDate = BirthDate;
            var today = DateTime.Now;
            var age = today.Year - BirthDate.Year;
            if (BirthDate > today.AddYears(-age)) age--;
            this.Age = age;
            this.Sex = Sex;
            this.PhoneNum = PhoneNum;
            this.NumOfRep = NumOfRep;
            this.ID = ID;
        }
    }
    public class Shift
    {
        public string NameOfShift { get; set; }
        public int NumShift { get; set; }
        public Shift(string name, int id)
        {
            this.NameOfShift = name;
            this.NumShift = id;
        }
        public Shift()
        {
        }
    }
    public class TimeTableElement
    {
        public DateTime Time { get; set; }
        public int Shifts { get; set; }
        public bool Avalable { get; set; }
        public TimeTableElement() { }
        public TimeTableElement(DateTime Time, int Shift)
        {
            this.Time = Time;
            this.Shifts = Shift;
        }
        public TimeTableElement(DateTime Time, int Shift, bool Avalable)
        {
            this.Time = Time;
            this.Shifts = Shift;
            this.Avalable = Avalable;
        }
    }

    public class TimeTableOfStom
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public DateTime MounthDate { get; set; }
        public bool IsChanged { get; set; }
        public ObservableCollection<TimeTableElement> elements = new ObservableCollection<TimeTableElement>();
        public TimeTableOfStom() { }
        public void MakeTable()
        {
            ObservableCollection<TimeTableElement> templistofelements = elements;
            List<TimeTableElement> list = new List<TimeTableElement>();
            foreach (TimeTableElement a in elements)
            {
                list.Add(a);
            }
            elements.Clear();
            DateTime time = new DateTime(MounthDate.Year, MounthDate.Month, 1);
            string DayOfWeek = time.DayOfWeek.ToString();
            int DayInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int firstindex = 0;
            switch (DayOfWeek)
            {
                case "Monday":
                    {
                        firstindex = 0;
                        break;
                    }
                case "Tuesday":
                    {
                        firstindex = 1;
                        break;
                    }
                case "Wednesday":
                    {
                        firstindex = 2;
                        break;
                    }
                case "Thursday":
                    {
                        firstindex = 3;
                        break;
                    }
                case "Friday":
                    {
                        firstindex = 4;
                        break;
                    }
                case "Saturday":
                    {
                        firstindex = 5;
                        break;
                    }
                case "Sunday":
                    {
                        firstindex = 6;
                        break;
                    }
            }
            int tempnumber = -firstindex;
            time = time.AddDays(-firstindex);
            for (int i = 0; i < 42; i++)
            {
                if (time.Month == MounthDate.Month)
                {
                    TimeTableElement temp = list.Find(p => p.Time == time);
                    if (temp != null)
                    {
                        if (temp.Time.Month == DateTime.Now.Month && temp.Time.Day <= DateTime.Now.Day)
                        {
                            elements.Add(new TimeTableElement(temp.Time, temp.Shifts, false));
                        }
                        else
                        {
                            elements.Add(new TimeTableElement(temp.Time, temp.Shifts, true));
                        }
                    }
                    else
                    {
                        if (time.Month == DateTime.Now.Month && time.Day <= DateTime.Now.Day)
                        {
                            elements.Add(new TimeTableElement(time, 3, false));
                        }
                        else
                        {
                            elements.Add(new TimeTableElement(time, 3, true));
                        }
                    }
                }
                else
                {
                    elements.Add(new TimeTableElement(time, 4));
                }
                time = time.AddDays(+1);
            }
        }
    }
 
    public class Spec
    {
        public string NameSpec
        {
            get; set;
        }
        public int ID1
        {
            get; set;
        }
        public Spec(string Name, int ID)
        {
            this.NameSpec = Name;
            this.ID1 = ID;
        }
    }
    public class Rooms
    {
        public string NameRooms
        {
            get; set;
        }
        public int ID2
        {
            get; set;
        }
        public Rooms(string Name, int ID)
        {
            this.NameRooms = Name;
            this.ID2 = ID;
        }
        public Rooms()
        {

        }
    }
    public class WorkerFull
    {
        public string Name
        {
            get; set;
        }
        public int SpecNum
        {
            get; set;
        }
        public string Pass
        {
            get; set;
        }
        public int NumRoom
        {
            get; set;
        }
        public int NumStatus
        {
            get; set;
        }
        public int ID
        {
            get; set;
        }
        public WorkerFull(string Name, int Spec, string Pass, int NumRoom, int ID, int Status)
        {
            this.Name = Name;
            this.SpecNum = Spec;
            this.Pass = Pass;
            this.NumRoom = NumRoom;
            this.ID = ID;
            NumStatus = Status;
        }
        public WorkerFull(string Name, int ID, int Status)
        {
            this.Name = Name;



            this.ID = ID;
            NumStatus = Status;
        }
        public WorkerFull()
        {

        }
    }
    public class Status
    {
        public string Name { get; set; }
        public int IDStatus { get; set; }
        public Status(string name, int id)
        {
            Name = name;
            IDStatus = id;
        }
    }
    public class Connection
    {
        static public string GetConSTR()
        {
            string str = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return str;
        }
    }
    public class MonthesNames
    {
        static public List<int> GetMonthes()
        {
            List<int> monthes = new List<int>();
            for (int i = 1; i < 13; i++)
            {
                monthes.Add(i);
            }
            return monthes;
        }
        static public List<string> GetDates()
        {
            List<string> temp = new List<string>();
            DateTime temp1 = DateTime.Now;
            for (int i = 0; i < 31; i++)
            {
                temp.Add(temp1.ToShortDateString());
                temp1 = temp1.AddDays(1);
            }
            return temp;
        }
        static public List<int> GetYears()
        {
            List<int> years = new List<int>();
            for (int i = DateTime.Now.Year - 90; i < DateTime.Now.Year; i++)
            {
                years.Add(i);
            }
            return years;
        }
        static public List<int> GetDays(int month, int year)
        {
            List<int> days = new List<int>();
            for (int i = 1; i < DateTime.DaysInMonth(year, month) + 1; i++)
            {
                days.Add(i);
            }
            return days;
        }
        static public string GetMonthName(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        return "Янаварь";
                    }
                case 2:
                    {
                        return "Февраль";
                    }
                case 3:
                    {
                        return "Март";
                    }
                case 4:
                    {
                        return "Апрель";
                    }
                case 5:
                    {
                        return "Май";
                    }
                case 6:
                    {
                        return "Июнь";
                    }
                case 7:
                    {
                        return "Июль";
                    }
                case 8:
                    {
                        return "Август";
                    }
                case 9:
                    {
                        return "Сентябрь";
                    }
                case 10:
                    {
                        return "Октябрь";
                    }
                case 11:
                    {
                        return "Ноябрь";
                    }
                case 12:
                    {
                        return "Декабрь";
                    }
                default:
                    {
                        return "Несуществующий номер месяца";
                    }
            }
        }
    }
    public class Inizialize
    {
        static public List<WorkerFull> FillCombobox()
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            SqlCommand com1 = new SqlCommand("Select ФИО,Специальность , ID,Статус_сотрудника From ПерсоналСпец Order by ФИО DESC", con);
            con.Open();
            SqlDataReader reader1 = com1.ExecuteReader();
            List<WorkerFull> WorkerList = new List<WorkerFull>();
            while (reader1.Read())
            {
                WorkerList.Add(new WorkerFull(reader1.GetString(0) + $" ({reader1.GetString(1)})", reader1.GetInt32(2), reader1.GetInt32(3)));
            }
            reader1.Close();
            return WorkerList;
        }
        static public int Autorization(int ID, string Pass)
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand($"Select Пароль,Номер_специализации From ПерсоналСпец Where ID={ID}", con);
            SqlDataReader reader1 = com.ExecuteReader();
            string pass = "";
            int spec = 0;
            while (reader1.Read())
            {
                pass = reader1.GetString(0);
                spec = reader1.GetInt32(1);
            }
            reader1.Close();
            pass = pass.Replace(" ", "");
            if (pass == Pass)
            {
                return spec;
            }
            else
            {
                return -1;
            }
        }
    }
    public class WorkWithData
    {
        static public List<Obrashen> LoadObrashen()
        {
            List<Obrashen> temp = new List<Obrashen>();
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand($"Select * From ОтчётОбращен", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp.Add(new Obrashen(reader.GetInt32(1),reader.GetString(2)+" "+reader.GetString(3)+" "+reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetDecimal(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetDateTime(11), reader.GetDateTime(12), reader.GetString(13)));
            }
            con.Close();
            return temp;
        }
        static public List<Obrashen> LoadObrashen(int IDVisitor)
        {
            List<Obrashen> temp = new List<Obrashen>();
            SqlConnection con = new SqlConnection(Connection.GetConSTR()) ;
            con.Open();
            SqlCommand com = new SqlCommand($"Select * From Обращения Where Номер_пациента={IDVisitor}",con);
            SqlDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                temp.Add(new Obrashen(reader.GetInt32(1),reader.GetString(3),reader.GetDateTime(4),reader.GetDecimal(5),reader.GetString(6),reader.GetString(7),reader.GetString(8),reader.GetDateTime(9),reader.GetDateTime(10),reader.GetString(11)));
            }
            con.Close();
            return temp;
        }
        static public void EndtalonMethod(EndTalon a,string cost,string usluga,int numtalon2)
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR()); ;
            con.Open();
            SqlCommand com = new SqlCommand("InsertIntoObrashen", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter Param1 = new SqlParameter
            {
                ParameterName = "@NumTalon"
            };
            SqlParameter Param2 = new SqlParameter
            {
                ParameterName = "@Numpacient"
            };
            SqlParameter Param3 = new SqlParameter
            {
                ParameterName = "@NumStatus"
            };
            SqlParameter Param4 = new SqlParameter
            {
                ParameterName = "@Dateoplata"
            };
            SqlParameter Param5 = new SqlParameter
            {
                ParameterName = "@Cost"
            };
            SqlParameter Param6 = new SqlParameter
            {
                ParameterName = "@NumSpecial"
              
            };
            SqlParameter Param7 = new SqlParameter
            {
                ParameterName = "@NumReg"
            };
            SqlParameter Param8 = new SqlParameter
            {
                ParameterName = "@Numvidavshtalon"

            };
            SqlParameter Param9 = new SqlParameter
            {
                ParameterName = "@Datewrite"

            };
            SqlParameter Param10 = new SqlParameter
            {
                ParameterName = "@GiveDate"

            };
            SqlParameter Param11 = new SqlParameter
            {
                ParameterName = "@Usluga"

            };
            SqlParameter Param12 = new SqlParameter
            {
                ParameterName = "@NumTalon2"

            };
            com.Parameters.Add(Param1);
            com.Parameters.Add(Param2);
            com.Parameters.Add(Param3);
            com.Parameters.Add(Param4);
            com.Parameters.Add(Param5);
            com.Parameters.Add(Param6);
            com.Parameters.Add(Param7);
            com.Parameters.Add(Param8);
            com.Parameters.Add(Param9);
            com.Parameters.Add(Param10);
            com.Parameters.Add(Param11);
            com.Parameters.Add(Param12);
            com.Parameters["@NumTalon"].Value = a.TalonNum;
            com.Parameters["@Numpacient"].Value = a.IdPac;
            com.Parameters["@NumStatus"].Value = a.IdStatus;
            com.Parameters["@Dateoplata"].Value = DateTime.Now;
            com.Parameters["@Cost"].Value = Convert.ToDecimal(cost);
            com.Parameters["@NumSpecial"].Value = a.IdSpeccial;
            com.Parameters["@NumReg"].Value = a.IdReg;
            com.Parameters["@Numvidavshtalon"].Value = a.IdGiveTalon;
            com.Parameters["@Datewrite"].Value = a.writedate;
            com.Parameters["@GiveDate"].Value = a.givetalon;
            com.Parameters["@Usluga"].Value = usluga;
            com.Parameters["@NumTalon2"].Value = numtalon2;
            com.ExecuteNonQuery();
            con.Close();
        }
        static public void DeletefromTalons(int Idtalon)
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand($"Delete from Талон where Номер_талона={Idtalon}", con);
            com.ExecuteNonQuery();
            con.Close();
        }
        static public List<Status> LoadStatus()
        {
            List<Status> temp = new List<Status>();
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand("select * From Статус", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp.Add(new Status(reader.GetString(0), reader.GetInt32(1)));
            }
            con.Close();
            return temp;
        }
        static public EndTalon EndTalonLoad(int ID)
        {
            EndTalon temp = new EndTalon();
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand($"Select * from EndTalon Where Номер_талона={ID}", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp = new EndTalon(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetInt32(4), reader.GetBoolean(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8), reader.GetDateTime(9), reader.GetString(10), reader.GetString(11), reader.GetString(12),reader.GetInt32(13),reader.GetInt32(14),reader.GetInt32(15),reader.GetInt32(16),reader.GetInt32(17),reader.GetDateTime(18),reader.GetDateTime(19));
            }
            con.Close();
            return temp;
        }
        static public ObservableCollection<EmplStatus> LoadEpmpstatus()
        {
            ObservableCollection<EmplStatus> temp = new ObservableCollection<EmplStatus>();
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand("Select * From Статус_сотрудника", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp.Add(new EmplStatus(reader.GetString(0), reader.GetInt32(1)));
            }
            con.Close();
            return temp;
        }
        static public ObservableCollection<Talon> MakeTableOFTalons(int shift, ObservableCollection<Talon> a)
        {
            DateTime temp = new DateTime();
            List<Talon> listt = new List<Talon>();
            foreach (Talon b in a)
            {
                listt.Add(b);
            }
            switch (shift)
            {
                case 1:
                    {
                        temp = temp.AddHours(8);
                        break;
                    }
                case 2:
                    {
                        temp = temp.AddHours(15);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            a.Clear();
            for (int i = 0; i < 12; i++)
            {
                if (listt.Find(x => x.TimeInTimeTable.TimeOfDay == temp.TimeOfDay) == null)
                {
                    a.Add(new Talon(temp));
                }
                else
                {
                    a.Add(listt.Find(x => x.TimeInTimeTable.TimeOfDay == temp.TimeOfDay));
                }
                temp = temp.AddMinutes(30);
            }
            return a;
        }
        static public List<Talon> LoadTalonsUnQueue(int ID)
        {
            List<Talon> temp = new List<Talon>();
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand($"Select * From Талоны Where Номер_специалиста={ID} and Day(Время_обращения)=Day(Cast('{DateTime.Now}' as smalldatetime)) and Month(Время_обращения)=Month(Cast('{DateTime.Now}' as smalldatetime)) and Вне_очереди=1 and Номер_статуса!=3", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp.Add(new Talon(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(5), reader.GetInt32(6), reader.GetDateTime(8), reader.GetDateTime(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetDateTime(14), true));
            }
            reader.Close();
            temp = temp.OrderBy(x => x.NumInQueue).ToList();
            return temp;
        }
        static public ObservableCollection<Talon> LoadTalons(int ID)
        {
            int shift = 0;
            ObservableCollection<Talon> temp = new ObservableCollection<Talon>();
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand($"Select * From Талоны Where Номер_специалиста={ID} and Day(Время_обращения)=Day(Cast('{DateTime.Now}' as smalldatetime)) and Month(Время_обращения)=Month(Cast('{DateTime.Now}' as smalldatetime)) and Вне_очереди=0 and Номер_статуса!=3", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp.Add(new Talon(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(5), reader.GetInt32(6), reader.GetDateTime(9), reader.GetDateTime(10), reader.GetString(11), reader.GetString(12), reader.GetString(13)));
            }
            reader.Close();
            com = new SqlCommand($"Select Смена From Расписание Where Номер_врача={ID} and Day(Дата)=Day(Cast('{DateTime.Now}' as date)) and Month(Дата)=Month(Cast('{DateTime.Now}' as date)) ", con);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                shift = reader.GetInt32(0);
            }
            con.Close();
            return MakeTableOFTalons(shift, temp);
        }
        static public void ChangeStatus(int idtalon, int status, int id)
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand($"Update Талон Set Номер_статуса={status}, Время_выдачи=cast('{DateTime.Now}'  as smalldatetime), Номер_выдавшего_талон={id} Where Номер_талона={idtalon}", con);
            com.ExecuteNonQuery();
            con.Close();
        }
        static public ObservableCollection<ElementOfVisitorList> ListOfVisits()
        {
            ObservableCollection<ElementOfVisitorList> temp = new ObservableCollection<ElementOfVisitorList>();
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand($"Select * From СписокЗаписей Where Day(Время_обращения)>=Day(cast('{DateTime.Now.ToString()}' as smalldatetime))", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp.Add(new ElementOfVisitorList(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetDateTime(8), reader.GetString(9), reader.GetInt32(10)));
            }
            con.Close();
            return temp;
        }
        static public string WriteTalon(int ID, MedVisitor a, WorkerFull b, Priem c, TimeTableElement d)
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand("WriteTalon", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter ParamName = new SqlParameter
            {
                ParameterName = "@NumPac"
            };
            SqlParameter ParamName1 = new SqlParameter
            {
                ParameterName = "@NumSpec"
            };
            SqlParameter ParamName2 = new SqlParameter
            {
                ParameterName = "@NumReg"
            };
            SqlParameter ParamName3 = new SqlParameter
            {
                ParameterName = "@TimeOfReg"
            };
            SqlParameter ParamName4 = new SqlParameter
            {
                ParameterName = "@TimeOFArr"
            };
            SqlParameter ParamName5 = new SqlParameter
            {
                ParameterName = "@Res",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            com.Parameters.Add(ParamName);
            com.Parameters.Add(ParamName1);
            com.Parameters.Add(ParamName2);
            com.Parameters.Add(ParamName3);
            com.Parameters.Add(ParamName4);
            com.Parameters.Add(ParamName5);

            com.Parameters["@NumPac"].Value = a.ID;
            com.Parameters["@NumSpec"].Value = b.ID;
            com.Parameters["@NunReg"].Value = ID;
            com.Parameters["@TimeOfReg"].Value = DateTime.Now;
            com.Parameters["@TimeOFArr"].Value = new DateTime(d.Time.Year, d.Time.Month, d.Time.Day, c.TimeOfPriem.Hour, c.TimeOfPriem.Minute, 0);
            com.ExecuteNonQuery();
           
            if ((int)com.Parameters["@Res"].Value == 1)
            {
                con.Close();
                return "Операция успешно завершена!";
            }
            else
            {
                con.Close();
                return "Этот пациент уже записан на это время к другому стоматологу!";
            }

            //SqlCommand com = new SqlCommand($"Insert into Талон(Номер_пацинета,Номер_статуса,Номер_специалиста,Номер_регистратора,Время_записи,Время_обращения) Values({a.ID},1,{b.ID},{ID},Cast('{DateTime.Now.ToString()}' as smalldatetime),Cast('{new DateTime(d.Time.Year, d.Time.Month, d.Time.Day, c.TimeOfPriem.Hour, c.TimeOfPriem.Minute, 0)}' as smalldatetime))", con);
            //com.ExecuteNonQuery();
          
        }
        static public void WriteTalonUnQueue(int ID, MedVisitor a, WorkerFull b)
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand("InsertUnQuere", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter MedVisID = new SqlParameter
            {
                ParameterName = "@NumMedVis"
            };
            SqlParameter NumSpecID = new SqlParameter
            {
                ParameterName = "@NumSpec"
            };
            SqlParameter NumRegID = new SqlParameter
            {
                ParameterName = "@NunReg"
            };
            SqlParameter NumGiveTalonID = new SqlParameter
            {
                ParameterName = "@NumGiveTalon"
            };
            com.Parameters.Add(MedVisID);
            com.Parameters.Add(NumSpecID);
            com.Parameters.Add(NumRegID);
            com.Parameters.Add(NumGiveTalonID);
            com.Parameters["@NumMedVis"].Value = a.ID;
            com.Parameters["@NumSpec"].Value = b.ID;
            com.Parameters["@NunReg"].Value = ID;
            com.Parameters["@NumGiveTalon"].Value = ID;
            com.ExecuteNonQuery();
            con.Close();
        }
        static public ListForPriems CheckTimeTableForTalon(WorkerFull a, TimeTableElement b)
        {
            int shift = 0;
            ListForPriems temp = new ListForPriems();
            if (b != null)
            {
                SqlConnection con = new SqlConnection(Connection.GetConSTR());
                con.Open();
                SqlCommand com = new SqlCommand($"Select Время_обращения From Талон Where Номер_специалиста={a.ID} and Day(Время_обращения)=Day(Cast('{b.Time}' as smalldatetime))", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    temp.listPriem.Add(new Priem(reader.GetDateTime(0)));
                }
                reader.Close();
                com = new SqlCommand($"Select Смена From Расписание Where Номер_врача={a.ID} and Day(Дата)=Day(Cast('{b.Time}' as date)) and Month(Дата)=Month(Cast('{b.Time}' as date)) ", con);
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    shift = reader.GetInt32(0);
                }
                con.Close();
                temp.MakeTable(shift);
            }
            return temp;
        }
        static public void SaveAMBCard(MedVisitor a)
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com;
            if (a.ID == 0)
            {
                com = new SqlCommand($"Insert into Амбулаторная_карта Values('{a.SerName}','{a.FirstName}','{a.ThirdName}',Cast('{a.BirthDate.ToShortDateString()}' as Date),{a.Age},'{a.Sex}','{a.PhoneNum}',{a.NumOfRep})", con);
            }
            else
            {
                com = new SqlCommand($"Update Амбулаторная_карта Set Фамилия='{a.SerName}', Имя='{a.FirstName}', Отчество='{a.ThirdName}',Дата_рождения=Cast('{a.BirthDate.ToShortDateString()}' as Date), Возраст={a.Age}, Пол='{a.Sex}', Телефон='{a.PhoneNum}', Номер_Граждантсво={a.NumOfRep}  Where ID={a.ID}", con);
            }
            com.ExecuteNonQuery();
            con.Close();
        }
        static public ObservableCollection<MedVisitor> LoadMedVis()
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand("Select * From Амбулаторная_карта", con);
            ObservableCollection<MedVisitor> temp = new ObservableCollection<MedVisitor>();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp.Add(new MedVisitor(reader.GetString(1), reader.GetString(0), reader.GetString(2), reader.GetDateTime(3), reader.GetBoolean(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8)));
            }
            con.Close();
            return temp;
        }
        static public List<Republics> LoadRepub()
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand("Select * From Гражднаство", con);
            List<Republics> temp = new List<Republics>();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp.Add(new Republics(reader.GetString(1), reader.GetInt32(0)));
            }
            con.Close();
            return temp;
        }
        static public ObservableCollection<WorkerFull> LoadData(bool parametr)
        {
            if (parametr == false)
            {
                SqlConnection myConnection = new SqlConnection(Connection.GetConSTR());
                myConnection.Open();
                SqlCommand command = new SqlCommand("Select * From Персонал", myConnection);
                SqlDataReader reader = command.ExecuteReader();
                ObservableCollection<WorkerFull> data = new ObservableCollection<WorkerFull>();
                while (reader.Read())
                {
                    data.Add(new WorkerFull(reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(5), reader.GetInt32(4)));
                }
                reader.Close();
                myConnection.Close();
                return data;
            }
            else
            {
                SqlConnection myConnection = new SqlConnection(Connection.GetConSTR());
                myConnection.Open();
                SqlCommand command = new SqlCommand("Select * From ПерсоналСпец Where Номер_специализации != 1 and Номер_специализации !=  2", myConnection);
                SqlDataReader reader = command.ExecuteReader();
                ObservableCollection<WorkerFull> data = new ObservableCollection<WorkerFull>();
                while (reader.Read())
                {

                    data.Add(new WorkerFull(reader.GetString(0) + $" ({reader.GetString(1)}) ", reader.GetInt32(4), reader.GetString(3), reader.GetInt32(5), reader.GetInt32(2), reader.GetInt32(6)));
                }
                reader.Close();
                myConnection.Close();
                return data;
            }
        }
        static public ObservableCollection<Spec> LoadSpec()
        {
            SqlConnection myConnection = new SqlConnection(Connection.GetConSTR());
            myConnection.Open();
            SqlCommand command = new SqlCommand("Select * From Специализация", myConnection);
            SqlDataReader reader = command.ExecuteReader();
            ObservableCollection<Spec> data = new ObservableCollection<Spec>();
            while (reader.Read())
            {
                data.Add(new Spec(reader.GetString(0), reader.GetInt32(1)));
            }
            reader.Close();
            myConnection.Close();
            return data;
        }
        static public ObservableCollection<Rooms> LoadRoom()
        {
            SqlConnection myConnection = new SqlConnection(Connection.GetConSTR());
            myConnection.Open();
            SqlCommand command = new SqlCommand("Select * From Кабинеты", myConnection);
            SqlDataReader reader = command.ExecuteReader();
            ObservableCollection<Rooms> data = new ObservableCollection<Rooms>();
            while (reader.Read())
            {

                data.Add(new Rooms(reader.GetString(0), reader.GetInt32(1)));
            }
            reader.Close();
            myConnection.Close();
            return data;
        }
       
        static public int InsertOrUpdateEmpl(WorkerFull a)
        {
            SqlConnection myConnection = new SqlConnection(Connection.GetConSTR());
            myConnection.Open();
            if (a.ID == 0)
            {
                SqlCommand com = new SqlCommand("GetInsertedID", myConnection);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter ParamName = new SqlParameter
                {
                    ParameterName = "@Name"
                };
                SqlParameter ParamSpecNum = new SqlParameter
                {
                    ParameterName = "@SpecNum"
                };
                SqlParameter ParamPass = new SqlParameter
                {
                    ParameterName = "@Pass"
                };
                SqlParameter ParamNumRoom = new SqlParameter
                {
                    ParameterName = "@NumRoom"
                };
                SqlParameter ParamNumStatus = new SqlParameter
                {
                    ParameterName = "@NumStatus"
                };
                SqlParameter ParamID = new SqlParameter
                {
                    ParameterName = "@ID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output
                };
                com.Parameters.Add(ParamName);
                com.Parameters.Add(ParamSpecNum);
                com.Parameters.Add(ParamPass);
                com.Parameters.Add(ParamNumRoom);
                com.Parameters.Add(ParamNumStatus);
                com.Parameters.Add(ParamID);
                com.Parameters["@Name"].Value = a.Name;
                com.Parameters["@SpecNum"].Value = a.SpecNum;
                com.Parameters["@Pass"].Value = a.Pass;
                com.Parameters["@NumRoom"].Value = a.NumRoom;
                com.Parameters["@NumStatus"].Value = a.NumStatus;
                com.ExecuteNonQuery();
                return (int)com.Parameters["@ID"].Value;
            }
            else
            {
                SqlCommand com = new SqlCommand("CheckUpdateEmpl", myConnection);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter ParamName = new SqlParameter
                {
                    ParameterName = "@Name"
                };
                SqlParameter ParamSpecNum = new SqlParameter
                {
                    ParameterName = "@SpecNum"
                };
                SqlParameter ParamPass = new SqlParameter
                {
                    ParameterName = "@Pass"
                };
                SqlParameter ParamNumRoom = new SqlParameter
                {
                    ParameterName = "@NumRoom"
                };
                SqlParameter ParamNumStatus = new SqlParameter
                {
                    ParameterName = "@NumStatus"
                };
                SqlParameter ParamID = new SqlParameter
                {
                    ParameterName = "@ID",
         
                };
                com.Parameters.Add(ParamName);
                com.Parameters.Add(ParamSpecNum);
                com.Parameters.Add(ParamPass);
                com.Parameters.Add(ParamNumRoom);
                com.Parameters.Add(ParamNumStatus);
                com.Parameters.Add(ParamID);
                com.Parameters["@Name"].Value = a.Name;
                com.Parameters["@SpecNum"].Value = a.SpecNum;
                com.Parameters["@Pass"].Value = a.Pass;
                com.Parameters["@NumRoom"].Value = a.NumRoom;
                com.Parameters["@NumStatus"].Value = a.NumStatus;
                com.Parameters["@ID"].Value = a.ID;
                com.ExecuteNonQuery();
                //SqlCommand command = new SqlCommand($"Update Персонал Set ФИО='{a.Name}',Номер_специализации={a.SpecNum},Пароль='{a.Pass}',Номер_кабинета={a.NumRoom},Статус_сотрудника={a.NumStatus} Where ID={a.ID}", myConnection);
                //command.ExecuteNonQuery();
                return -1;
            }
        }
        static public int InsertOrUpdateRoom(Rooms a)
        {
            SqlConnection myConnection = new SqlConnection(Connection.GetConSTR());
            myConnection.Open();
            if (a.ID2 == 0)
            {
                SqlCommand com = new SqlCommand("GetRoomID", myConnection);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter ParamName = new SqlParameter
                {
                    ParameterName = "@Name"
                };
                SqlParameter ParamID = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output
                };
                com.Parameters.Add(ParamName);
                com.Parameters.Add(ParamID);
                com.Parameters["@Name"].Value = a.NameRooms;
                com.ExecuteNonQuery();
                return (int)com.Parameters["@Id"].Value;
            }
            else
            {
                SqlCommand command = new SqlCommand($"Update Кабинеты Set Наименование='{a.NameRooms}' Where Номер_Кабинета={a.ID2}", myConnection);
                command.ExecuteNonQuery();
                return -1;
            }
        }
        static public TimeTableOfStom TimeTableCheck(int ID, DateTime Mounth, string name)
        {
            TimeTableOfStom temp = new TimeTableOfStom();
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand($"Select * From Расписание Where Номер_врача={ID} and Month(Дата)={Mounth.Month} Order By Дата ASC", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp.elements.Add(new TimeTableElement(reader.GetDateTime(1), reader.GetInt32(0)));
            }
            temp.ID = ID;
            temp.Name = name;
            temp.MounthDate = Mounth;
            temp.MakeTable();
            return temp;
        }
        static public void SaveElementInTimeTable(TimeTableOfStom mainelement, List<TimeTableElement> table)
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand("CheckOfUpdate", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter Param1 = new SqlParameter
            {
                ParameterName = "@Shift"
            };
            SqlParameter Param2 = new SqlParameter
            {
                ParameterName = "@Date"
            };
            SqlParameter Param3 = new SqlParameter
            {
                ParameterName = "@NumOfStom"
            };
            SqlParameter Param4 = new SqlParameter
            {
                ParameterName = "@IsChanged",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            com.Parameters.Add(Param1);
            com.Parameters.Add(Param2);
            com.Parameters.Add(Param3);
            com.Parameters.Add(Param4);
            foreach (TimeTableElement a in mainelement.elements)
            {
                if (a.Shifts == 4)
                {
                    table.Remove(a);
                }
                else
                {
                    com.Parameters["@Shift"].Value = a.Shifts;
                    com.Parameters["@Date"].Value = a.Time;
                    com.Parameters["@NumOfStom"].Value = mainelement.ID;
                    com.ExecuteNonQuery();
                    if ((int)com.Parameters["@IsChanged"].Value != 0)
                    {
                        table.Remove(a);
                    }
                }
            }
            foreach (TimeTableElement a in table)
            {
                com = new SqlCommand($"Insert into Расписание(Смена,Дата,Номер_врача) Values({a.Shifts},Cast('{a.Time.ToShortDateString()}' as Date) , {mainelement.ID})", con);
                com.ExecuteNonQuery();
            }
            con.Close();
        }
        static public void DeleteElementInTimeTable(TimeTableOfStom mainelement, List<TimeTableElement> table)
        {
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com;
            foreach (TimeTableElement a in table)
            {
                com = new SqlCommand($"Delete from Расписание Where Номер_врача={mainelement.ID} and Дата=Cast('{a.Time.ToShortDateString()}' as Date)", con);
                com.ExecuteNonQuery();
            }
            con.Close();
        }

        static public ObservableCollection<ElementOfVisitorList> LoadTalons()
        {
            ObservableCollection<ElementOfVisitorList> temp = new ObservableCollection<ElementOfVisitorList>();
            SqlConnection con = new SqlConnection(Connection.GetConSTR());
            con.Open();
            SqlCommand com = new SqlCommand("Select * From СписокЗаписей", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                temp.Add(new ElementOfVisitorList(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetDateTime(8), reader.GetString(9), reader.GetInt32(10), reader.GetString(12)));
            }
            con.Close();
            return temp;
        }

    }
}
