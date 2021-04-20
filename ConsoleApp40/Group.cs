namespace ConsoleApp40
{
    public class Group
    {
        public string Name { get; private set; }

        public Group(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException($"Имя не может быть пустым или содержать только пробел.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " (SGK)";
        }
    }
}