using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinParser.Data
{
    public class Order
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public DateTime DateCreate { get; set; }
        public string State { get; set; }
        public string Link { get; set; }
        public string DownloadLink 
        {
            get 
            {
                if (string.IsNullOrEmpty(Link))
                    return "X";
                else
                    return "Скачать";
            }
        }


        public string CadastralNumber { get; set; }
        public string FullAdderess { get; set; }
        public string TypeObject { get; set; }
        public string Square { get; set; }
        public string CategoryZU { get; set; }
        public string TypeZU { get; set; }
        public string Purpose { get; set; }

        public IWebElement HtmlObject { get; set; }
    }
}
