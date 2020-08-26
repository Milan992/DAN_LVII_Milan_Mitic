using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfReceipt
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static int counter = 0;

        public void AddNewReciept(List<string> reciept)
        {
            string location = AppDomain.CurrentDomain.BaseDirectory + "/Reciept_" + counter++ +"_"+ DateTime.Now.Millisecond.ToString() + ".txt";

            using (StreamWriter sw = new StreamWriter(location, true))
            {
                foreach (var item in reciept)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public void AddNewArticle(Article article)
        {
            string location = AppDomain.CurrentDomain.BaseDirectory + "/Articles.txt";

            using (StreamWriter sw = new StreamWriter(location, true))
            {
                sw.WriteLine("Name:{0}, Price:{1}, Amount:{2}", article.Name, article.Price, article.Amount);
            }
        }

        public List<Article> GetAllArticles()
        {
            List<Article> articles = new List<Article>();
            try
            {
                string location = AppDomain.CurrentDomain.BaseDirectory + "/Articles.txt";

                using (StreamReader sr = new StreamReader(location))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] array = line.Split(':', ',');
                        Article a = new Article(array[1], Convert.ToInt32(array[3]), Convert.ToInt32(array[5]));
                        articles.Add(a);
                    }
                }
            }
            catch
            {
                Article a = new Article();
                articles.Add(a);
            }
            return articles;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        public void ClearFile()
        {
            string location = AppDomain.CurrentDomain.BaseDirectory + "/Articles.txt";

            using (StreamWriter sw = new StreamWriter(location, false))
            {
                sw.Write("");
            }
        }
    }
}
