using IteaLinqToSql.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IteaAsync
{
    public class Helper
    {
        static HttpClient client = new HttpClient();
        public static async Task<List<MailBox>> Request()
        {
            try
            {
                List<MailBox> mailboxes = null;
                HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/mailbox");
                Console.WriteLine(response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    string mailboxStr = await response.Content.ReadAsStringAsync();
                    mailboxes = JsonConvert.DeserializeObject<List<MailBox>>(mailboxStr);
                }
                return mailboxes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.Message}\n");
                return null;
            }
        }
    }
}
