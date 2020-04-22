using IteaLinqToSql.Models.Abstract;
using IteaLinqToSql.Models.Database;
using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteaLinqToSql.Services
{
    public class SaveGameService : IService<SaveGame>
    {
        public BaseRepository<SaveGame> Repository { get; set; }
        public SaveGameService(IteaDbContext dbContext)
        {
            Repository = new BaseRepository<SaveGame>(dbContext);
        }

        public void Create(SaveGame item)
        {
            Repository.Create(item);
        }

        public void Delete(SaveGame item)
        {
            Repository.Remove(item);
        }

        public SaveGame FindById(int id)
        {
            return Repository.FindById(id);
        }

        public List<SaveGame> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public IQueryable<SaveGame> GetQuery()
        {
            return Repository.GetAll();
        }

        public SaveGame Update(int id, SaveGame updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
    }
}
