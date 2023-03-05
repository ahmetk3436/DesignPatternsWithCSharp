using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Attach(new EmployeeObserver());  
            productManager.UpdatePrice();
            Console.ReadLine();
        }
    }
    class ProductManager
    {
        List<Observer> observers= new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }
        public void Attach (Observer observer)
        {
            observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        private void Notify()
        {
            foreach (var item in observers)
            {
                item.Update(); 
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }
    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Messager to Customer : Product price changed ! ");
        }
    }
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Messager to Customer : Product price changed ! ");
        }
    }
}
