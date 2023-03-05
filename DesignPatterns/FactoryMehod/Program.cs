using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMehod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager= new CustomerManager(new LoggerFactory());
            customerManager.Save();

            Console.ReadLine();
        }
    }
    public class LoggerFactory : ILoggerFactory
    {
       public ILogger CreateLogger()
        {
            return new AckLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new KizilkayaLogger();
        }
    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
    public class AckLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine(" Logged with Ack logger");
        }
    }
    public class KizilkayaLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine(" Logged with KizilkayaLogger");
        }
    }
    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger(); 
            logger.Log();   
        }
    }

}
