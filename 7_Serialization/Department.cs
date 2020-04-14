using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteaSerialization
{
    [Serializable]
    public class Department : IModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
        public Department() { }
        public Department(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
        public void AddEmployee(Person employee)
        {
            People.Add(employee);
        }
        public override bool Equals(object obj)
        {
            var other = obj as Department;
            return other != null &&
                   Id == other.Id &&
                   Name.Equals(other.Name) &&
                   People.Count() == other.People.Count() &&
                   !People.Except(other.People).Any();
        }
    }
}
