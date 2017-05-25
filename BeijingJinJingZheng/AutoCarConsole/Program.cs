using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarConsole
{
    class Program
    {

       
        static void Main(string[] args)
        {
            BeijingJiaojingApp app = new BeijingJiaojingApp();
            app.LoginWithUserID("EC3DD6EBD84948BCA57D610292E3836C");
            var cars = app.GetCars();
            foreach (var car in cars)
            {
                Console.Write(car.carno);
            }

            Console.ReadKey();
        }
    }
}
