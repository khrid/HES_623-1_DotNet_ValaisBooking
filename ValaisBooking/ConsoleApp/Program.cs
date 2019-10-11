using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    public class Program
    {
        // pour gérer la configuration du fichier appsettings.json
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        static void Main(string[] args)
        {
            var HotelsDb = new HotelsDB(configuration: Configuration);
            List<Hotel> hotels = HotelsDb.GetAllHotels();
            hotels.ForEach(delegate(Hotel hotel){
                Console.WriteLine(hotel);
            });
        }
    }
}
