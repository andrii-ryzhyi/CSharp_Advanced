using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using static ITEA_Collections.Common.Extensions;

namespace IteaSerialization
{
    [System.Runtime.InteropServices.Guid("01FDEB4A-7B33-45DD-B2A4-18B5F1DEA96E")]
    class Program
    {
        static void Main(string[] args)
        {
        //    ReadFromFile("example.txt");
        //    WriteToFile("example1.txt", "Some data");
        //    AppendToFile("example1.txt", "1");
        //    ToConsole(ReadFromFile("example.txt", ""));
            Person person = new Person("Alex", Gender.Man, 21, "alexs98@gmail.com");
            List<Person> people = new List<Person>
            {
                new Person("Pol", Gender.Man, 37, "pol@gmail.com"),
                new Person("Ann", Gender.Woman, 25, "ann@yahoo.com"),
                new Person("Alex", Gender.Man, 21, "alex@gmail.com"),
                new Person("Harry", Gender.Man, 58, "harry@yahoo.com"),
                new Person("Germiona", Gender.Woman, 18, "germiona@gmail.com"),
                new Person("Ron", Gender.Man, 24, "ron@yahoo.com"),
                new Person("Etc1", Gender.etc, 42, "etc1@yahoo.com"),
                new Person("Etc2", Gender.etc, 42, "etc2@gmail.com"),
            };

            Company microsoft = new Company("Microsoft");
            Company apple = new Company("Apple");

            people.ForEach(x => {
                if (x.Age < people.Average(a => a.Age))
                    x.SetCompany(microsoft);
                else
                    x.SetCompany(apple);
            }) ;

            XmlSerialize("exampleXml", people);
            JsonSerialize("microsoftJson", microsoft);
            JsonSerialize("appleJson", apple);
            Company appleFromFile = JsonDeserialize("appleJson");
            Console.WriteLine("AppleFromFile equals after deserialization: {0}", apple.Equals(appleFromFile));

            /*--------------------------------*/
            Console.WriteLine("***********HW7*****************");

            Department it = new Department("IT");
            Department infrastructure = new Department("Infra");
            Department sales = new Department("Sales");
            Department marketing = new Department("Marketing");

            microsoft.Departments.Add(it);
            microsoft.Departments.Add(infrastructure);
            microsoft.Departments.Add(sales);
            microsoft.Departments.Add(marketing);

            Person employee1 = new Person("Alex", 27);
            Person employee2 = new Person("Max", 36);
            Person employee3 = new Person("Nick", 29);
            Person employee4 = new Person("E4", 30);
            Person employee5 = new Person("E5", 41);
            Person employee6 = new Person("E6", 28);
            Person employee7 = new Person("E7", 25);
            Person employee8 = new Person("E8", 37);
            Person employee9 = new Person("E9", 42);
            Person employee10 = new Person("E10", 34);

            employee1.SetCompany(microsoft);
            employee2.SetCompany(microsoft);
            employee3.SetCompany(microsoft);
            employee4.SetCompany(microsoft);
            employee5.SetCompany(microsoft);
            employee6.SetCompany(microsoft);
            employee7.SetCompany(microsoft);
            employee8.SetCompany(microsoft);
            employee9.SetCompany(microsoft);
            employee10.SetCompany(microsoft);

            employee1.SetDepartment(it);
            employee2.SetDepartment(it);
            employee3.SetDepartment(it);
            employee4.SetDepartment(it);
            employee5.SetDepartment(infrastructure);
            employee6.SetDepartment(sales);
            employee7.SetDepartment(sales);
            employee8.SetDepartment(marketing);
            employee9.SetDepartment(infrastructure);
            employee10.SetDepartment(it);


            JsonSerialize("microsoftJson_hw7", microsoft);
            var fromJson = JsonDeserialize("microsoftJson_hw7");
            JsonSerialize("microsoftJson_hw7_2attempt", fromJson);
            Console.WriteLine("Company equals after deserialization: {0}", microsoft.Equals(fromJson));
            Console.WriteLine(microsoft.Departments.Except(fromJson.Departments).Any());

            Console.Read();
        }

        #region Serialization
        public static void XmlSerialize<T>(string path, T obj) where T : class
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (var fs = new FileStream($"{path}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }

            using (var stringwriter = new StringWriter())
            {
                formatter.Serialize(stringwriter, obj);
                ToConsole(stringwriter.ToString());
            }
        }

        public static void JsonSerialize<T>(string path, T obj) where T : class
        {
            using (var fs = new FileStream($"{path}.json", FileMode.OpenOrCreate))
            {
                string strObj = JsonConvert.SerializeObject(obj);
                byte[] data = strObj
                    .Select(x => (byte)x)
                    .ToArray();
                fs.Write(data, 0, data.Length);
                strObj
                    .Split(",")
                    .ToList()
                    .ForEach(x => ToConsole($"{x},", ConsoleColor.Green));
            }
        }

        public static Company JsonDeserialize(string path)
        {
            using (var streamReader = new StreamReader($"{path}.json"))
            {
                //var startMemory = GC.GetTotalMemory(true);
                string dataStr = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Company>(dataStr);
                //var endMemory = GC.GetTotalMemory(true);
                //Console.WriteLine($"Total memory: {endMemory - startMemory}");
            }
        }
        #endregion
        #region System.IO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Path to file</param>
        public static void ReadFromFile(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                var startMemory = GC.GetTotalMemory(true);
                streamReader
                    .ReadToEnd()
                    .Split(';')
                    .ShowAll(separator: ";")
                    .Select(x => long.TryParse(x, out long l) ? l : (long?)null)
                    .Where(x => x != null)
                    .ShowAll(separator: ";");
                var endMemory = GC.GetTotalMemory(true);
                Console.WriteLine($"Total memory: {endMemory - startMemory}");
            }
        }

        public static void WriteToFile(string path, string data)
        {
            using (var fileWriter = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = data.Select(x => (byte)x).ToArray();
                fileWriter.Write(array, 0, array.Length);
            }

            //{
            //    FileStream fileWriter = new FileStream(path, FileMode.OpenOrCreate);
            //    try
            //    {
            //        byte[] array = data.Select(x => (byte)x).ToArray();
            //        fileWriter.Write(array, 0, array.Length);
            //    }
            //    finally
            //    {
            //        fileWriter?.Dispose();
            //    }
            //}

            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(data);
            }
        }

        public static void AppendToFile(string path, string data)
        {
            using (var fileWriter = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = data.Select(x => (byte)x).ToArray();
                long fileDataLength = fileWriter.Length;
                fileWriter.Seek(fileDataLength, SeekOrigin.Begin);
                //fileWriter.Seek(0, SeekOrigin.End);
                fileWriter.Write(array, 0, array.Length);
            }
            using (var fileWriter = new FileStream(path, FileMode.Append))
            {
                byte[] array = data.Select(x => (byte)x).ToArray();
                fileWriter.Write(array, 0, array.Length);
            }
        }

        public static string ReadFromFile(string path, string notExistingEx)
        {
            notExistingEx = string.IsNullOrEmpty(notExistingEx)
                ? "Create file!"
                : notExistingEx;
            try
            {
                using (var fileReader = new FileStream(path, FileMode.Open))
                {
                    byte[] data = new byte[fileReader.Length];
                    fileReader.Read(data, 0, (int)fileReader.Length);
                    //return string.Concat(data.Select(x => (char)x));
                    return Encoding.Default.GetString(data);
                }
            }
            catch (FileNotFoundException)
            {
                ToConsole(notExistingEx, ConsoleColor.Red);
                return "Error";
            }
        }
        #endregion
    }
}
