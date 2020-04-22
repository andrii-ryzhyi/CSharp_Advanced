using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IteaLinqToSql.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        readonly IService<SaveGame> service;

        public GameController(IService<SaveGame> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<SaveGame> Get()
        {
            /*return service
                .GetQuery()
                .Include(x => x.SaveGame)
                .Where(x => x.Games.Count > 0)
                .ToList();\
                */
            return null;
        }

        [HttpGet("{id}")]
        public SaveGame Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<SaveGame> Post([FromBody] SaveGame value)
        {
            return service
                .GetAll()
                .Where(x => x.Email.Contains(value.Email) ||
                            x.Username.Contains(value.Username) ||
                            x.Id == value.Id)
                .ToList();
                
        }
    }
}