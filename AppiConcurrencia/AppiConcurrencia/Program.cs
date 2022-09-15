using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AppiConcurrencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(api);
            Thread t2 = new Thread(api2);
            t1.Start();
            t2.Start();
            Console.ReadLine();

        }

        public static long dato = 1;
        public static long dato2 = 1;
        public static void api()
        {
            for (int i = 0; i < 100; i++)
            {
                var url = $"https://pokeapi.co/api/v2/pokemon/{dato++}/";
                WebClient wc = new WebClient();
                var datos = wc.DownloadString(url);
                var json = JsonConvert.DeserializeObject<Root>(datos);
                foreach (var p in json.forms)
                {
                    Console.WriteLine("Nombre de la forma del pokemon: " + p.name);
                }
            }
            Console.ReadKey();


        }

        public static void api2()
        {
            for (int i = 0; i < 100; i++)
            {
                var url = $"https://pokeapi.co/api/v2/pokemon/{dato++}/";
                WebClient wc = new WebClient();
                var datos = wc.DownloadString(url);
                var json = JsonConvert.DeserializeObject<Root>(datos);
                foreach (var p in json.forms)
                {
                    Console.WriteLine("URL del pokemon: " + p.url);
                }
            }
            Console.ReadKey();

        }


    }
}
