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
    [Route("api/loginhistory")]
    [ApiController]
    public class LoginHistoryController : ControllerBase
    {
        readonly IService<LoginHistory> service;

        public LoginHistoryController(IService<LoginHistory> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<LoginHistory> Get()
        {
            return service
                .GetQuery()
                .Include(x => x.User)
                .ToList();
        }

        [HttpGet("{id}")]
        public LoginHistory Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<LoginHistory> Post([FromBody] LoginHistory value)
        {
            return service
                .GetAll()
                .Where(x => x.UserId == value.UserId ||
                            x.UserDevice.Contains(value.UserDevice) ||
                            x.Id == value.Id)
                .ToList();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LoginHistory value)
        {
            service.Update(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            LoginHistory record = service.FindById(id);
            service.Delete(record);
        }
    }
}