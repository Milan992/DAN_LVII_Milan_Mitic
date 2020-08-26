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
        public void AddNewArticle(string name, string price, string amount)
        {
            using (StreamWriter sw = new StreamWriter(@"Articles.txt", true))
            {
                sw.WriteLine("Name: {0}, Price: {1}, Amount: {2}", name, price, amount);
            }
        }

        public List<string> GetAllArticles()
        {
            List<string> articles = new List<string>();

            using (StreamReader sr = new StreamReader(@"..\..\Articles.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    articles.Add(line);
                }
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
    }
}
