using Microsoft.AspNetCore.Mvc;
using PelSoftLabsTest.Models;
using PelSoftLabsTest.Services.Interfaces;

namespace PelSoftLabsTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _productService;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            return View(new SearchProductCriteria());
        }

        [HttpPost]
        public ActionResult Search(SearchProductCriteria criteria)
        {
            try
            {
                var searchResults = _productService.SearchProducts(criteria);

                var viewModel = new SearchResultsView
                {
                    SearchCriteria = criteria,
                    SearchResults = searchResults
                };

                return PartialView("_SearchResults", viewModel);
            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = ex.Message;
                return PartialView("_SearchResults");
            }
        }
    }
}