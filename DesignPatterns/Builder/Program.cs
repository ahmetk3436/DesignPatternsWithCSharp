using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            productDirector.GenerateProduct(builder);
            Console.WriteLine(builder.GetModel().Id.ToString());
            Console.WriteLine(builder.GetModel().ProductName.ToString());
            Console.WriteLine(builder.GetModel().UnitPrice.ToString());
            Console.WriteLine(builder.GetModel().CategoryName.ToString());
            Console.WriteLine(builder.GetModel().DiscountApplied.ToString());
            Console.WriteLine(builder.GetModel().DiscountedPrice.ToString());

            Console.ReadLine();
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }
    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();

    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel viewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            viewModel.DiscountedPrice = viewModel.UnitPrice *(decimal) 0.90;
            viewModel.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return viewModel;
        }

        public override void GetProductData()
        {
            viewModel.Id = 1;
            viewModel.CategoryName = "T-Shirt";
            viewModel.ProductName = "Zai";
            viewModel.UnitPrice = 20;
        }
    }
    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel viewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            viewModel.DiscountedPrice = viewModel.UnitPrice;
            viewModel.DiscountApplied = true;
        }

        public override void GetProductData()
        {
            viewModel.Id = 1;
            viewModel.CategoryName = "T-Shirt";
            viewModel.ProductName = "Zai";
            viewModel.UnitPrice = 20;
        }
        public override ProductViewModel GetModel()
        {
            return viewModel;
        }
    }
    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
