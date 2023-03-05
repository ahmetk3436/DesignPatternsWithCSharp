using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager= new CustomerManager();
            customerManager.SenderBase = new EmailSender();
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }
    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved!");
        }
        public abstract void Send(Body body);
    }
    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body);
        }
    }
    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EmailSender", body);
        }
    }
    class CustomerManager
    {
        public MessageSenderBase SenderBase { get; set; }
        public void UpdateCustomer ()
        {
            SenderBase.Send(new Body());
                Console.WriteLine("Customer updated");
        }
    }
}
