using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp40
{
    public  class User
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public  Group Group { get; private set; }

        /// <summary>
        /// возвращает текущий возраст 
        /// </summary>
        public  int Age 
        { 
            get { return GetAge(); }
        }

        public User(string name, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Имя не может быть неопределенным или пустым", nameof(name));
            }

            if(dateOfBirth.Year<=1990 || dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException($"Некорректная дата", nameof(dateOfBirth));
            }

            Name = name;
            DateOfBirth = dateOfBirth;
            Group = new Group("No");
        }

        public User(string name, DateTime dateOfBirth, Group group  ): this (name , dateOfBirth)
        {
            Group = group ?? throw new ArgumentNullException(nameof(group));
        }

        public override string ToString()
        {
            return $"группа: {Group} , Студент: {Name} , Возраст: {GetAge()} ";
        }

        /// <summary>
        /// возвращает  возраст по дате рождения
        /// </summary>
        /// <returns></returns>
        private int  GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

}
