using ConsoleAppReceipt.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppReceipt
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client service = new Service1Client();

            Console.WriteLine("\tWELCOME\n");

            while (true)
            {
                ViewMenu();

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":

                        break;

                    case "2":

                        break;

                    case "3":
                        string name = "";
                        string price = "";
                        string amount = "";
                        while (name.Length < 1)
                        {
                            Console.WriteLine("\nEnter article name:");
                            name = Console.ReadLine();
                        }
                        int pricei;
                        while (!int.TryParse(price, out pricei))
                        {
                            Console.WriteLine("\nEnter article price:");
                            price = Console.ReadLine();
                        }
                        int amounti;
                        while (!int.TryParse(amount, out amounti))
                        {
                            Console.WriteLine("\nEnter article amount:");
                            amount = Console.ReadLine();
                        }
                        service.AddNewArticle(name, price, amount);
                        break;


                    case "4":
                        Console.WriteLine(String.Join("\n", service.GetAllArticles()));
                        break;


                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\n\tPlease choose one of the following options:\n");
                        break;
                }
            }
        }

        public static void ViewMenu()
        {
            Console.WriteLine("1. Make a purchase");
            Console.WriteLine("2. Update an article");
            Console.WriteLine("3. Add an article");
            Console.WriteLine("4. View all articles");
            Console.WriteLine("5. Exit\n");
        }
    }
}
