using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditBase manager = new CreditManagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());
            Console.ReadLine();
        }
    }
    abstract class CreditBase
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i <= 10; i++)
            {
                result *= i;
                Thread.Sleep(100);
            }
            return result;  
        }
    }
    class CreditManagerProxy : CreditBase
    {
        private CreditManager creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
           if(creditManager == null ) { 
                creditManager = new CreditManager();
            _cachedValue = creditManager.Calculate();
            } 
           return _cachedValue;
        }
    }
}
