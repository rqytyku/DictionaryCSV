using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\romel\OneDrive\Documents\Book1.csv ";
            CsvReader reader = new CsvReader(filePath);

            Dictionary<string, List<Country>> countries = reader.ReadAllCountries();

            foreach (string region in countries.Keys)
                Console.WriteLine(region);

            Console.Write("Vendos rajonin qe deshironi te kerkoni: ");
            string chosenRegion = Console.ReadLine();

            if (countries.ContainsKey(chosenRegion))
            {
                
                foreach (Country country in countries[chosenRegion].Take(10))
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            else
                Console.WriteLine("Ky region nuk eshte valid");
                Console.ReadKey();
        }
        
    }
    }

