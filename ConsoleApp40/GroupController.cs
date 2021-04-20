using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp40
{
    public class GroupController
    {
        private List<Group> groups  = new List<Group>(); // список  пользователей 

        private string[] gr = new string[] { "is-19-01", "is-19-02", "is-19-03", "is-19-04" }; // статичный список
        //для стартовых данных , должен  по  хорошему  браться из источника

        /// <summary>
        /// создает  стартовые  группы
        /// </summary>
        public GroupController()
        {
            foreach (var item in gr) 
            {
                groups.Add(new Group(item));
            }
        }

        /// <summary>
        /// Возвращает  список  групп
        /// </summary>
        /// <returns></returns>
        public List<Group> Groups () 
        {
            return groups;
        }

        /// <summary>
        /// Добавляет новую группу
        /// </summary>
        /// <param name="name"></param>
        public  void Add (string  name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"Имя не может быть пустым или содержать только пробел.", nameof(name));
            }

            if (IsDoubleGroup(name))
            {
                throw new ArgumentException($"Такая группа уже есть в списке", nameof(name));
            }
            groups.Add(new Group(name));
        }

        /// <summary>
        /// Проверяет есть ли такая группа  в  списке
        /// </summary>
        /// <param name="name"></param>
        /// <returns>да, если есть</returns>
        private bool IsDoubleGroup(string name)
        {
            foreach (var item in groups)
            {
                if (item.Name.ToUpper().TrimEnd().TrimStart() == name.ToUpper().TrimStart().TrimEnd())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Возвращает  группу по названию  группы
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Group GetGroup(string name)
        {
            foreach (var item in groups)
            {
                if (item.Name.ToUpper().TrimEnd().TrimStart() == name.ToUpper().TrimStart().TrimEnd())
                {
                    return item;
                }
            }
            throw new Exception("Такой группы нет");
        }
    }
}
