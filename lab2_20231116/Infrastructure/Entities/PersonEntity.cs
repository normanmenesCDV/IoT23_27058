using System.Reflection.PortableExecutable;
using Lab2.Klasy;

namespace Lab2.Infrastructure.Entities
{
    public class PersonEntity
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public bool Add(PersonClass person)
        {
            FirstName = person.FirstName,
            LastName = person.LastName
        }
    }
}
