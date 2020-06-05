using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace W3
{
    class Program
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        static void WeatherData()
        {
            while(true)
            {
                try 
                {
                    Console.WriteLine("╔════════════╤══════════════════════════════╗");
                    Console.WriteLine("   Hot key   │            Function       ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      A      │          Add product  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      S      │     Search product by name  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      D      │     Delete product by name ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      T      │         Show products  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("    Space    │         Clear console  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("     Esc     │          Exit program  ");
                    Console.WriteLine("╚════════════╧══════════════════════════════╝");

                    var data = JsonConvert.DeserializeObject<List<Product_range>>(File.ReadAllText(FilePath));

                    int menuselect = 0;
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.A:
                            menuselect = 1;
                            break;
                        case ConsoleKey.S:
                            menuselect = 2;
                            break;
                        case ConsoleKey.T:
                            menuselect = 3;
                            break;
                        case ConsoleKey.Escape:
                            menuselect = 4;
                            break;
                        case ConsoleKey.D:
                            menuselect = 5;
                            break;
                    }

                    if (menuselect == 1)
                    {
                        Console.Clear();

                        Console.WriteLine("Enter product info\n");
                        Console.WriteLine("Product id");
                        string id = Console.ReadLine();
                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Product mass: ");
                        string mass = Console.ReadLine();
                        Console.WriteLine("Clear price: ");
                        string clPrice = Console.ReadLine();
                        Console.WriteLine("Shop price: ");
                        string shopPrice = Console.ReadLine();

                        if (id != null && name != null && mass != null && clPrice != null && shopPrice != null)
                        {
                            data.Add(new Product_range { Id = id, Name = name, Mass = mass, ClearPrice = clPrice, ShopPrice = shopPrice });
                        }
                        else
                        {
                            Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                        }
                        Console.Clear();
                    }

                    if (menuselect == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter search product name: ");
                        string name = Console.ReadLine();
                        if (Console.ReadLine() != null)
                        {
                            Console.Clear();
                            Product_range FoundData = data.Find(found => found.Name == name);
                            if (FoundData != null)
                            {
                                Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                Console.WriteLine("      ID     │    Name    │   Mass   │ Clear price │  Shop price");
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", FoundData.Id, FoundData.Name, FoundData.Mass, FoundData.ClearPrice, FoundData.ShopPrice);
                                Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");


                                Console.WriteLine("\nTo edit press 'E'");
                                Console.WriteLine("\n\nTo edit press 'D'");
                                if (Console.ReadKey().Key == ConsoleKey.E)
                                {
                                    Console.WriteLine("Edit product info\n");
                                    Console.WriteLine("Product id");
                                    string id = Console.ReadLine();
                                    Console.WriteLine("Name: ");
                                    string namE = Console.ReadLine();
                                    Console.WriteLine("Product mass: ");
                                    string mass = Console.ReadLine();
                                    Console.WriteLine("Clear price: ");
                                    string clPrice = Console.ReadLine();
                                    Console.WriteLine("Shop price: ");
                                    string shopPrice = Console.ReadLine();

                                    if (id == null || namE == null || mass == null || clPrice == null || shopPrice == null)
                                    {
                                        Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                                    }
                                    FoundData.Id = id;
                                    FoundData.Name = namE;
                                    FoundData.Mass = mass;
                                    FoundData.ClearPrice = clPrice;
                                    FoundData.ShopPrice = shopPrice;
                                    Console.Clear();
                                    Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                    Console.WriteLine("      ID     │    Name    │   Mass   │ Clear price │  Shop price");
                                    Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                    Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", FoundData.Id, FoundData.Name, FoundData.Mass, FoundData.ClearPrice, FoundData.ShopPrice);
                                    Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                                }
                                if (Console.ReadKey().Key == ConsoleKey.D)
                                {
                                    data.RemoveAll(x => x.Name == name);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Error\n\n" +
                            "City not found");
                            }
                             
                            
                        }
                    }

                    if (menuselect == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                        Console.WriteLine("      ID     │    Name    │   Mass   │ Clear price │  Shop price");
                        Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                        for (int i = 0; i < data.Count; i++)
                        {
                            Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", data[i].Id, data[i].Name, data[i].Mass, data[i].ClearPrice, data[i].ShopPrice);
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");

                        }
                        Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        Console.WriteLine("\nTo sort by name press 'S'");
                        if (Console.ReadKey().Key == ConsoleKey.S)
                        {

                            Console.Clear();
                            List<Product_range> SortData = data.OrderBy(o => o.ShopPrice).ToList();
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("      ID     │    Name    │   Mass   │ Clear price │  Shop price");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", SortData[i].Id, SortData[i].Name, SortData[i].Mass, SortData[i].ClearPrice, SortData[i].ShopPrice);
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            }
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        }
                        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                        {
                            Console.Clear();
                        }
                    }

                    if (menuselect == 4)
                    {
                        Environment.Exit(0);
                    }

                    if (menuselect == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter city to delete: ");
                        string name = Console.ReadLine();
                        if (Console.ReadLine() != null)
                        {
                            Console.Clear();
                            Product_range FoundData = data.Find(found => found.Name == name);
                            if (FoundData != null)
                            {
                                Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                Console.WriteLine("      ID     │    Name    │   Mass   │ Clear price │  Shop price");
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", FoundData.Id, FoundData.Name, FoundData.Mass, FoundData.ClearPrice, FoundData.ShopPrice);
                                Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                                data.RemoveAll(x => x.Name == name);
                                Console.WriteLine("This information has been deleted");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Error\n\n" +
                            "City not found");
                            }


                        }
                    }

                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                    }

                    string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                    if (serialize.Count() > 1)
                    {
                        if (!File.Exists(FileName))
                        {
                            File.Create(FileName).Close();
                        }
                        File.WriteAllText(FilePath, serialize, Encoding.UTF8);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                
            } 
        }
        static void Main(string[] args)
        {
            WeatherData();
        }
    }

    public class Product_range
    {
        private string id;
        private string name;
        private string mass;
        private string clearPrice;
        private string shopPrice;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Mass
        {
            get { return mass; }
            set { mass = value; }
        }
        public string ClearPrice
        {
            get { return clearPrice; }
            set { clearPrice = value; }
        }
        public string ShopPrice
        {
            get { return shopPrice; }
            set { shopPrice = value; }
        }

    }
}
