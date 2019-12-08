using MyTobaccoShop.Data;
using MyTobaccoShop.Logic;
using MyTobaccoShop.Logic.Customers_Logic;
using MyTobaccoShop.Logic.Products_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace My_Tobacco_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            UserLogic userLogic = new UserLogic();
            if(userLogic.GetUser("abdul76").Count() > 0)
            {
                WebClient webClient = new WebClient();
                String context = webClient.DownloadString("http://localhost:8080/MyTobaccoShop.Java/username?username=" + "abdul76");
                Console.WriteLine(context);
            }
            CustomerLogic customerLogic = new CustomerLogic();
            // userLogic.UpdateUserType(2, "Admin");
            var s = userLogic.GetAdminUsers();
            foreach (var item in s)
            {
                Console.WriteLine(item.Name + "Type : " + item.User_type );

            }

            //Console.WriteLine(userLogic.GetUser(1));
            //Console.WriteLine(userLogic.GetUser(2));
            Console.WriteLine(customerLogic.SumOfCustomers());

            ProductLogic productLogic = new ProductLogic();
            var avgPrice = productLogic.GetAveragePrices();
            foreach (var item in avgPrice)
            {
                Console.WriteLine(item);
            }
        }
    }
}
