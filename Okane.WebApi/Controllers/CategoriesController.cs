using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Okane.Application;
using Okane.Domain;

namespace Okane.WebApi.Controllers;

//[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService) => 
        _categoryService = categoryService;
    
    // POST /category
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDictionary))]
    public ActionResult<CategoryResponse> Post(CreateCategoryRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(_categoryService.Register(request));
    }
    
    // PUT /category
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryResponse))]
    public ActionResult<CategoryResponse> Put(int id, CreateCategoryRequest request)
    {
        var response = _categoryService.Update(id, request);
        return Ok(response);
    }

    // GET /category
    [HttpGet]
    public IEnumerable<CategoryResponse> Get(string? category) => 
        _categoryService.Search(category);

    // GET /category/:id
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ExpenseResponse> Get(int id)
    {
        var response = _categoryService.ById(id);
        if (response == null)
            return NotFound();
        
        return Ok(response);
    }

    // DELETE /category/:id
    [HttpDelete("{id}")]
    public bool Delete(int id) => 
        _categoryService.Delete(id);
}