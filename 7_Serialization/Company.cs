using System;
using System.Collections.Generic;
using System.Linq;

namespace IteaSerialization
{
    [Serializable]
    public class Company : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

        protected Company() { }

        public Company(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public override bool Equals(object company)
        {
            var other = company as Company;
            return other != null &&
                   Id == other.Id &&
                   Name.Equals(other.Name) &&
                   Departments.Count() == other.Departments.Count() &&
                   Departments.Except(other.Departments) == null;
            //!Departments.Except(other.Departments).Any();
        }

        public override int GetHashCode()
        {
            //return HashCode.Combine(Id, Name, Departments);
            int hash = 19;
            hash = hash * 23 + ((Id == null) ? 0 : Id.GetHashCode());
            hash = hash * 23 + ((Name == null) ? 0 : Name.GetHashCode());
            hash = hash * 23 + ((Departments == null) ? 0 : Departments.GetHashCode());
            return hash;
        }
    }
}
