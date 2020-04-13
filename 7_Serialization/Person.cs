using System;
using System.Linq;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace IteaSerialization
{
    public enum Gender
    {
        Man,
        Woman,
        etc
    }

    [Serializable]
    public class Person : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public Company Company { get; set; }
        public Department Dept { get; set; }

        protected Person() { }

        public Person(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }

        public Person(string name, Gender gender, int age, string email)
            : this(name, age)
        {
            Gender = gender;
            Email = email;
        }

        /// <summary>
        /// Set company for person
        /// </summary>
        /// <param name="company">Company to set</param>
        public void SetCompany(Company company)
        {
            Company = company;            
        }
        public void SetDepartment(Department dept)
        {
            Company?.Departments?.FirstOrDefault(x => x == dept).People.Add(this);
            Dept = dept;
        }

        public override string ToString()
        {
            return $"{Id.ToString().Substring(0, 5)}_{Name}: {Gender}, {Age}, {Email}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   Id == person.Id &&
                   Name.Equals(person.Name) &&
                   Email.Equals(person.Email);
        }
    }
}
