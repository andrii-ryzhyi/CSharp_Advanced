using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _6_LINQ_to_SQL.Controllers
{
    [Route("api/mailbox")]
    [ApiController]
    public class MailBoxController : ControllerBase
    {

        [HttpGet]
        public List<MailBox> Get()
        {
            return new List<MailBox>() { new MailBox(1, "test@mailbox.com"), new MailBox(2, "test2@mailbox.com")};
        }
    }
}