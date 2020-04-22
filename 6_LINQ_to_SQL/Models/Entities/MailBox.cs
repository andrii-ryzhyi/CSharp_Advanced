using IteaLinqToSql.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteaLinqToSql.Models.Entities
{
    public class MailBox : IIteaModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }
    }
}
