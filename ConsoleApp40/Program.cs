using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupController groups = new GroupController(); // список групп
            UserController users = new UserController(); // список  юзеров

            Console.bu

            InformMessage2("Вас приветствует программа \"отдел  кадров\""); // приветствие
            while (true)
            {
                StartMenu(groups, users);
            }
        }


        /// <summary>
        /// Выводит  на консоль  возможные операции
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="users"></param>
        private static void StartMenu(GroupController groups, UserController users)
        {
            InformMessage("Если хотите вывести список всех групп введите -");
            Console.WriteLine("\t \"all groups\"");
            InformMessage("Если хотите добавить группу введите- ");
            Console.WriteLine("\t  \"add group\"");
            InformMessage("Если хотите вывести список всех студентов введите -");
            Console.WriteLine("\t \"all users\"");
            InformMessage("Если хотите добавить группу введите -");
            Console.WriteLine("\t \"add user\"");
            InformMessage("Если хотите очистить окно введите -");
            Console.WriteLine("\t \"clear\"");
            switch (Console.ReadLine().ToLower())
            {
                case "all groups": PrintGroup(groups); break;
                case "add group": AddGroup(groups); break;
                case "all users": PrintUser(users); break;
                case "add user": MessageAddUser(users, groups); break;
                case "clear": Console.Clear(); break;
                default: ErrorMessage(new Exception("команда не опознана")); break;
            }
        }

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="users"></param>
        /// <param name="groups"></param>
        private static void MessageAddUser(UserController users, GroupController groups)
        {
            InformMessage("Введите имя пользователя:");
            string name = Console.ReadLine();

            InformMessage("Введите дату рождения в формате \"Год.месяц.день:");
            Console.WriteLine("или оставьте пустым");
            string date = Console.ReadLine();

            InformMessage("введите  группу");
            Console.WriteLine("или оставьте пустым");

            string group = Console.ReadLine();

            try
            {
                AddUser(users, groups, name, date, group);
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }


        /// <summary>
        /// Добавление нового  пользователя в  контроллер
        /// </summary>
        /// <param name="users"></param>
        /// <param name="groups"></param>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="group"></param>
        private static void AddUser(UserController users, GroupController groups, string name, string date, string group)
        {
            if (string.IsNullOrWhiteSpace(date) && string.IsNullOrWhiteSpace(group)) // если нет даты и  группы
            {
                users.Add(name);
                PrintUser(users);
                return;
            }

            if (string.IsNullOrWhiteSpace(date) == false && string.IsNullOrWhiteSpace(group))
            {
                users.Add(name, date);
                PrintUser(users);
                return;
            }

            if (string.IsNullOrWhiteSpace(date) && string.IsNullOrWhiteSpace(group) == false)
            {
                Group gr = groups.GetGroup(group);
                users.Add(name, gr);
                PrintUser(users);
                return;
            }


            if (string.IsNullOrWhiteSpace(date) == false && string.IsNullOrWhiteSpace(group) == false)
            {
                Group gr = groups.GetGroup(group);
                users.Add(name, gr, date);
                PrintUser(users);
                return;
            }
        }

        /// <summary>
        /// выводит  список пользователей на консоль
        /// </summary>
        /// <param name="users"></param>
        private static void PrintUser(UserController users)
        {
            Print(users.Users(), "Список студентов:");
        }

        /// <summary>
        /// Добавляет новую группу
        /// </summary>
        /// <param name="controller"></param>
        private static void AddGroup(GroupController controller)
        {
            InformMessage("Введите имя новой группы:");
            string s = Console.ReadLine();
            try
            {
                controller.Add(s);
                PrintGroup(controller);
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                return;
            }
        }

        private static void PrintGroup(GroupController controller)
        {
            Print(controller.Groups(), "Список групп:");
        }

        /// <summary>
        /// Выводит на  консоль список
        /// </summary>
        /// <param name="colecction"></param>
        /// <param name="message"></param>
        private static void Print(IEnumerable collection, string message)
        {
            InformMessage(message);
            int x = 1; // номер  пп 
            foreach (var item in collection)
            {
                Console.WriteLine($"{x}. " + item);
                x++;
            }

            InformMessage($"всего: {x-1}\n");
        }

        /// <summary>
        /// Выводит  на  консоль red
        /// </summary>
        /// <param name="ex"></param>
        private static void ErrorMessage(Exception ex)
        {
            var s = Console.ForegroundColor; // запомнить  старый  цвет
            Console.ForegroundColor = ConsoleColor.Red; // задать новый 
            Console.WriteLine(ex.Message); // вывести сообщение 
            Console.ForegroundColor = s; // вернуть старый цвет
        }

        /// <summary>
        /// Выводит  на  консоль  Cyan
        /// </summary>
        /// <param name="message"></param>
        private static void InformMessage(string message)
        {
            var s = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ForegroundColor = s;
        }

        /// <summary>
        /// Выводит  на  консоль  DarkCyan
        /// </summary>
        /// <param name="message"></param>
        private static void InformMessage2(string message)
        {
            var s = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t" +message +"\n");
            Console.ForegroundColor = s;
        }
    }
}
