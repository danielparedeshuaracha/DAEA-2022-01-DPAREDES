using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Globalization;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;

namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;
                IQueryable<String> ProductNames = from p in products
                                                  select p.Name;
                Console.WriteLine("Productos");
                foreach (var productName in ProductNames)
                {
                    Console.WriteLine(productName);
                }
                Console.ReadLine();
            }
            */
            /*
             using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;
                IQueryable<String> ProductNames = products.Select(p => p.Name);
                
                Console.WriteLine("Productos");
                foreach (var productName in ProductNames)
                {
                    Console.WriteLine(productName);
                }
                Console.ReadLine();
            }
            */
            /*
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;
                IQueryable<Product> productsQuery = from p in products
                                                    select p;

                IQueryable<Product> largeProducts = productsQuery.Where(p => p.Size == "L");
                Console.WriteLine("Productos de tamaño 'L'");
                foreach (var product in largeProducts)
                {
                    Console.WriteLine(product.Name + " - " + product.ProductID);
                }
                Console.ReadLine();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Product> productQuery = from product in context.Product
                                                   select product;
                Console.WriteLine("Productos");
                foreach (var prod in productQuery)
                {
                    Console.WriteLine(prod.Name);
                }
                Console.ReadLine();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from product in context.Product
                            select new
                            {
                                ProductId = product.ProductID,
                                ProductName = product.Name
                            };
                Console.WriteLine("Información de productos");
                foreach (var productInfo in query)
                {
                    Console.WriteLine("Product ID: {0} Product Name: {1}",
                            productInfo.ProductId, productInfo.ProductName);
                }
                Console.ReadLine();
            }
            */
            /*
            int orderQtyMin = 2;
            int orderQtMax = 6;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from order in context.SalesOrderDetail
                            where order.OrderQty > orderQtyMin
                            && order.OrderQty < orderQtMax
                            select new
                            {
                                SalesOrderID = order.SalesOrderID,
                                OrderQty = order.OrderQty
                            };
                foreach (var order in query)
                {
                    Console.WriteLine("Order ID: {0} Order Quantity: {1}",
                            order.SalesOrderID, order.OrderQty);
                }
                Console.ReadLine();
            }
            */
            /*
            String color = "Red";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from product in context.Product
                            where product.Color == color
                            select new
                            {
                                Name = product.Name,
                                ProductNumber = product.ProductNumber,
                                ListPrice = product.ListPrice
                            };
                foreach (var product in query)
                {
                    Console.WriteLine("Name: {0}", product.Name);
                    Console.WriteLine("Product number: {0}", product.ProductNumber);
                    Console.WriteLine("List price: ${0}", product.ListPrice);
                    Console.WriteLine("");
                }
                Console.ReadLine();
            }
            */
            /*
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                int?[] productModelIds = { 19, 26, 118 };
                var products = from p in AWEntities.Product
                               where productModelIds.Contains(p.ProductModelID)
                               select p;
                foreach (var product in products)
                {
                    Console.WriteLine("{0}: {1}",
                        product.ProductModelID, product.ProductID);
                }
                Console.ReadLine();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Decimal> sortedPrices = from p in context.Product
                                                   orderby p.ListPrice descending
                                                   select p.ListPrice;
                Console.WriteLine("Lista de precios desde el más alto al más bajo:");
                foreach (Decimal price in sortedPrices)
                {
                    Console.WriteLine(price);
                }
                Console.ReadLine();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var products = context.Product;
                var query = from product in products
                            group product by product.Style into g
                            select new
                            {
                                Style = g.Key,
                                AverageListPrice = g.Average(product => product.ListPrice)
                            };
                foreach (var product in query)
                {
                    Console.WriteLine("Estilo: {0} Precio promedio: {1}",
                        product.Style, product.AverageListPrice);
                }
                Console.ReadLine();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var products = context.Product;
                var query = from product in products
                            group product by product.Color into g
                            select new
                            {
                                Color = g.Key,
                                ProductCount = g.Count()
                            };
                foreach (var product in query)
                {
                    Console.WriteLine("Color = {0} \t Cantidad = {1}",
                        product.Color, product.ProductCount);
                }
                Console.ReadLine();
            }
            */
            /*
            using (AdventureWorksEntities eje16 = new AdventureWorksEntities())
            {
                var orders = eje16.SalesOrderHeader;
                var query = from order in orders
                            group order by order.SalesPersonID into g
                            select new
                            {
                                Category = g.Key,
                                maxTotalDue = g.Max(order => order.TotalDue)
                            };
                foreach (var order in query)
                {
                    Console.WriteLine("Person ID: {0} TotalDue Máximo: {1}",
                            order.Category, order.maxTotalDue);
                }
                Console.ReadLine();
            }
            */
        }
    }
}
