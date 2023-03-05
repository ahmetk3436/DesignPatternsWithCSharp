using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();
        }
    }
    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Info("User data");
            Console.WriteLine("Saved");
        }
    }
    interface ILogger
    {
        void Info(string message);
    }
    class EdLogger : ILogger
    {
        public void Info(string message)
        {
           Console.WriteLine("Message, {0}" , message);  
        }
    }
    class Log4Net
    {
        public void Log(string message) { Console.WriteLine("Message , {0}",message); }
    }
    class Log4NetAdapter : ILogger
    {
        public void Info(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.Log(message);
                }
    }
}
