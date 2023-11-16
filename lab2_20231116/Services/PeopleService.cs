using Lab2.Klasy;

namespace Lab2.Function
{
    public class PeopleServices
    {
        private List<Person> people { get; } = new List<Person>();
        
        public Person Add(PersonDTO personDTO)
        {
            var person = new Person
            {
                Id = 1,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName
            };
            people.Add(person);
            return person;
        }    

        public Person Update (PersonDTO personDTO)
        {
            var person = people.First(x => x.Id == personDTO.Id);
            person.FirstName = personDTO.FirstName;
            person.LastName = personDTO.LastName;

            return person;
        }

        public void Delete(int id)
        {
            var person = people.First(x => x.Id == id);
            people.Remove(person);
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