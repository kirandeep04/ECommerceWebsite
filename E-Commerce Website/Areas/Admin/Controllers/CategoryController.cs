using E_Commerce_Website.API.Models;
using E_Commerce_Website.Areas.Admin.Models;
using E_Commerce_Website.Helpers;
using E_Commerce_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace E_Commerce_Website.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpAPIWrapper _apiWrapper;

        public CategoryController(IConfiguration configuration, HttpAPIWrapper apiWrapper)
        {
            _configuration = configuration;
            _apiWrapper = apiWrapper;

        }
        [Area("Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var endpoint = Constants.APIEndpoints.Index;
          
            var categoriesResponse = await _apiWrapper.GetAsync<List<CategoryUIViewModel>>(endpoint);

            if (categoriesResponse.IsSuccess)
            {
                return View(categoriesResponse.data);
            }
            else
            {

                ModelState.AddModelError(string.Empty, "Failed to retrieve categories from the API.");
                return View(new List<CategoryUIViewModel>());
            }
        }


        [Area("Admin")]
        [HttpGet]        
        public IActionResult Create()
        {
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryUIViewModel model)
        {
            if (model != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var endpoint = Constants.APIEndpoints.Create;
                        var response = await _apiWrapper.CreateAsync<CategoryUIViewModel, string>(endpoint, model);

                        if (response != null && response.IsSuccess)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Failed to create category. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception according to your needs
                        ModelState.AddModelError(string.Empty, "An error occurred while processing your request. Please try again.");
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid model. Please provide valid data.");
            }

            return View(model);
        }

        //public async Task<IActionResult> Create(CategoryUIViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var endpoint = Constants.APIEndpoints.Create;
        //        var response = await _apiWrapper.CreateAsync<CategoryUIViewModel, string>(endpoint, model);

        //        if (response != null && response.IsSuccess)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Failed to create category. Please try again.");
        //        }
        //    }

        //    return View(model);
        //}
    }

}





