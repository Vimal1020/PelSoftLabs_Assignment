using PelSoftLabsTest.Models;

namespace PelSoftLabsTest.Services.Interfaces
{
    public interface IProduct
    {
        List<Product> SearchProducts(SearchProductCriteria searchProduct);
    }
}
