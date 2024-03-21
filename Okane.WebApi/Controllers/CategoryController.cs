using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Okane.Application;
using Okane.Domain;

namespace Okane.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) =>
            _categoryService = categoryService;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExpenseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDictionary))]
        public ActionResult<Category> Post(CreateCategoryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_categoryService.Add(request));
        }

        [HttpGet("{category}")]
        public ActionResult<Category> Get(string? category)
        {
            if (string.IsNullOrEmpty(category))
                throw new NullReferenceException();
            return _categoryService.GetByName(category);
        }
    }
}