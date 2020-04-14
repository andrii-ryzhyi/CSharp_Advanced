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

        public override bool Equals(object obj)
        {
            var company = obj as Company;
            return company != null &&
                   Id == company.Id &&
                   Name.Equals(company.Name);
        }
    }
}
