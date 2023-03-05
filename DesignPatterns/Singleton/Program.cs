using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class CustomerManager {
        private static CustomerManager _instance; 
        static object _instanceLock = new object();
        private CustomerManager()
        {

        }
        public static CustomerManager GetCustomerManager()
        {
          lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new CustomerManager();
                }
            }
          return _instance;
                
        }
}
   
}
