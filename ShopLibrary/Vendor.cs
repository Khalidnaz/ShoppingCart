using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Vendor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Commission { get; set; }

        //constructor. you can tell its a constructor because there is no return type. gets ran when ever this class gets instantuated.
        public Vendor()
        {
           Commission = .5;
        }
    }
}
