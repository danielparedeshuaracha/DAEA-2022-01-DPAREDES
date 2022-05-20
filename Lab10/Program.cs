using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Origen de datos
            NorthwndDataContext context = new NorthwndDataContext();

            Console.WriteLine("==============Ejercicio 1================");
            //Creación de consulta
            var query1 = from p in context.Products
            select p;
            //Ejecución de consulta
            foreach (var prod in query1)
            {
                Console.WriteLine("ID={0} \t Name={1}", prod.ProductID, prod.ProductName);
            }

            Console.WriteLine("==============Ejercicio 2================");
            //Creación de consulta
            var query2 = from p in context.Products
            where p.Categories.CategoryName == "Beverages"
            select p;
            //Ejecución de consulta
            foreach (var prod in query2)
            {
                Console.WriteLine("ID={0} \t Name={1}", prod.ProductID, prod.ProductName);
            }

            Console.WriteLine("==============Ejercicio 3================");
            //Creación de consulta
            var query3 = from p in context.Products
                        where p.UnitPrice < 20
                        select p;
            //Ejecución de consulta
            foreach (var prod in query3)
            {
                Console.WriteLine("ID={0} \t Price={1} \t Name={2}", 
                    prod.ProductID, prod.UnitPrice, prod.ProductName);
            }

            Console.WriteLine("==============Ejercicio 4================");
            //Creación de consulta
            var query4 = from p in context.Products
                             where p.ProductName.Contains("Queso")
                             select p;
            foreach (var prod in query4)
            {
                Console.WriteLine("ID={0} \t Name={1}", prod.ProductID, prod.ProductName);
            }

            Console.WriteLine("==============Ejercicio 5================");
            var query5 = from p in context.Products
                               where p.QuantityPerUnit.Contains("pkg") || p.QuantityPerUnit.Contains("pkgs")
                               select p;
            foreach (var prod in query5)
            {
                Console.WriteLine("ID={0} \t Name={1} \t QuantityPerUnit={2}", prod.ProductID, prod.ProductName,prod.QuantityPerUnit);
            }

            Console.WriteLine("==============Ejercicio 6================");
            var query6 = from p in context.Products
                              where p.ProductName.ToLower().StartsWith("A")
                              select p;
            foreach (var prod in query6)
            {
                Console.WriteLine("ID={0} \t Name={1} \t UnitPrice={2}",prod.ProductID, prod.ProductName, prod.UnitPrice);
            }

            Console.WriteLine("==============Ejercicio 7================");
            var query7 = from p in context.Products
                                 where p.UnitsInStock == 0
                                 select p;
            foreach (var prod in query7)
            {
                Console.WriteLine("ID={0} \t Name={1} \t UnitsInStock={2}",
                    prod.ProductID, prod.ProductName, prod.UnitsInStock);
            }

            Console.WriteLine("==============Ejercicio 8================");
            var query8 = from p in context.Products
                                         where p.Discontinued == true
                                         select p;
            foreach (var prod in query8)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Discontinued={2}",
                    prod.ProductID, prod.ProductName, prod.Discontinued);
            }

            //////INSERTAR DATOS EN TABLA PRODUCTS
            //Products pi = new Products();
            //pi.ProductName = "Peruvian Coffee";
            //pi.SupplierID = 20;
            //pi.CategoryID = 1;
            //pi.QuantityPerUnit = "10 pkgs";
            //pi.UnitPrice = 25;

            ////Ejecución de consulta
            //context.Products.InsertOnSubmit(pi);
            //context.SubmitChanges();

            //INSERTAR DATOS EN TABLA CATEGORIES
            //Categories nc = new Categories();
            //nc.CategoryName = "Monitores";
            //nc.Description = "Monitores para videojuegos, hogar y oficina";

            ////Ejecución de la consulta
            //context.Categories.InsertOnSubmit(nc);
            //context.SubmitChanges();

            //MODIFICAR DATOS
            //var product = (from p in context.Products
            //               where p.ProductName == "Tofu"
            //               select p).FirstOrDefault();

            //product.UnitPrice = 100;
            //product.UnitsInStock = 15;
            //product.Discontinued = true;

            ////Ejecución de la consulta
            //context.SubmitChanges();

            ////ELIMINACIÓN DE DATOS
            //var product = (from p in context.Products
            //                       where p.ProductID == 78
            //                       select p).FirstOrDefault();

            ////Ejecución de la consulta
            //context.Products.DeleteOnSubmit(product);
            //context.SubmitChanges();

            //TAREA Ejercicio 1
            //Console.WriteLine("==============Tarea Ejercicio 1================");
            //var queryTarea1 = from p in context.Products
            //                    where p.Categories.CategoryName == "Dairy Products"
            //                    select p;
            //foreach (var prod in queryTarea1)
            //{
            //    Console.WriteLine("ID={0} \t Name={1} \t SupplierName={2}",
            //        prod.ProductID, prod.ProductName, prod.Suppliers.CompanyName);
            //}

            //TAREA Ejercicio 2
            Console.WriteLine("==============Tarea Ejercicio 2================");
            var queryTarea2 = from p in context.Products
                               where p.Suppliers.Country.ToLower() == "usa"
                               select p;
            foreach (var prod in queryTarea2)
            {
                Console.WriteLine("ID={0} \t Name={1} \t SupplierName={2} \t Country={3}",
                    prod.ProductID, prod.ProductName, prod.Suppliers.CompanyName, prod.Suppliers.Country);
            }

            Console.ReadKey();

        }
    }
}
