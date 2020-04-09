using IteaDelegates.IteaMessanger;
using System;
using System.Collections.Generic;
using System.Linq;

using static ITEA_Collections.Common.Extensions;

namespace IteaLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Person> people = GetPeople().ToList();

            //foreach (Person x in people)
            //{
            //    ToConsole(x.ToString(), ConsoleColor.Cyan);
            //}

            //people
            //    .ForEach(x => ToConsole(x.ToString(), ConsoleColor.Cyan));

            //people
            //    .CustomWhere(x => x.Age < 28)
            //    .ToList()
            //    .ForEach(x => ToConsole(x.ToString(), ConsoleColor.Cyan));

            //foreach (Person x in from i in people where i.Age < 28 select i)
            //    ToConsole(x.ToString(), ConsoleColor.Cyan);

            //IOrderedEnumerable<Person> ordered1 = people
            //    .Where(x => x.Age > 35)
            //    .OrderByDescending(x => x.Age);

            //var ordered2 = from i in people
            //               where i.Age > 35
            //               orderby i.Age descending
            //               select new { i.Name };


            //int min = people.Min(x => x.Age);
            //int max = people.Max(x => x.Age);
            //double avr = people.Average(x => x.Age);

            //var tenten = people.Skip(10).Take(10);

            var anon = new
            {
                Name = "Anon",
                Age = 21
            };

            var anon1 = new
            {
                Name = "Anon",
                Age = "dwqd"
            };

            ToConsole(anon.Age.GetType().Name);
            ToConsole(anon1.Age.GetType().Name);

            //List<Person> people = new List<Person>
            //{
            //    new Person("Pol", Gender.Man, 37, "pol@gmail.com"),
            //    new Person("Ann", Gender.Woman, 25, "ann@yahoo.com"),
            //    new Person("Alex", Gender.Man, 21, "alex@gmail.com"),
            //    new Person("Harry", Gender.Man, 58, "harry@yahoo.com"),
            //    new Person("Germiona", Gender.Woman, 18, "germiona@gmail.com"),
            //    new Person("Ron", Gender.Man, 24, "ron@yahoo.com"),
            //    new Person("Etc1", Gender.etc, 42, "etc1@yahoo.com"),
            //    new Person("Etc2", Gender.etc, 42, "etc2@gmail.com"),
            //};

            //people
            //    .CustomWhere(x => x.Email.Contains("gmail"))
            //    .ShowAll()
            //    .OrderByDescending(x => x.Age)
            //    .ShowAll();

            #region HW5_LINQ
            Account user1 = new Account("User 1");
            Account user2 = new Account("User 2");
            Account user3 = new Account("User 3");
            Account user4 = new Account("User 4");
            List<Account> users = new List<Account> { user1, user2, user3, user4};

            /*Group group = new Group("Group");

            user1.Subscribe(group);
            user2.Subscribe(group);
            user3.Subscribe(group);
            user4.Subscribe(group);
            

            Message msg1 = user1.CreateMessage("hello", group);
            user1.Send(msg1);
            Message msg2 = user3.CreateMessage("hi all", group);
            user3.Send(msg2);
            Message msg3 = user3.CreateMessage("Message 3", group);
            user3.Send(msg3);
            Message msg4 = user3.CreateMessage("Message 4", group);
            user3.Send(msg4);
            Message msg5 = user2.CreateMessage("Message 5", group);
            user2.Send(msg5);
            Message msg6 = user1.CreateMessage("Message 6", group);
            user1.Send(msg6);
            Message msg7 = user3.CreateMessage("Message 7", group);
            user3.Send(msg7);
            Message msg8 = user2.CreateMessage("Message 8", group);
            user2.Send(msg8);
            Message msg9 = user1.CreateMessage("Message 9", group);
            user1.Send(msg9);
            Message msg10 = user3.CreateMessage("Message 10", group);
            user3.Send(msg10);
            Message msg11 = user3.CreateMessage("Message 11", user1);
            user3.Send(msg11);
            Message msg12 = user3.CreateMessage("Message 12", user2);
            user3.Send(msg12);
            Message msg13 = user3.CreateMessage("Message 13", group);
            user3.Send(msg13);
            */

            Console.WriteLine("-------------------------------");

            
            Console.Read();
            #endregion


        }

        #region Create people list
        public static IEnumerable<Person> GetPeople()
        {
            for (int i = 0; i < 20; i++)
            {
                yield return new Person("Person" + i, 18 + i * 2);
            }
        }
        #endregion

        static void BaseDelegates(int f, int s)
        {
            Action<int, int> action = (a, b) => Console.WriteLine($"{a}{b}");
            Predicate<int> predicate = (a) => a > 0;
            Func<int, int, string> func = delegate (int a, int b)
            {
                return (a * b).ToString();
            };
            action(f, s);
            predicate(f);
            func(f, s);
        }

    }
}
