using Lab2.Klasy;

namespace Lab2.Function
{
    public class PeopleServices
    {
        private List<Person> people { get; } = new List<Person>();

        private static int autoincrementId = 1;

        public Person Add(PersonDTO personDTO)
        {
            var person = new Person
            {
                Id = autoincrementId,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName
            };
            people.Add(person);
            autoincrementId++;
            return person;
        }

        public Person Update(PersonDTO personDTO)
        {
            var person = people.First(x => x.Id == personDTO.Id);
            person.FirstName = personDTO.FirstName;
            person.LastName = personDTO.LastName;

            return person;
        }

        public bool Delete(int id)
        {
            var person = people.First(x => x.Id == id);
            people.Remove(person);
            return true;
        }

        public Person Find(int id)
        {
            return people.First(x => x.Id == id);
        }

        public IEnumerable<Person> Get()
        {
            return people;
        }
    }
}