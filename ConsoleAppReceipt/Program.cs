using ConsoleAppReceipt.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfReceipt;

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
                        List<Article> articles = service.GetAllArticles();
                        List<string> reciept = new List<string>();
                        while (true)
                        {
                            int i = 1;
                            Console.WriteLine("\nPress '#' when you want to finish shopping.\nPlease choose one of the following articles:");
                            foreach (var item in articles)
                            {
                                Console.WriteLine(i++ + "." + item.ToString());
                            }
                            string chosen = Console.ReadLine();
                            if (chosen == "#")
                            {
                                service.AddNewReciept(reciept);
                                break;
                            }
                            string amountBought = "";
                            int amountBoughti;
                            while (!int.TryParse(amountBought, out amountBoughti))
                            {
                                Console.WriteLine("Amount:"); amountBought = Console.ReadLine();
                            }
                            try
                            {
                                if (articles[Convert.ToInt32(chosen) - 1].Amount - amountBoughti >= 0)
                                {
                                    articles[Convert.ToInt32(chosen) - 1].Amount -= amountBoughti;
                                    reciept.Add(articles[Convert.ToInt32(chosen) - 1].ToString() + " amount bought: " + amountBought);
                                }
                                else
                                {
                                    Console.WriteLine("Article amount can not be less then 0.");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("There is no article with number {0}", chosen);
                            }
                        }
                        Console.WriteLine("\nYour reciept:");
                        Console.WriteLine(string.Join("\n", reciept));
                        service.ClearFile();
                        foreach (var item in articles)
                        {
                            service.AddNewArticle(item);
                        }
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
                        Article article = new Article(name, Convert.ToInt32(price), Convert.ToInt32(amount));
                        service.AddNewArticle(article);
                        break;


                    case "4":
                        Console.WriteLine("\n\tArticles:\n");
                        Console.WriteLine(String.Join("\n", service.GetAllArticles()));
                        Console.WriteLine("\n");
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
            Console.WriteLine("\n1. Make a purchase");
            Console.WriteLine("2. Update an article");
            Console.WriteLine("3. Add an article");
            Console.WriteLine("4. View all articles");
            Console.WriteLine("5. Exit\n");
        }
    }
}
