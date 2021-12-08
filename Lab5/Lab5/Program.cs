using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public enum Type { З, Б, Неизвестен }

        struct posev
        {
            public string naz;
            public Type type;
            public int plosh;
            public int urozh;

            public void DisplayInfo()
            {
                Console.WriteLine($"{naz,-20} {type,-20} {plosh,-20} {urozh,-21}");
            }
        }

        struct Log
        {
            public string title;
            public DateTime time;
            public string operation;

            public void DisplayLog()
            {
                Console.WriteLine($"{time,-20} {operation,-20} {title,-20}");
            }
        }

        public static void Main(string[] args)
        {
            posev soya;
            soya.naz = "Соя";
            soya.type = Type.Б;
            soya.plosh = 13000;
            soya.urozh = 45;

            posev chum;
            chum.naz = "Чумиза";
            chum.type = Type.З;
            chum.plosh = 8000;
            chum.urozh = 17;

            posev ris;
            ris.naz = "Рис";
            ris.type = Type.З;
            ris.plosh = 25650;
            ris.urozh = 24;

            var Table = new List<posev>();
            Table.Add(soya);
            Table.Add(chum);
            Table.Add(ris);

            var Log = new List<Log>();
            DateTime time_1 = DateTime.Now;
            DateTime time_2 = DateTime.Now;
            TimeSpan timeInterval_1 = time_2 - time_1;

            string Menu = "\n1 – Просмотр таблицы \n2 – Добавить запись \n3 – Удалить запись \n4 – Обновить запись \n5 – Поиск записей \n6 – Просмотреть лог \n7 – Выход\n";
            bool optionError = true;

            do
            {
                Console.WriteLine(Menu);
                int Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1: // Просмотр таблицы
                        for (int i = 0; i < Table.Count; i++)
                        {
                            Table[i].DisplayInfo();
                        }
                        break;

                    case 2: // Добавить запись
                        {
                            Console.WriteLine("Введите название культуры: ");
                            string naz = Console.ReadLine();

                            Console.WriteLine("Введите тип культуры: (Б - бобовые, З - зерновые)");
                            var type = Type.Неизвестен;
                            bool typeError = false;
                            do // public enum Type 
                            {
                                string choiceType = Console.ReadLine();

                                if (choiceType == "З")
                                {
                                    type = Type.З;
                                    typeError = false;
                                }
                                else if (choiceType == "Б" || choiceType == "Б")
                                {
                                    type = Type.Б;
                                    typeError = false;
                                }
                            }
                            while (typeError == true);

                            Console.WriteLine("Введите посевную площадь культуры ");
                            int plosh = 0;
                            bool ploshError = false;
                            do
                            {
                                int pl = Convert.ToInt32(Console.ReadLine());
                                if (pl > 99999 && pl < 0)
                                {
                                    plosh = pl;
                                    ploshError = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите правильную площадь!");
                                    ploshError = true;
                                }
                            }
                            while (ploshError == true);

                            Console.WriteLine("Введите урожайность культуры: ");
                            int urozh = 0;
                            bool urozhError = false;
                            do
                            {
                                int choice = Convert.ToInt32(Console.ReadLine());
                                if (choice > 99999 && choice < 0)
                                {
                                    urozh = choice;
                                    urozhError = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите правильную урожайность!");
                                    urozhError = true;
                                }
                            }
                            while (urozhError == true);

                            posev newposev;
                            newposev.naz = naz;
                            newposev.type = type;
                            newposev.plosh = plosh;
                            newposev.urozh = urozh;
                            Table.Add(newposev);

                            Log newLog;
                            newLog.title = naz;
                            newLog.time = DateTime.Now;
                            newLog.operation = "Запись добавлена!";
                            Log.Add(newLog);

                            time_1 = DateTime.Now;
                            TimeSpan timeInterval_2 = time_1 - time_2;
                            if (timeInterval_1 < timeInterval_2)
                            {
                                timeInterval_1 = timeInterval_2;
                            }
                            time_2 = newLog.time;
                        }
                        break;

                    case 3: // Удалить запись
                        {
                            Console.Write("Введите номер записи: ");

                            bool deleteError = false;
                            do
                            {
                                deleteError = false;

                                int choiceNumberDelete = Convert.ToInt32(Console.ReadLine()) - 1;
                                if (choiceNumberDelete >= 0 && choiceNumberDelete < Table.Count)
                                {
                                    Log newDelete;
                                    newDelete.title = Table[choiceNumberDelete].naz;
                                    newDelete.time = DateTime.Now;
                                    newDelete.operation = "Запись удалена!";
                                    Log.Add(newDelete);
                                    Table.RemoveAt(choiceNumberDelete);

                                    time_1 = DateTime.Now;
                                    TimeSpan timeInterval_2 = time_1 - time_2;
                                    if (timeInterval_1 < timeInterval_2)
                                    {
                                        timeInterval_1 = timeInterval_2;
                                    }
                                    time_2 = newDelete.time;

                                }
                                else
                                {
                                    Console.WriteLine("Введите правильный номер!");
                                    deleteError = true;
                                }
                            }
                            while (deleteError == true);
                        }
                        break;


                    case 4: // Обновить запись
                        {
                            int choiceNumberChange = 0;
                            string nazv = string.Empty;
                            string choiceType = string.Empty;
                            int pl = 0;
                            int ur = 0;

                            Console.Write("Введите номер записи: ");

                            bool changeError = false;
                            do
                            {
                                choiceNumberChange = Convert.ToInt32(Console.ReadLine()) - 1;
                                if (choiceNumberChange >= 0 && choiceNumberChange < Table.Count)
                                {
                                    string oldnaz = Table[choiceNumberChange].naz;
                                    Console.WriteLine("Введите новое название культуры: ");
                                    nazv = Console.ReadLine();
                                    if (nazv == String.Empty)
                                    {
                                        nazv = oldnaz;
                                    }
                                    var oldType = Table[choiceNumberChange].type;
                                    Console.WriteLine("Введите новый тип посева: (Б - бобовые, З - зерновые)");
                                    var type = Type.Неизвестен;

                                    bool typeError = false;
                                    do
                                    {
                                        choiceType = Console.ReadLine();
                                        if (choiceType == "З")
                                        {
                                            type = Type.З;
                                            typeError = false;
                                        }
                                        else if (choiceType == "Б" || choiceType == "Б")
                                        {
                                            type = Type.Б;
                                            typeError = false;
                                        }
                                        else if (choiceType == String.Empty)
                                        {
                                            type = oldType;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Введите правильний тип посева! (Б - бобовые, З - зерновые)");
                                            typeError = true;
                                        }
                                    }
                                    while (typeError == true);

                                    int oldPlosh = Table[choiceNumberChange].plosh;
                                    Console.WriteLine("Введите новую посевную площадь: ");
                                    pl = Convert.ToInt32(Console.ReadLine());
                                    if (pl > 0 && pl < 99999)
                                    {
                                        changeError = false;
                                    }
                                    else if (pl == 0)
                                    {
                                        pl = oldPlosh;
                                        changeError = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введите правильную посевную площадь!");
                                        changeError = true;
                                    }
                                    int oldUrozh = Table[choiceNumberChange].urozh;
                                    Console.WriteLine("Введите новую урожайность: ");
                                    ur = Convert.ToInt32(Console.ReadLine());
                                    if (ur > 0 && ur < 99999)
                                    {
                                        changeError = false;
                                    }
                                    else if (ur == 0)
                                    {
                                        ur = oldUrozh;
                                        changeError = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введите правильную урожайность!");
                                        changeError = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Введите правильный номер!");
                                }

                            }
                            while (changeError == true);

                            posev newPosev;
                            newPosev.naz = nazv;
                            newPosev.type = (Type)Enum.Parse(typeof(Type), choiceType);
                            newPosev.plosh = pl;
                            newPosev.urozh = ur;

                            Table[choiceNumberChange] = newPosev;
                        }
                        break;

                    case 5: // Поиск записей
                        {
                            Console.WriteLine("Введите перечисляемый тип: (Б - бобовые, З - зерновые)");

                            bool seatchError = false;
                            do
                            {
                                Char choiceNumberSearch = Convert.ToChar(Console.ReadLine());
                                if (choiceNumberSearch == 'З')
                                {
                                    var records = Table.FindAll(i => i.type == Type.З);
                                    foreach (var record in records)
                                    {
                                        record.DisplayInfo();
                                    }
                                    seatchError = false;
                                }
                                else if (choiceNumberSearch == 'Б' || choiceNumberSearch == 'Б')
                                {
                                    var records = Table.FindAll(i => i.type == Type.Б);
                                    foreach (var record in records)
                                    {
                                        record.DisplayInfo();
                                    }
                                    seatchError = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите правильный перечисляемый тип: (Б - бобовые, З - зерновые)");
                                    seatchError = true;
                                }
                            }
                            while (seatchError == true);
                        }
                        break;

                    case 6: // Просмотреть лог
                        {
                            for (int i = 0; i < Log.Count; i++)
                            {
                                Log[i].DisplayLog();
                            }
                            Console.WriteLine();
                            Console.WriteLine(timeInterval_1 + " - Самый долгий период бездействия пользователя");
                        }
                        break;

                    case 7: // Выход
                        {
                            optionError = false;
                        }
                        break;

                    default:
                        Console.WriteLine("Введите правильную команду!");
                        optionError = true;
                        break;
                }
            }
            while (optionError);
        }
    }
}