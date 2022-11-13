using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using App1;

namespace App2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string jsonStr = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonStr = sr.ReadToEnd();
            }
            Product [] products = JsonSerializer.Deserialize < Product[]>(jsonStr);

            Product prEx = products[0];
            foreach (var p in products)
            {
                prEx = (prEx.Price < p.Price) ? p : prEx;
            }
            Console.WriteLine($"Самый дорогой продукт {prEx.Name} с кодом {prEx.Code} и ценой {prEx.Price:N2}");
            Console.ReadKey();
        }
    }
}
