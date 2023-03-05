using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }
    public class Cache : ICache
    {
        void ICache.Cache(string data)
        {
            Console.WriteLine(data);
        }
    }

    public interface ICache
    {
        void Cache(string data);
    }

    public class Logger : ILogger
    {
        public void Log(string message)
        {
           Console.WriteLine(message);  
        }
    }
    public interface ILogger
    {
        void Log(string message);
    }
    public class CrossCuttingConcerns
    {
        public ILogger logger;
        public ICache cache;
        public CrossCuttingConcerns()
        {
            logger = new Logger();
            cache = new Cache();

        }
    }
    public class CustomerManager
    {
        private CrossCuttingConcerns cuttingConcerns;
        public CustomerManager()
        {
          cuttingConcerns =  new CrossCuttingConcerns();
        }
        public void Save()
        {
            cuttingConcerns.cache.Cache("Cached");
            cuttingConcerns.logger.Log("Logged");
        }
    }
}
