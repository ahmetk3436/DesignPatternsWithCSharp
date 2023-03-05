using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();

            Console.ReadLine();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);
    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4Net");    
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }
    }
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
    public class MemCaching : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with MemCache");

        }
    }
    public class RedisCaching : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with RedisCache");

        }
    }
    public abstract class CrossCuttingConcersFactory1
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    public class Factory1 : CrossCuttingConcersFactory1
    {
        public override Caching CreateCaching()
        {
            return new RedisCaching();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }
    public class Factory2 : CrossCuttingConcersFactory1
    {
        public override Caching CreateCaching()
        {
            return new RedisCaching();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class ProductManager
    {
        private CrossCuttingConcersFactory1 _crossCuttingConcersFactory1;
        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttingConcersFactory1 crossCuttingConcersFactory1)
        {
            _crossCuttingConcersFactory1 = crossCuttingConcersFactory1;
            _logging = _crossCuttingConcersFactory1.CreateLogger();
            _caching = _crossCuttingConcersFactory1.CreateCaching();
        }
        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Cached Product 1");
            Console.WriteLine("Products Listed!");
        }
    }
}
