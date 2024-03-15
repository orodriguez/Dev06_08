using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Okane.Application;
using Okane.Domain;
using System.Text.RegularExpressions;

namespace Okane.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _expensesService;

    public ExpensesController(IExpenseService expensesService) => 
        _expensesService = expensesService;
    
    // POST /expenses
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExpenseResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDictionary))]
    public ActionResult<ExpenseResponse> Post(CreateExpenseRequest request)
    {
        string urlPattern = @"^(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w.-]*)*/?$";

        string url = request.InvoiceUrl;
        bool isValidUrl = Regex.IsMatch(url, urlPattern, RegexOptions.IgnoreCase);
        if (!isValidUrl)
        {
            ModelState.AddModelError("InvoiceUrl", "La url que has enviado no es una valida, por favor, verifica.");
            return BadRequest(ModelState);
        }


        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(_expensesService.Register(request));
    }
    
    // PUT /expenses
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExpenseResponse))]
    public ActionResult<ExpenseResponse> Post(int id, UpdateExpenseRequest request)
    {
        var response = _expensesService.Update(id, request);
        return Ok(response);
    }

    // GET /expenses
    [HttpGet]
    public IEnumerable<ExpenseResponse> Get(string? category) => 
        _expensesService.Search(category);

    // GET /expenses/:id
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExpenseResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ExpenseResponse> Get(int id)
    {
        var response = _expensesService.ById(id);
        if (response == null)
            return NotFound();
        
        return Ok(response);
    }

    // DELETE /expenses/:id
    [HttpDelete("{id}")]
    public bool Delete(int id) => 
        _expensesService.Delete(id);
}