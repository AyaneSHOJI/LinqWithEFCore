using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;

FilterAndSort();

static void FilterAndSort()
{
    using(Northwind db = new())
    {
        DbSet<Product> allProducts = db.Products;
        //IQueryable<Product> filteredProducts = allProducts.Where(product => product.UnitPrice < 10M);
        //// IOrderedQueryable : Represents the result of a sorting operation.
        //IOrderedQueryable<Product> sortedAndFilteredProducts = filteredProducts.OrderByDescending(product => product.UnitPrice);
    
        // IOrderedQueryable : Represents the result of a sorting operation.
        IQueryable<Product> sortedAndFilteredProducts = allProducts.Where(product => product.UnitPrice < 10M).OrderByDescending(product => product.UnitPrice);

        WriteLine("Products that cost less than $10:");
        foreach(Product p in sortedAndFilteredProducts)
        {
            WriteLine("{0}:{1} costs {2:$#,##0.00}", 
                p.ProductId, p.ProductName, p.UnitPrice);
        }
        WriteLine();
    }
}