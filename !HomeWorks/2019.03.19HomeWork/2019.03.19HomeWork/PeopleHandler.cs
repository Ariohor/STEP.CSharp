using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace _2019._03._19HomeWork
{
    public class PeopleHandler
    {
        public People PeopleLoader(int idPeople)
        {
            People people = null;
            if (LoadOfXML(idPeople, out people)) { }
            else
            {
                people = LoadOfURL(idPeople);
                SaveOnXML(people);
            }


            return people;
        }

        public void ShowPeople(People people)
        {
            Console.WriteLine($"Информация о персонаже - {people.Name}");
            Console.WriteLine($"Рост - {people.Height}");
            Console.WriteLine($"Вес - {people.Mass}");
            Console.WriteLine($"Цвет волос - {people.HairColor}");
            Console.WriteLine($"Цвет кожи - {people.SkinColor}");
            Console.WriteLine($"Цвет глаз - {people.EyeColor}");
            Console.WriteLine($"Дата рождения - {people.BirthYear}");
            Console.WriteLine($"Пол - {people.Gender}");
            Console.WriteLine($"Родной мир - {people.Homeworld}");

            Console.WriteLine($"Фильмы с его участием:");
            foreach (var film in people.Films)
            {
                Console.WriteLine($"  {film}");
            }

            Console.WriteLine($"Species:");
            foreach (var species in people.Species)
            {
                Console.WriteLine($"  {species}");
            }

            Console.WriteLine($"Транспортные средства:");
            foreach (var vehicles in people.Vehicles)
            {
                Console.WriteLine($"  {vehicles}");
            }

            Console.WriteLine($"Звёздные корабли:");
            foreach (var starships in people.Starships)
            {
                Console.WriteLine($"  {starships}");
            }

            Console.WriteLine($"Создан - {people.Created}");
            Console.WriteLine($"Изменён - {people.Edited}");
            Console.WriteLine($"Ссылка - {people.Url}");
        }

        bool LoadOfXML(int idPeople, out People people)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<People>));
            people = null;

            if (File.Exists("peoples.xml"))
            {
                List<People> peoples = new List<People>();

                using (var fileStream = new FileStream("peoples.xml", FileMode.Open))
                {
                    peoples = ((List<People>)xmlSerializer.Deserialize(fileStream));
                }

                people = peoples.Where(p => p.Id == idPeople).FirstOrDefault();

                if (people != null)
                {
                    return true;
                }
            }


            return false;
        }

        People LoadOfURL(int idPeople)
        {
            var httpMethod = Enums.HttpMethod.GET;
            string url = $"https://swapi.co/api/people/{idPeople}/";

            string result = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = httpMethod.ToString();

            JsonSerializer jsonSerializer = new JsonSerializer();
            var people = new People();

            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var reader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    // result = reader.ReadToEnd();
                    people = (People)jsonSerializer.Deserialize(reader, typeof(People));
                }
                people.Id = idPeople;
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }

            return people;
        }

        void SaveOnXML(People people)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<People>));
            List<People> peoples = new List<People>();

            if (File.Exists("peoples.xml"))
            {
                using (var fileStream = new FileStream("peoples.xml", FileMode.Open))
                {
                    peoples = ((List<People>)xmlSerializer.Deserialize(fileStream));
                }
            }

            peoples.Add(people);

            using (var fileStream = new FileStream("peoples.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, peoples);
            }
        }
    }
}
