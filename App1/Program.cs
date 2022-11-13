using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.IO;

namespace App1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n  = 5;
            Product [] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int code = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите название товара");
                string name = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Введите цену товара");
                double price = Convert.ToDouble(Console.ReadLine());

                products[i] = new Product()
                {
                    Code = code,
                    Name = name,
                    Price = price,
                };

                JsonSerializerOptions optionats = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.Cyrillic, UnicodeRanges.BasicLatin),
                    WriteIndented = true
                };
                string jsonStr = JsonSerializer.Serialize(products, optionats);


                using(StreamWriter sw = new StreamWriter("../../../Products.json"))
                {
                    sw.WriteLine(jsonStr);
                }
            }


        }
    }
}
