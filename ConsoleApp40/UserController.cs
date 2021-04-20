using System;
using System.Collections.Generic;

namespace ConsoleApp40
{
    public class UserController
    {
        private List<User> users { get; set; } = new List<User>(); // список случайных стартовых юзеров

        private string[] us = new string[] { "Букаев Артемий Владимирович", "Крючков Даниил Дмитриевич", "Милов Илья Сергеевич",
            "Тимофеев Илья Андреевич" };

        /// <summary>
        /// генерация стартовых пользователей 
        /// </summary>
        public UserController()
        {
            GroupController groupController = new GroupController();  // список групп
            foreach (var item in us)
            {
                DateTime date =   RandomDateTime(); // случайная дата
                Group group = RandomGroup(groupController); // случайная группа
                User user = new User(item, date, group);
                users.Add(user);
            }
        }

        /// <summary>
        /// Возвращает  список юзеров
        /// </summary>
        /// <returns></returns>
        public  List<User> Users ()
        {
            return users;
        }

        /// <summary>
        /// добавляет нового пользователя // "12.12.2000" по умолчанию 
        /// </summary>
        /// <param name="name"></param>
        public void Add(string name)
        {
            Add(name, DateTime.Parse("12.12.2000"));
        }

        /// <summary>
        /// добавляет нового пользователя // "12.12.2000" по умолчанию 
        /// </summary>
        /// <param name="name"></param>
        public void Add(string name , Group group)
        {
            Add(name, group, DateTime.Parse("12.12.2000"));
        }

        /// <summary>
        /// добавляет нового пользователя 
        /// </summary>
        /// <param name="name"></param>
        public void Add(string name, Group group, string date)
        {
            DateTime dateTime = DateTime.Parse(date);
            Add(name, group, dateTime);
        }

        /// <summary>
        /// добавляет нового пользователя 
        /// </summary>
        /// <param name="name"></param>
        public void Add(string name,  string date)
        {
            DateTime dateTime = DateTime.Parse(date);
            Add(name, dateTime);
        }

        /// <summary>
        /// добавляет нового пользователя 
        /// </summary>
        /// <param name="name"></param>
        private void Add(string name, Group group, DateTime date)
        {
            users.Add(new User(name, date, group));
        }

        /// <summary>
        /// добавляет нового пользователя 
        /// </summary>
        /// <param name="name"></param>
        private void Add(string name, DateTime date)
        {
            users.Add(new User( name, date));
        }

        /// <summary>
        /// случайная дата от  1.1.1999 до 30.12.2005
        /// </summary>
        /// <returns></returns>
        private static DateTime RandomDateTime()
        {
            Random random = new Random();
            int day = random.Next(1, 30);
            int month = random.Next(1, 12);
            int year = random.Next(1999, 2005);
            return DateTime.Parse($"{year},{month},{day}");
        }

        /// <summary>
        ///  возвращает случайную группу
        /// </summary>
        /// <param name="groupController"></param>
        /// <returns></returns>
        private Group RandomGroup(GroupController groupController)
        {
            Random random = new Random();
            return groupController.Groups()[random.Next(0, groupController.Groups().Count)];
        }
    }
}
