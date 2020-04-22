using IteaLinqToSql.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IteaLinqToSql.Models.Entities
{
    public class SaveGame : IIteaModel
    {
        [Key] public int Id { get; set; }
        public string GameString { get; set; }
        public SaveGame(string gameString)
        {
            GameString = gameString;
        }
    }
}
