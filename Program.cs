using EntityDemo03.Contexts;
using EntityDemo03.Entities;
using EntityDemo03.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityDemo03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DemoContext context = new DemoContext()) {

                #region CRUD ON TPH
                //Car C01 = new Car() { Make = "BMW", DoorsCount = 4, Model = "X6" };
                //Car C02 = new Car() { Make = "Aston Martin", DoorsCount = 2, Model = "S1" };

                //Truck T01 = new Truck()
                //{
                //    LoadCapacity = 700,
                //    Make = "Mercedus",
                //    Model = "GC"

                //};
                //Truck T02 = new Truck()
                //{
                //    LoadCapacity = 1200,
                //    Make = "Toytoa",
                //    Model = "X3"

                //};

                //Console.WriteLine(context.Entry(C01).State);
                //Console.WriteLine(context.Entry(C02).State);
                //context.vechicles.Add(C01);
                //context.Add(C02);
                //context.Set<Truck>().Add(T01);
                //context.Add(T02);
                //context.SaveChanges();
                //Console.WriteLine(context.Entry(C01).State);
                //Console.WriteLine(context.Entry(C02).State);


                //var cars = context.vechicles.Where(x=>EF.Property<string>(x, "VechicleType") == "Car").ToList();

                //foreach (var item in context.vechicles.OfType<Car>())
                //    Console.WriteLine(item);
                //foreach (var item in context.cars)
                //    Console.WriteLine(item);
                //foreach (var item in context.Trucks)
                //    Console.WriteLine(item); 
                #endregion
            }

            using (NorthwindContext northwind = new NorthwindContext()) {

                #region Join By (Fluent) And (Query) Syntax
                //var BeveragesCategory = (from Cat in northwind.Categories
                //             join pdt in northwind.Products
                //             on Cat.CategoryID equals pdt.CategoryID
                //             select new
                //             {
                //                 ProductName = pdt.ProductName,
                //                 CategoryName = Cat.CategoryName,
                //                 ProductUnitInStock = pdt.UnitsInStock,
                //                 CategoryDesc = Cat.Description
                //             }).Where(x=>x.CategoryName== "Beverages").ToList();
                //foreach (var item in BeveragesCategory)
                //{
                //    Console.WriteLine(item);
                //}

                //var BeveragesCategory = northwind.Products.Join(northwind.Categories, x => x.CategoryID, y => y.CategoryID, (Prod, Cat) => new {
                //ProductName = Prod.ProductName,
                //CategoryName = Cat.CategoryName,
                //ProductUnitStock = Prod.UnitsInStock,
                //CatgoryDesc = Cat.Description

                //}).Where(x=>x.CategoryName== "Beverages").ToList();

                //foreach (var item in BeveragesCategory)
                //{
                //    Console.WriteLine(item);
                //} 
                #endregion

                #region Stored Procedure
                NorthwindContextProcedures contextProcedures = new NorthwindContextProcedures(northwind);
                //var BeveragesCategory = contextProcedures.SalesByCategoryAsync("Beverages", "1998").Result;

                //foreach (var item in BeveragesCategory)
                //    Console.WriteLine($"ProdName = {item.ProductName}, TotalPurchase= {item.TotalPurchase}");



                //var SalesByYear  = contextProcedures.SalesbyYearAsync(new DateTime(1998,01,01), new DateTime( 2024,01,01)).Result;
                //foreach (var item in SalesByYear)
                //{
                //    Console.WriteLine($"OrderID=>{item.OrderID}, Year=> {item.Year}, Subtotal=> {item.Subtotal}, ShippedDate=>{item.ShippedDate}");
                //}


                //var CustomerOrderHistory = contextProcedures.CustOrderHistAsync("ALFKI").Result;
                //foreach (var item in CustomerOrderHistory)
                //{
                //    Console.WriteLine($"ProductName=> {item.ProductName},Total=> {item.Total}");
                //}
                //var y = contextProcedures.CustOrdersOrdersAsync("ALFKI").Result;
                //foreach (var item in y)
                //{
                //    Console.WriteLine($"OrderID = {item.OrderID}, OrderDate = {item.OrderDate}, RequiredDate = {item.RequiredDate},ShippedDate = {item.ShippedDate}");
                //}
                #endregion
                #region Views
                //var ProductPrice = northwind.Products_Above_Average_Prices;
                //foreach (var item in ProductPrice)
                //{
                //    Console.WriteLine($"ProductName=> {item.ProductName},UnitPrice=> {item.UnitPrice}");
                //}

                //var CategoryProducts = northwind.Products_by_Categories.ToList();
                //foreach (var item in CategoryProducts)
                //{
                //    Console.WriteLine($"{item.ProductName}, {item.CategoryName}, {item.QuantityPerUnit}");
                //}

                //var CurrentProducts = northwind.Current_Product_Lists;
                //foreach (var item in CurrentProducts)
                //{
                //    Console.WriteLine($"ProductID = {item.ProductID}, ProductName = {item.ProductName}");
                //}
                //var invoice = northwind.Invoices.Where(x=>x.Region == "Co. Cork");
                //foreach (var item in invoice)
                //{
                //    Console.WriteLine($"ProductName = {item.ProductName},UnitPrice = {item.UnitPrice}");
                //}
                #endregion
                #region Run Sql Query

                #region 1.Execute Select Statement
                //var category = "Beverages";
                //var result = northwind.Categories.FromSqlRaw("select * from Categories").ToList();
                //var result = northwind.Categories.FromSqlInterpolated($"select * from Categories where CategoryName = {category}").ToList();

                //var result = northwind.Categories.Where(x => x.CategoryName == category);
                //foreach (var item in result)
                //{
                //    Console.WriteLine($"CategoryID = {item.CategoryID},CategoryName = {item.CategoryName},Description = {item.Description}");
                //} 
                #endregion


                #region 2.Execute DML Query
                //northwind.Database.ExecuteSqlInterpolated($"update Products set ProductName ='Chai02' where ProductId = {2}");
                #endregion


                #endregion

                #region Lazy Loading Vs Eager Loading Vs Explicit Loading


                //var result = northwind.Products.ToList();

                //foreach (var item in result)
                //{
                //Console.WriteLine($"ProductID: {item.ProductID} ,UnitPrice: {item.UnitPrice}");
                //Console.WriteLine($"ProductID: {item.ProductID} ,UnitPrice: {item.UnitPrice} {item.Category.CategoryID}");//NullReferenceException, Category is Null
                //}

                //var productsWithCategories = northwind.Products.Include(x=>x.Category).FirstOrDefault();
                //var productsWithCategories = northwind.Products.Include(x=>x.Category).ThenInclude(x=>x.Products).FirstOrDefault();
                //var Category = productsWithCategories?.Category.CategoryName;
                //Console.WriteLine(Category);

                //var product = northwind.Products.FirstOrDefault(); //InvalidOperationException With UseLazyLoadingProxies(true) because Category is not Virual
                ////var category =   northwind.Categories.FirstOrDefault();

                //var CategoryName = product.Category.CategoryName;
                //Console.WriteLine(CategoryName);
                //northwind.Entry(product).Reference(x => x.Category).Load();
                //northwind.Entry(category).Collection(x=>x.Products).Load();
                #endregion

                #region Remote Vs Local

                //northwind.Products.Load(); //Request from Database  

                //if(northwind.Products.Local.Any(x=>x.UnitsInStock==0)) //Not Request from Database  
                //    Console.WriteLine("There are out of stock products");
                //else
                //    Console.WriteLine("There aren't out of stock products");
                #endregion
            }

        }
    }
}
