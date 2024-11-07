using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person tom = new Person("Tom", 37);
                JsonSerializer.Serialize(fs, tom);
                Console.WriteLine("Data has been saved to file");
            }

            // чтение данных
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person person = JsonSerializer.Deserialize<Person>(fs);
                Console.WriteLine($"Name: {person?.Name}  Age: {person?.Age}");
            }
        }


class Person
        {
            public string Name { get; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
    }
}
