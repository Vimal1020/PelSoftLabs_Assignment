using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PelSoftLabsTest.Models;
using PelSoftLabsTest.Services.Interfaces;

public class ProductService : IProduct
{
    private readonly ProductContext _productContext;

    public ProductService(ProductContext productContext)
    {
        _productContext = productContext;
    }

    public List<Product> SearchProducts(SearchProductCriteria searchProduct)
    {
        var sql = "CALL SearchProducts(@ProductName, @Size, @Price, @MfgDate, @Category, @Conjunction)";

        var parameters = new List<MySqlParameter>
        {
            new MySqlParameter("@ProductName", searchProduct.ProductName),
            new MySqlParameter("@Size", searchProduct.Size),
            new MySqlParameter("@Price", searchProduct.Price),
            new MySqlParameter("@MfgDate", searchProduct.MfgDate),
            new MySqlParameter("@Category", searchProduct.Category),
            new MySqlParameter("@Conjunction", searchProduct.Conjunction)
        };

        parameters.ForEach(p => p.Value ??= DBNull.Value);

        var sqlParameters = parameters.Cast<MySqlParameter>().ToArray();

        return _productContext.Set<Product>().FromSqlRaw(sql, sqlParameters).ToList();
    }
}
